using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack2
{
    public class Hand
    {
        public List<Card> Cards { set; get; }
        public int Number_of_cards { set; get; }
        public int Score { set; get; }
        public string Result { set; get; }

        // kontruktor vytvoří seznam a vloží do něj "prázdné" karty
        public Hand(int numcards)
        {
            Number_of_cards = numcards; // počet karet v ruce

            // vytvoří seznam karet
            Cards = new List<Card>(); 
            Card emptycard = new Card(); // prázdná karta

            for (int i = 0; i < numcards; i++)
            {
                // přidá příslušný počet prázdných karet do seznamu
                Cards.Add(emptycard);
            }
        }
   
        
        // vybere náhodnou kartu z balíčku a vloží ji místo jedné z prázdných karet 
        public void Add_card(Deck currentdeck)
        {
            bool added = false;
            int pickedcard = 0;

            // pokud je balíček skoro prázdný, vytvoří nový
            if (currentdeck.Cards.Count <= 2)
            {
                currentdeck.LoadDeck();
            }

            // vytvoří náhodné číslo, vybere tuto kartu z balíčku
            pickedcard = RandomNumber.NumberBetween(1, currentdeck.Cards.Count - 1);
            Card currentcard = currentdeck.Cards.ElementAt(pickedcard);
            Card tobereplaced = new Card();

            while (!added)
            {
                foreach (Card temp in Cards)
                {
                    // najde prázdnou kartu
                    if (temp.Suit == "")
                        tobereplaced = temp;
                }
                if (tobereplaced != null)
                {
                    Cards.Remove(tobereplaced); // odebere nalezenou prázdnou kartu
                    Cards.Add(currentcard); // přidá vytáhnutou náh. kartu z balíčku do ruky
                    added = true;
                    currentdeck.Cards.Remove(currentcard); // odebere tuto kartu z balíčku
                }
            }
        }
        
        // rozdá karty - zavolá add_card tolikrát, kolik je potřeba karet v ruce
        public void Deal_cards(Deck currentdeck, int numcards)
        {
            numcards = Cards.Count;
            for (int i = 0; i < numcards; i++)
            {
                Add_card(currentdeck);
            }
        }

        // vyhodnotí hodnotu karet v ruce
        public void Evaluate_hand()
        {
            Score = 0;

            foreach (Card temp in Cards)
            {
                if (temp.Value < 10) // pro karty 1-9 má karta přísl. hodnotu
                    Score = Score + temp.Value;
                else
                    Score = Score + 10; // pro obrázkové karty (J, Q, K) je hodnota 10
            }

            // úprava pro esa
            foreach (Card temp in Cards)
            {
                if (temp.Value == 1 && Score + 10 <= 21)    // pokud eso s hodnotou 11 není více než 21
                    Score = Score + 10;                     // přidá k hodnotě ruky 10, aby eso bylo 11
            }

            // zobrazení hodnoty ruky v richTextBoxu pomocí stringu result
            if (Score > 21)
            {
                Result = "Jsi přes, prohrál jsi.";
            }
            else
            {
                Result = "Máš " + Score + ".";
            }
        }
    }
}