using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Entities
{
    class Player
    {
        private string playerName;
        private int chips;

        public int Chips
        {
            get { return Chips; }
            set { Chips = value; }
        }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

    }
}
