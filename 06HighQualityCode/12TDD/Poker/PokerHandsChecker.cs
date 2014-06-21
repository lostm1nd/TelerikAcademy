using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i+1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].ToString() == hand.Cards[j].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            // we need to check only the first two
            // because if they are not the same face
            // as the rest we cannot form four of a kind
            for (int i = 0; i < 2; i++)
            {
                // we count the current card
                // so we start at 1
                int fourOfAKind = 1;

                for (int j = i+1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        fourOfAKind++;
                    }
                }

                if (fourOfAKind == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            int spadesCounter = 0;
            int diamondsCounter = 0;
            int clubsCounter = 0;
            int heartsCounter = 0;

            foreach (var card in hand.Cards)
            {
                switch (card.Suit)
                {
                    case CardSuit.Clubs:
                        clubsCounter++;
                        break;
                    case CardSuit.Diamonds:
                        diamondsCounter++;
                        break;
                    case CardSuit.Hearts:
                        heartsCounter++;
                        break;
                    case CardSuit.Spades:
                        spadesCounter++;
                        break;
                    default:
                        break;
                }
            }

            if (spadesCounter == 5 || diamondsCounter == 5 ||
                clubsCounter == 5 || heartsCounter == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
