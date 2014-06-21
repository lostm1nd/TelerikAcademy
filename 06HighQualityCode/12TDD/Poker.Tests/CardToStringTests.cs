using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void TestAceOfSpades()
        {
            Card aceOfSpades = new Card(CardFace.Ace, CardSuit.Spades);
            string result = aceOfSpades.ToString();
            Assert.AreEqual("A♠", result);
        }

        [TestMethod]
        public void TestTwoOfDiamonds()
        {
            Card twoOfDiamonds = new Card(CardFace.Two, CardSuit.Diamonds);
            string result = twoOfDiamonds.ToString();
            Assert.AreEqual("2♦", result);
        }

        [TestMethod]
        public void TestJackOfHearts()
        {
            Card jackOfHearts = new Card(CardFace.Jack, CardSuit.Hearts);
            string result = jackOfHearts.ToString();
            Assert.AreEqual("J♥", result);
        }

        [TestMethod]
        public void TestQueenOfClubs()
        {
            Card queenOfClubs = new Card(CardFace.Queen, CardSuit.Clubs);
            string result = queenOfClubs.ToString();
            Assert.AreEqual("Q♣", result);
        }

        [TestMethod]
        public void TestTenOfDiamonds()
        {
            Card tenOfDiamonds = new Card(CardFace.Ten, CardSuit.Diamonds);
            string result = tenOfDiamonds.ToString();
            Assert.AreEqual("10♦", result);
        }
    }
}
