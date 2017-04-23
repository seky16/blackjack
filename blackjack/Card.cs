using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Card
    {
        public string Suit { set; get; }
        public int Value { set; get; }
        public int CardIndex { set; get; }

        // konstruktor generuje prázdnou kartu, té později přiřadíme hodnotu
        public Card()
        {
            Value = -1;
            Suit = "";
            CardIndex = -1;
        }
    }
}
