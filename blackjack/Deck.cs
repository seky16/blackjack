using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Deck
    {
        public List<Card> Cards { set; get; }

        public Deck()
        {
            Cards = new List<Card>();
            LoadDeck();
        }

        // přídá karty v pořadí
        public void LoadDeck()
        {
            Cards.Clear();

            int i = 1;
            for (int s = 1; s < 5; s++) // 4 barvy
            {
                for (int v = 1; v < 14; v++) // 13 karet pro každou barvu
                {
                    // vytvoří novou kartu
                    Card currentcard = new Card();

                    // přiřadí index karty
                    currentcard.CardIndex = i;

                    // přiřadí barvu
                    if (s == 1)
                        currentcard.Suit = "spades";
                    if (s == 2)
                        currentcard.Suit = "clubs";
                    if (s == 3)
                        currentcard.Suit = "hearts";
                    if (s == 4)
                        currentcard.Suit = "diamonds";

                    // přiřadí hodnotu
                    currentcard.Value = v;

                    // přidá do balíčku
                    Cards.Add(currentcard);

                    // další karta
                    i++;
                }
            }
        }

        // vyhledání karty podle indexu karty
        public Card FindCard(int cardnum)
        {
            foreach (Card card in Cards)
            {
                if (card.CardIndex == cardnum)
                {
                    return card;
                }
            }
            return null;
        }
    }
}