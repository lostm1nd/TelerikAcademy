using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandToStringTests
    {
        [TestMethod]
        public void TestEmptyHand()
        {
            Hand emptyHand = new Hand(new List<ICard>());
            string result = emptyHand.ToString();
        }

        [TestMethod]
        public void TestOneCardHand()
        {
            Hand oneCardHand = new Hand(new List<ICard>());
            oneCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            string result = oneCardHand.ToString();
            Assert.AreEqual("10♣", result);
        }

        [TestMethod]
        public void TestTwoCardHand()
        {
            Hand twoCardHand = new Hand(new List<ICard>());
            twoCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            twoCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            string result = twoCardHand.ToString();
            Assert.AreEqual("10♣ 10♥", result);
        }

        [TestMethod]
        public void TestThreeCardHand()
        {
            Hand threeCardHand = new Hand(new List<ICard>());
            threeCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            threeCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            threeCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            string result = threeCardHand.ToString();
            Assert.AreEqual("10♣ 10♥ 10♦", result);
        }

        [TestMethod]
        public void TestFourCardHand()
        {
            Hand fourCardHand = new Hand(new List<ICard>());
            fourCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            fourCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            fourCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            fourCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            string result = fourCardHand.ToString();
            Assert.AreEqual("10♣ 10♥ 10♦ 10♠", result);
        }

        [TestMethod]
        public void TestFiveCardHand()
        {
            Hand fiveCardHand = new Hand(new List<ICard>());
            fiveCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            fiveCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            fiveCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            fiveCardHand.Cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            fiveCardHand.Cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            string result = fiveCardHand.ToString();
            Assert.AreEqual("10♣ 10♥ 10♦ 10♠ 2♣", result);
        }
    }
}
