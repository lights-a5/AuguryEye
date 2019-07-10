using AuguryEye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace TakePictures
{
    /// <summary>
    /// A simple project to help me to easily take pictures for testing
    /// </summary>
    class TakePicture
    {
        static void Main(string[] args)
        {
            CameraController camera = new CameraController();
            while (true)
            {
                Mat frame = camera.getCameraDisplay();
                Cv2.ImShow("pic", frame);
                int keyPress = Cv2.WaitKey(3);
                if (keyPress == 32)
                {
                    Cv2.ImWrite("cameraPic.jpg", frame);
                }

            }
        }
    }
}
