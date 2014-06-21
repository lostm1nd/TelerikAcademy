using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder();

            for (int i = 0; i < this.Cards.Count; i++)
            {
                hand.Append(this.Cards[i].ToString());

                if (i < this.Cards.Count - 1)
                {
                    hand.Append(' ');
                }
            }

            return hand.ToString();
        }
    }
}
