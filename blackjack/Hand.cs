using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Hand
    {
        public List<Card> CardsInHand { set; get; }
        public int NumberOfCards { set; get; }
        public int Score { set; get; }
        public string Result { set; get; }
        public static Form1 form;

        // konstruktor vytvoří seznam a vloží do něj "prázdné" karty
        public Hand(int numcards)
        {
            NumberOfCards = numcards; // počet karet v ruce

            // vytvoří seznam karet
            CardsInHand = new List<Card>();
            Card emptycard = new Card(); // prázdná karta

            for (int i = 0; i < numcards; i++)
            {
                // přidá příslušný počet prázdných karet do seznamu
                CardsInHand.Add(emptycard);
            }
        }

        private bool CheckDeck(Deck currentdeck)
        {
            while (true)
            {
                if (currentdeck.Cards.Count <= 0)
                {
                    if (form.Deck1.Cards.Count <= 0 && form.Deck2.Cards.Count <= 0 && form.Deck3.Cards.Count <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("\"Míchám\"", "Krupiér");
                        form.Deck1 = new Deck(1);
                        form.Deck2 = new Deck(2);
                        form.Deck3 = new Deck(3);
                        form.CurrentDeck = form.Deck1;
                        return true;
                    }
                    form.SwitchDecks();
                    currentdeck = form.CurrentDeck;
                    continue;
                }
                else
                {
                    return true;
                }
            }
        }

            // vybere náhodnou kartu z balíčku a vloží ji místo jedné z prázdných karet
            public void AddCard(Deck currentdeck)
        {
            bool added = false;

            // vymění balíčky
            form.SwitchDecks();

            // vytvoří náhodné číslo, vybere tuto kartu z balíčku
            int pickedcard = RandomNumber.Between(0, currentdeck.Cards.Count-1);

            Card currentcard = new Card();
            try
            {
                currentcard = currentdeck.Cards.ElementAt(pickedcard);
            }
            catch
            {
                while (!CheckDeck(currentdeck)) { form.SwitchDecks(); };
                currentdeck = form.CurrentDeck;
                pickedcard = RandomNumber.Between(0, currentdeck.Cards.Count - 1);

                try
                {
                    currentcard = currentdeck.Cards.ElementAt(pickedcard);
                }
                catch
                {
                    while (!CheckDeck(currentdeck)) { form.SwitchDecks(); };
                    currentdeck = form.CurrentDeck;
                    pickedcard = RandomNumber.Between(0, currentdeck.Cards.Count - 1);
                    currentcard = currentdeck.Cards.ElementAt(pickedcard);
                }
            }
            Card tobereplaced = new Card();

            while (!added)
            {
                foreach (Card temp in CardsInHand)
                {
                    // najde prázdnou kartu
                    if (temp.Suit == "")
                        tobereplaced = temp;
                }
                if (tobereplaced != null)
                {
                    CardsInHand.Remove(tobereplaced); // odebere nalezenou prázdnou kartu
                    CardsInHand.Add(currentcard); // přidá vytáhnutou náh. kartu z balíčku do ruky
                    added = true;
                    currentdeck.Cards.Remove(currentcard); // odebere tuto kartu z balíčku
                }
            }
        }

        // rozdá karty - zavolá add_card tolikrát, kolik je potřeba karet v ruce
        public void Deal(Deck currentdeck, int numcards)
        {
            numcards = CardsInHand.Count;
            for (int i = 0; i < numcards; i++)
            {
                AddCard(currentdeck);
            }
        }

        // vyhodnotí hodnotu karet v ruce
        public void Evaluate()
        {
            Score = 0;

            foreach (Card temp in CardsInHand)
            {
                if (temp.Value < 10) // pro karty 1-9 má karta přísl. hodnotu
                    Score = Score + temp.Value;
                else
                    Score = Score + 10; // pro obrázkové karty (J, Q, K) je hodnota 10
            }

            // úprava pro esa
            foreach (Card temp in CardsInHand)
            {
                if (temp.Value == 1 && Score + 10 <= 21)    // pokud eso s hodnotou 11 není více než 21
                    Score = Score + 10;                     // přidá k hodnotě ruky 10, aby eso bylo 11
            }

            // zobrazení hodnoty ruky v richTextBoxu pomocí stringu result
            if (Score > 21)
            {
                Result = null;
            }
            else
            {
                Result = "Máš " + Score + ".";
            }
        }
    }
}