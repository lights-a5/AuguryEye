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
            Mat definitionImage = new Mat("testRes\\captured.jpg");
            Mat testImage = new Mat("testRes\\original.jpg");
            CameraController camera = new CameraController();
            CardIdentifier identifier = new CardIdentifier("imageHashMap.json");

            Mat returnedImage = camera.GetCardImage(testImage);

            Assert.AreEqual(identifier.getHash(definitionImage), identifier.getHash(returnedImage));            
        }
    }
}