using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCvSharp;
using QuickType;

namespace AuguryEye.Tests
{
    [TestClass]
    public class CardIdentifierTests
    {
        static CardIdentifier identifier;
        [ClassInitialize]
        public static void setupIdentifier(TestContext a)
        {
            identifier = new CardIdentifier("imageHashMap.json", "sortedScryfall.json", true);
        }

        [TestMethod]
        public void GetHash_ImageFileAndImageStream_AreEqual()
        {
            Mat testImage = Cv2.ImRead("testRes\\captured.jpg");
            ulong hash = identifier.getHash(testImage);
            ulong hash2 = identifier.getHash("testRes\\captured.jpg");
            Assert.AreEqual(hash, hash2);
        }

        [TestMethod]
        public void FindMatch_Hash_AreEqual()
        {
            Mat testImage = Cv2.ImRead("testRes\\captured.jpg");
            ulong hash = identifier.getHash(testImage);
            string idOfCard = identifier.FindMatch(hash);
            Assert.AreEqual("da0966a6-f378-4975-88ae-23b600d578bf.jpg", idOfCard);
        }

        [TestMethod]
        public void matchIdToCard_goodNormalString_AreEqual()
        {
            string idToTest = "0000cd57-91fe-411f-b798-646e965eec37";
            Card identifiedCard = identifier.matchIdToCard(idToTest);
            Assert.AreEqual(identifiedCard.Id.ToString(), idToTest);         
        }

        [TestMethod]
        public void GetCardByImage_ValidImage_AreEqual()
        {
            Mat testImage = Cv2.ImRead("testRes\\captured.jpg");

            Card card = identifier.GetCardByImage(testImage);

            Assert.AreEqual("Cyclops Electromancer", card.Name);
            
        }
    }
}
