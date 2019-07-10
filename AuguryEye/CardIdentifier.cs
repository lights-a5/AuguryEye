using DupImageLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using QuickType;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuguryEye
{

    /// <summary>
    /// Provides several functions to help identify images of cards. The image should
    /// already be processed and contains exactly the card.
    /// </summary>
    public class CardIdentifier
    {
        readonly Dictionary<ulong, string> imageHashDictionary;
        readonly List<Card> cards;

        ImageHashes imageHash = new ImageHashes(new ImageMagickTransformer());

        public CardIdentifier(string imageHashDictionaryPath, string scryfallJsonPath, bool sorted = false)
        {

            string hashDictionaryJson;
            using (StreamReader r = new StreamReader(imageHashDictionaryPath))
            {
                Console.WriteLine("Loading Hash");
                hashDictionaryJson = r.ReadToEnd();
            }
            string scryfallJson;
            using (StreamReader r = new StreamReader(scryfallJsonPath))
            {
                Console.WriteLine("Loading Card Objects");
                scryfallJson = r.ReadToEnd();
            }

            imageHashDictionary = JsonConvert.DeserializeObject<Dictionary<ulong, string>>(hashDictionaryJson);
            JArray cardsJArray = JArray.Parse(scryfallJson);
            cards = cardsJArray.ToObject<List<Card>>();
            if (!sorted) cards.Sort(new CardCompareGuid());
        }

        public CardIdentifier(string imageHashDictionaryPath)
        {
            string hashDictionaryJson;
            using (StreamReader r = new StreamReader(imageHashDictionaryPath))
            {
                Console.WriteLine("Loading Hash");
                hashDictionaryJson = r.ReadToEnd();
            }
            imageHashDictionary = JsonConvert.DeserializeObject<Dictionary<ulong, string>>(hashDictionaryJson);
            cards = null;

        }

        /// <summary>
        /// Finds the closest hash of a card and returns the GUID of the closest card.
        /// </summary>
        /// <param name="incomingHash"></param>
        /// <returns></returns>
        // TODO: Fix ids after removing ".jpg" from dictionary
        // TODO: Make work with double-sided
        public string FindMatch(ulong incomingHash)
        {
            float LeastHammingDistance = 0;
            ulong closestHash = 0; 
            foreach(ulong key in imageHashDictionary.Keys) 
            {
                float hammingDistance = ImageHashes.CompareHashes(incomingHash, key);
                if (hammingDistance >= LeastHammingDistance)
                {
                    LeastHammingDistance = hammingDistance;
                    closestHash = key;
                }
            };
            string idOfCard = imageHashDictionary[closestHash];
            return idOfCard.Substring(0, idOfCard.Length - 4);
        }

        /// <summary>
        /// Calculates the DCT Hash of a Mat Image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public ulong getHash(Mat image)
        {
            byte[] bytearray = image.ImEncode(".jpg");
            MemoryStream stream = new MemoryStream(bytearray);
            return imageHash.CalculateDctHash(stream);
        }

        /// <summary>
        /// Calculates the DCT Hash of a saved file.
        /// </summary>
        /// <param name="imagefile"></param>
        /// <returns></returns>
        public ulong getHash(string imagefile)
        {
            return imageHash.CalculateDctHash(imagefile);
        }

        /// <summary>
        /// Returns a card with the id given.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Card matchIdToCard(string id)
        {
            Card cardIndicator = new Card();
            cardIndicator.Id = new Guid(id);
            CardCompareGuid comparer = new CardCompareGuid();
            return cards[cards.BinarySearch(cardIndicator, comparer)];
        }

        /// <summary>
        /// Returns the closest card by image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Card GetCardByImage(Mat image)
        {
            ulong incomingHash = getHash(image);
            string cardId = FindMatch(incomingHash);
            return matchIdToCard(cardId);
        }

        public void saveScryfallJson(string filePath)
        {
            string jsonScryfall = JsonConvert.SerializeObject(cards);
            File.WriteAllText(filePath, jsonScryfall);
        }
    }
}


/// <summary>
/// Simple comparer class to help comparisons of cards
/// </summary>
public class CardCompareGuid : Comparer<Card>
{
    public override int Compare(Card x, Card y)
    {
        return x.Id.CompareTo(y.Id);
    }
}