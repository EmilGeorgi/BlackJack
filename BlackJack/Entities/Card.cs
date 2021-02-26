using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Entities
{
    class Card
    {
        private int cardValue;
        private string cardSuite;
        private string cardName;

        public Card(string cardName)
        {
            CardName = cardName;
        }
        public Card(string cardName, string cardSuite)
        {
            CardName = cardName;
            CardSuite = cardSuite;
        }

        public int CardValue
        {
            get { return cardValue; }
            set
            {
                if (value > 11)
                {
                    throw new ArgumentException("card value can't be higher then 11");
                }
                else
                {
                    cardValue = value;
                }
            }
        }
        public string CardSuite
        {
            get { return cardSuite; }
            set { cardSuite = value; }
        }
        public string CardName
        {
            get { return cardName; }
            set 
            {
                if (int.TryParse(value, out int currvalue))
                {
                    CardValue = currvalue;
                }
                else if(value == "ace")
                {
                    CardValue = 11;
                }
                else
                {
                    CardValue = 10;
                }
                cardName = value;
            }
        }
    }
}
