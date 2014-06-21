using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandsChecker
    {
        [TestMethod]
        public void TestValidHandConsistingOfFiveDifferentCards()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Clubs));

            Assert.AreEqual(true, checker.IsValidHand(hand), "The test hand is valid so the checker does not work properly.");
        }

        [TestMethod]
        public void TestInvalidHandConsistingOfFiveRepeatingCards()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));

            Assert.AreEqual(false, checker.IsValidHand(hand), "The test hand is invalid so the checker does not work properly.");
        }

        [TestMethod]
        public void TestHandHoldingValidFlush()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));

            Assert.AreEqual(true, checker.IsValidHand(hand), "The test hand is valid so the checker does not work properly.");
            Assert.AreEqual(true, checker.IsFlush(hand), "The test hand is valid flush so the checker does not work properly.");
        }

        [TestMethod]
        public void TestHandHoldingInvalidFlush()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));

            Assert.AreEqual(false, checker.IsValidHand(hand), "The test hand is invalid so the checker does not work properly.");
            Assert.AreEqual(true, checker.IsFlush(hand), "The test hand is valid flush so the checker does not work properly.");
        }

        [TestMethod]
        public void TestHandWithNoFlush()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));

            Assert.AreEqual(false, checker.IsFlush(hand), "The test hand is invalid flush so the checker does not work properly.");
        }

        [TestMethod]
        public void TestForValidFourOfAKind()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));

            Assert.AreEqual(true, checker.IsValidHand(hand), "The test hand is valid so the checker does not work properly.");
            Assert.AreEqual(true, checker.IsFourOfAKind(hand), "The test hand is valid four of a kind so the checker does not work properly.");
        }

        [TestMethod]
        public void TestForInvalidFourOfAKind()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            hand.Cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            hand.Cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));

            Assert.AreEqual(false, checker.IsValidHand(hand), "The test hand is invalid so the checker does not work properly.");
            Assert.AreEqual(true, checker.IsFourOfAKind(hand), "The test hand is valid four of a kind so the checker does not work properly.");
        }
    }
}
