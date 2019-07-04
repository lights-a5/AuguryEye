using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuguryEye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace AuguryEye.Tests
{
    [TestClass()]
    public class CameraControllerTests
    {
        [TestMethod()]
        public void ExtractCardImageTest()
        {
            CameraController controller = new CameraController();
            Mat testImage = new Mat("F:\\camera_cap.jpg");

            Mat returnedImage = controller.GetCardImage(testImage);
            Cv2.ImWrite("testRes/original.jpg", testImage);
            Cv2.ImWrite("testRes/captured.jpg", returnedImage);
                        
        }
    }
}