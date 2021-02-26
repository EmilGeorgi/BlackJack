using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Entities
{
    class Hand
    {
        #region fields
        private List<Card> cards;
        #endregion
        #region constructor
        public Hand(Deck deck)
        {
            Cards = new List<Card>();
            this.RoundStart(deck);
        }
        #endregion
        #region props
        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        #endregion
        #region methods
        public override string ToString()
        {
            int currValue = 0;
            foreach (Card card in Cards)
            {
                currValue += card.CardValue;
            }
            return currValue.ToString();
        }
        public string GetCards()
        {
            string cards = "";
            foreach (Card card in Cards)
            {
                cards += $"{card.CardName} of {card.CardSuite} \n";
            }
            return cards;
        }
        public void RoundStart(Deck deck)
        {
            Cards.Add(deck.DrawCard());
            Cards.Add(deck.DrawCard());
        }
        public void AddCard(Deck deck)
        {
            int currValue = 0;
            Cards.Add(deck.DrawCard());
            foreach (Card card in Cards)
            {
                currValue += card.CardValue;
            }
            foreach (Card card in Cards)
            {
                if (currValue > 21)
                {
                    if (card.CardValue == 11)
                    {
                        card.CardValue = 1;
                        currValue =- 10;
                    }
                }
            }
        }
        public int GetValue()
        {
            int currVal = 0;
            foreach (Card card in Cards)
            {
                currVal += card.CardValue;
            }
            return currVal;
        }
        #endregion
    }
}
