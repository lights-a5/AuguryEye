using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace AuguryEye
{
    /// <summary>
    /// Captures images from a camera and processes them.
    /// </summary>
    public class CameraController
    {
        VideoCapture capture;
        Rect roi;
        
        /// <summary>
        /// A controller for both camera and image input.
        /// </summary>
        /// <param name="camera"></param>
        public CameraController(int camera = 0)
        {
            capture = new VideoCapture(camera);
            Mat tempImage = new Mat();
            capture.Read(tempImage);
            roi = GetRoi(tempImage);
        }

        /// <summary>
        /// Gets the current display of the camera with indicator of the roi.
        /// </summary>
        /// <returns>camera input with roi indicators</returns>
        public Mat getCameraDisplay()
        {
            Mat image = new Mat();
            capture.Read(image);
            return addRoiDots(image);
        }

        /// <summary>
        /// Adds red dots to an image where the roi is.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Mat addRoiDots(Mat image)
        {
            Cv2.Circle(image, roi.Left, roi.Top, 1, new Scalar(0, 0, 255), -1);
            Cv2.Circle(image, roi.Right, roi.Top, 1, new Scalar(0, 0, 255), -1);
            Cv2.Circle(image, roi.Right, roi.Bottom, 1, new Scalar(0, 0, 255), -1);
            Cv2.Circle(image, roi.Left, roi.Bottom, 1, new Scalar(0, 0, 255), -1);
            return image;
        }

        /// <summary>
        /// Gets an image of a card from the camera
        /// </summary>
        /// <returns>Mat</returns>
        public Mat GetCardFromCamera()
        {
            Mat image = new Mat();
            capture.Read(image);
            return GetCardImage(image);
        }

        /// <summary>
        /// Crops and Transforms Image to return an image of a card
        /// </summary>
        /// <param name="imageInput"></param>
        /// <returns>Mat[]</returns>
        public Mat GetCardImage(Mat imageInput)
        {
            Mat image = imageInput;
            image = new Mat(image, roi);
            Mat transformedImage = GetTransformedImage(image);
            Mat returnCardImage = new Mat();

            Point[][] contours;
            HierarchyIndex[] outputArray;
            //Only external contours... we don't want the textbox or the art of the card
            Cv2.FindContours(transformedImage, out contours, out outputArray, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            //FindContours will give array of contours detected in image. Here we filter to get the contour of a card by...
            foreach (Point[] contour in contours)
            {
                //shaping out the contour
                Point[] contourPoints = Cv2.ApproxPolyDP(contour, .01 * Cv2.ArcLength(contour, true), true);
                //and then checking if it's a rectangle and is big enough to be our card...
                if (contourPoints.Length == 4 && Cv2.ContourArea(contour) > 600)
                {
                    //if it is, apply a perspective transform to get a flat image and return it
                    Point2f[] arrayContourPoints = new Point2f[4];
                    for (int i = 0; i < arrayContourPoints.Length; i++)
                    {
                        arrayContourPoints[i] = contourPoints[i];
                    }
                    var corners = GetCorners(arrayContourPoints);
                    int rotation = GetCardRotation(corners);
                    ///The order of the corners matter for the perspective transform. The order differs depending on rotation.
                    if (rotation < 0)
                    {
                        arrayContourPoints[0] = corners["leftCorner"];
                        arrayContourPoints[1] = corners["topCorner"];
                        arrayContourPoints[2] = corners["bottomCorner"];
                        arrayContourPoints[3] = corners["rightCorner"];
                    }
                    else
                    {
                        arrayContourPoints[0] = corners["topCorner"];
                        arrayContourPoints[1] = corners["rightCorner"];
                        arrayContourPoints[2] = corners["leftCorner"];
                        arrayContourPoints[3] = corners["bottomCorner"];
                    }
                    Point2f[] destinationPoints = { new Point(0, 0), new Point(672, 0), new Point(0, 936), new Point(672, 936)};

                    Mat perspective = Cv2.GetPerspectiveTransform(arrayContourPoints, destinationPoints);

                    Cv2.WarpPerspective(image, returnCardImage, perspective, new Size(672, 936));
                    break;
                }
            }
            return returnCardImage;
        }
        /// <summary>
        /// Gets rotation of card. 1 is clockwise. -1 is counterclockwise.
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <returns></returns>
        private int GetCardRotation(Dictionary<string, Point2f> corners)
        {
            Point2f topCorner = corners["topCorner"];
            Point2f leftCorner = corners["leftCorner"];
            Point2f rightCorner = corners["rightCorner"];
            double distanceFromLeft = Math.Sqrt(Math.Pow((topCorner.X - leftCorner.X), 2.0) + Math.Pow((topCorner.Y - leftCorner.Y), 2.0));
            double distanceFromRight = Math.Sqrt(Math.Pow((topCorner.X - rightCorner.X), 2.0) + Math.Pow((topCorner.Y - rightCorner.Y), 2.0));
            if (distanceFromLeft > distanceFromRight) return 1;
            else return -1;
        }

        /// <summary>
        /// Returns a dictionary that shows which points are which corners
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <returns></returns>
        private Dictionary<string, Point2f> GetCorners(Point2f[] cardPoints)
        {
            Point2f leftCorner = new Point2f(int.MaxValue, int.MaxValue);
            Point2f rightCorner = new Point2f(0, 0);
            Point2f topCorner = new Point2f(int.MaxValue, int.MaxValue);
            Point2f bottomCorner = new Point2f(0, 0);
            foreach (Point2f point in cardPoints)
            {
                if (point.Y < topCorner.Y)
                {
                    topCorner = point;
                }
                if (point.X < leftCorner.X)
                {
                    leftCorner = point;
                }
                if (point.X > rightCorner.X)
                {
                    rightCorner = point;
                }
                if (point.Y > bottomCorner.Y)
                {
                    bottomCorner = point;
                }
            }
            var returnDict = new Dictionary<string, Point2f>();
            returnDict.Add("topCorner", topCorner);
            returnDict.Add("leftCorner", leftCorner);
            returnDict.Add("rightCorner", rightCorner);
            returnDict.Add("bottomCorner", bottomCorner);
            return returnDict;
        }

        /// <summary>
        /// Gets the Rectangle of the Roi
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Rect of the Roi</returns>
        private Rect GetRoi(Mat image)
        {
            int topBorder = image.Size().Height / 5;
            int bottomBorder = topBorder * 4;
            int leftBorder = (int)(image.Size().Width / 2 - (topBorder * 1.5));
            int rightBorder = (int)(image.Size().Width / 2 + (topBorder * 1.5));
            Rect roi;
            roi.X = leftBorder;
            roi.Y = topBorder;
            roi.Height = bottomBorder - topBorder;
            roi.Width = rightBorder - leftBorder;
            return roi;
        }
        /// <summary>
        /// Get a Transformed Version of the image for processing contours
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Transformed Image</returns>    
        private Mat GetTransformedImage(Mat image)
        {
            Mat returnImage = new Mat();
            Cv2.CvtColor(image, returnImage, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(returnImage, returnImage, new OpenCvSharp.Size(5.0, 5.0), 0);
            Cv2.Threshold(returnImage, returnImage, 100, 255, ThresholdTypes.BinaryInv);
            return returnImage;
        }
    }
}
