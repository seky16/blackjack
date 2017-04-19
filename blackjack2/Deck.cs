using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack2
{
    public class Deck
    {
        // balíček je seznam karet
        public List<Card> Cards { set; get; } 

        // vytvoří balíček
        public Deck() 
        {
            Cards = new List<Card>();
            LoadDeck();
        }

        // přídá karty v pořadí
        public void LoadDeck()
        {
            Cards.Clear();
            int cardnum = 1;

            for (int i = 1; i < 5; i++) // 4 barvy
            {
                for (int j = 1; j < 14; j++) // 13 karet pro každou barvu
                {
                    // vytvoří novou kartu
                    Card currentcard = new Card();

                    // přiřadí index karty
                    currentcard.Card_number = cardnum;

                    // přiřadí barvu
                    if (i == 1)
                        currentcard.Suit = "spades";
                    if (i == 2)
                        currentcard.Suit = "clubs";
                    if (i == 3)
                        currentcard.Suit = "hearts";
                    if (i == 4)
                        currentcard.Suit = "diamonds";

                    // přiřadí hodnotu
                    currentcard.Value = j;

                    // přidá do balíčku
                    Cards.Add(currentcard); 
                                           
                    // další karta
                    cardnum++;
                }
            }
        }
 
        // vyhledání karty podle indexu karty
        public Card FindCard(int cardnum)
        {
            foreach (Card a_card in Cards)
            {
                if (a_card.Card_number == cardnum)
                {
                    return a_card;
                }
            }
            return null;
        }
   

    } 
}