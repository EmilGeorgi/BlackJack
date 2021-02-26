using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Entities
{
    class Deck
    {
        #region fields
        private List<Card> cards;
        #endregion
        #region props
        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        #endregion
        #region methods
        public Card DrawCard()
        {
            Random rng = new Random();
            int index = rng.Next(Cards.Count);
            Card drawedCard = Cards[index];
            Cards.Remove(drawedCard);
            return drawedCard;
        }
        /// <summary>
        /// used to generate the deck
        /// </summary>
        /// <param name="AmountOfDecks">1 deck = 52 cards</param>
        public void GenerateDeck(int AmountOfDecks)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < AmountOfDecks; i++)
            {
                string[] suites = new string[] { "diamonds", "spades", "hearts", "clubs" };
                for (int j = 0; j < 4; j++)
                {
                    cards.Add(new Card("2", suites[j]));
                    cards.Add(new Card("3", suites[j]));
                    cards.Add(new Card("4", suites[j]));
                    cards.Add(new Card("5", suites[j]));
                    cards.Add(new Card("6", suites[j]));
                    cards.Add(new Card("7", suites[j]));
                    cards.Add(new Card("8", suites[j]));
                    cards.Add(new Card("9", suites[j]));
                    cards.Add(new Card("10", suites[j]));
                    cards.Add(new Card("knight", suites[j]));
                    cards.Add(new Card("queen", suites[j]));
                    cards.Add(new Card("king", suites[j]));
                    cards.Add(new Card("ace", suites[j]));
                }
            }
            Cards = cards;
        }
        public override string ToString()
        {
            string DeckValue = "";
            foreach (Card card in Cards)
            {
                DeckValue += card.CardName + " ";
            }
            return DeckValue;
        }
        #endregion
    }
}
