using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blackjack
{
    public partial class Form1 : Form
    {
        public Deck CurrentDeck;
        public Deck Deck1;
        public Deck Deck2;
        public Deck Deck3;

        private Player PlayerHand;
        private Dealer DealerHand;

        private int Tie { get; set; }
        private int Loss { get; set; }
        private int Win { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.Icon = (Icon)Properties.Resources.ResourceManager.GetObject("blackjack");
            Hand.form = this;

            // při inicializaci zobrazí pouze tlačítko "Rozdat" a skryje karty
            ShowButton(1);
            HideCards();

            // vytvoří tři balíčky
            Deck1 = new Deck(1);
            Deck2 = new Deck(2);
            Deck3 = new Deck(3);
            CurrentDeck = Deck1;

            // zobrazení skóre
            UpdateScore(0, 0, 0);
        }

        // při zavolání náhodně vybere jeden ze tří balíčků
        public void SwitchDecks()
        {
            int i = RandomNumber.Between(1, 3);
            if (i == 1)
            {
                if      (CurrentDeck.Id == 2) { Deck2 = CurrentDeck; }
                else if (CurrentDeck.Id == 3) { Deck3 = CurrentDeck; }
                CurrentDeck = Deck1;
            }
            else if (i == 2)
            {
                if      (CurrentDeck.Id == 1) { Deck1 = CurrentDeck; }
                else if (CurrentDeck.Id == 3) { Deck3 = CurrentDeck; }
                CurrentDeck = Deck2;

            }
            else if (i == 3)
            {
                if      (CurrentDeck.Id == 1) { Deck1 = CurrentDeck; }
                else if (CurrentDeck.Id == 2) { Deck2 = CurrentDeck; }
                CurrentDeck = Deck3;
            }
        }

        // zobrazí skóre
        private void UpdateScore()
        {
            label3.Text = "Výhry:"  + Convert.ToString(Win);
            label4.Text = "Prohry:" + Convert.ToString(Loss);
            label5.Text = "Remízy:" + Convert.ToString(Tie);
        }
        private void UpdateScore(int w, int l, int t)
        {
            this.Win  = w;
            this.Loss = l;
            this.Tie  = t;
            UpdateScore();
        }

        // zobrazí/skryje tlačítka
        private void ShowButton()
        {
            button1.Visible = false;    // "Rozdat"
            button2.Visible = true;     // "Další kartu"
            button3.Visible = true;     // "Skončit"

        }
        private void ShowButton(int R)
        {
            button1.Visible = true;     // "Rozdat"
            button2.Visible = false;    // "Další kartu"
            button3.Visible = false;    // "Skončit"
        }

        //skryje karty
        public void HideCards()
        {
            foreach (var pb in this.Controls.OfType<PictureBox>())
                pb.Visible = false;
        }

        // zobrazí karty v ruce hráče/krupiéra
        public void DisplayHand(Hand hand)
        {
            string currentcard_picture = null;
            List<PictureBox> HandPB = new List<PictureBox>();

            if (hand == PlayerHand)
            {
                HandPB.Add(pictureBox1);
                HandPB.Add(pictureBox2);
                HandPB.Add(pictureBox3);
                HandPB.Add(pictureBox4);
                HandPB.Add(pictureBox5);
                HandPB.Add(pictureBox6);
                HandPB.Add(pictureBox7);
                HandPB.Add(pictureBox8);
                HandPB.Add(pictureBox9);
                HandPB.Add(pictureBox10);
                HandPB.Add(pictureBox11);
                HandPB.Add(pictureBox12);
            }
            else
            {
                HandPB.Add(pictureBox13);
                HandPB.Add(pictureBox14);
                HandPB.Add(pictureBox15);
                HandPB.Add(pictureBox16);
                HandPB.Add(pictureBox17);
                HandPB.Add(pictureBox18);
                HandPB.Add(pictureBox19);
                HandPB.Add(pictureBox20);
                HandPB.Add(pictureBox21);
                HandPB.Add(pictureBox22);
                HandPB.Add(pictureBox23);
                HandPB.Add(pictureBox24);
            };

            int count = 0;
            if (hand.CardsInHand != null && hand != null)
                // každé kartě určí příslušný název souboru podle její hodnoty a barvy
                foreach (Card currentcard in hand.CardsInHand)
                {
                    if (currentcard != null && currentcard.Suit != "")
                    {
                        if (currentcard.Value < 10)
                            currentcard_picture = "_0" + currentcard.Value.ToString() + "_" + currentcard.Suit;
                        if (currentcard.Value == 10)
                            currentcard_picture = "_" + currentcard.Value.ToString() + "_" + currentcard.Suit;
                        if (currentcard.Value == 11)
                            currentcard_picture = "j" + "_" + currentcard.Suit;
                        if (currentcard.Value == 12)
                            currentcard_picture = "q" + "_" + currentcard.Suit;
                        if (currentcard.Value >= 13)
                            currentcard_picture = "k" + "_" + currentcard.Suit;
                    }

                    foreach (PictureBox pb in HandPB)
                    {
                        if (count == HandPB.IndexOf(pb))
                        {
                            pb.Visible = true;                                                                      // zviditelní PictureBox
                            pb.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(currentcard_picture); // přiřadí PictureBoxu příslušný soubor
                            pb.BringToFront();                                                                      // PictureBox do popředí
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;                                          // přizpůsobí obrázek velikosti PictureBoxu
                        }
                    }
                    count++;
                }
        }

        // tlačítko "ROZDAT"
        private void Button1_Click(object sender, EventArgs e)
        {
            // zobrazí tlačítka a skryje všechny karty
            ShowButton();
            HideCards();

            // vytvoří handy hráče a krupiéra
            PlayerHand = new Player(2);
            DealerHand = new Dealer(1);

            PlayerHand.Deal(CurrentDeck, 2);                                // rozdá hráči dvě karty
            DealerHand.Deal(CurrentDeck, 1);                                // rozdá krupiérovi jednu kartu

            DisplayHand(PlayerHand);                                        // zobrazí hráčovy karty
            DisplayHand(DealerHand);                                        // zobrazí krupiérovy karty
            PlayerHand.Evaluate();                                          // vyhodnotí hráčovy karty
            richTextBox1.Text = PlayerHand.Result + Environment.NewLine;    // zobrazí hodnotu hráč. karet v richTextBoxu

            DebugDecks();

            if (PlayerHand.Score == 21) // pokud má hráč ihned po rozdání 21 (blackjack), ukončí kolo
            {
                EndGame(PlayerHand, DealerHand);
            }
        }

        // tlačítko "DALŠÍ KARTU"
        private void Button2_Click(object sender, EventArgs e)
        {
            PlayerHand.AddCard(CurrentDeck);                                // přidá kartu do ruky
            DisplayHand(PlayerHand);                                        // zobrazí karty v ruce
            PlayerHand.Evaluate();                                          // vyhodnotí hráčovy karty
            richTextBox1.Text = PlayerHand.Result + Environment.NewLine;    // zobrazí hodnotu hráč. karet v richTextBoxu

            DebugDecks();

            if (PlayerHand.Score >= 21) // pokud je hráč přes 21 nebo má 21 (blackjack), ukončí kolo
            {
                EndGame(PlayerHand, DealerHand);
            }
        }

        // tlačítko "UKONČIT KOLO"
        private void Button3_Click(object sender, EventArgs e)
        {
            DebugDecks();
            EndGame(PlayerHand, DealerHand); // ukončí kolo
        }

        // konec kola
        private void EndGame(Hand PlayerHand, Hand DealerHand)
        {
            // pokud má hráč více než 21, zobrazí hlášku o prohře a přičte 1 k počtu proher
            if (PlayerHand.Score > 21)
            {
                richTextBox1.Text = "Jsi přes, prohrál jsi." + Environment.NewLine;
                richTextBox1.Find("prohrál");
                richTextBox1.SelectionColor = Color.Red;
                Loss++;
            }
            // pokud má hráč 21 (blackjack), zobrazí hlášku o výhře a přičte 1 k počtu výher
            else if (PlayerHand.Score == 21)
            {
                richTextBox1.Text = "Máš BLACKJACK, vyhrál jsi." + Environment.NewLine;
                richTextBox1.Find("vyhrál");
                richTextBox1.SelectionColor = Color.Green;
                Win++;
            }
            // hraje krupiér, bere karty dokud nemá 17 a více
            else while (DealerHand.Score < 17)
            {
                DealerHand.AddCard(CurrentDeck);    // přidá kartu do ruky
                DisplayHand(DealerHand);            // zobrazí karty v ruce
                DealerHand.Evaluate();              // vyhodnotí krupiérovy karty
            }
            // pokud má krupiér 21 (blackjack), zobrazí hlášku o prohře a přičte 1 k počtu proher
            if (DealerHand.Score == 21)
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má BLACKJACK, prohrál jsi." + Environment.NewLine;
                richTextBox1.Find("prohrál");
                richTextBox1.SelectionColor = Color.Red;
                Loss++;
            }
            // pokud má krupiér více než 21, zobrazí hlášku o výhře a přičte 1 k počtu výher
            else if (DealerHand.Score > 21)
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + DealerHand.Score + ", vyhrál jsi." + Environment.NewLine;
                richTextBox1.Find("vyhrál");
                richTextBox1.SelectionColor = Color.Green;
                Win++;
            }
            // pokud má hráč více než krupiér, zobrazí hlášku o výhře a přičte 1 k počtu výher
            else if ((PlayerHand.Score > DealerHand.Score) && (PlayerHand.Score <= 21) && (DealerHand.Score > 0))
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + DealerHand.Score + ", vyhrál jsi." + Environment.NewLine;
                richTextBox1.Find("vyhrál");
                richTextBox1.SelectionColor = Color.Green;
                Win++;
            }
            // pokud má hráč méně než krupiér, zobrazí hlášku o prohře a přičte 1 k počtu proher
            else if (PlayerHand.Score < DealerHand.Score)
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + DealerHand.Score + ", prohrál jsi." + Environment.NewLine;
                richTextBox1.Find("prohrál");
                richTextBox1.SelectionColor = Color.Red;
                Loss++;
            }
            // pokud mají hráč i krupiér stejně, zobrazí hlášku o remíze a přičte 1 k počtu remíz
            else if (PlayerHand.Score == DealerHand.Score)
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + DealerHand.Score + ", remíza." + Environment.NewLine;
                richTextBox1.Find("remíza");
                richTextBox1.SelectionColor = Color.Blue;
                Tie++;
            }

            // znovu zobrazí tlačítko "ROZDAT" a skryje tlačítka "DALŠÍ KARTU" a "UKONČIT KOLO"
            ShowButton(1);

            // aktualizuje skóre
            UpdateScore();
        }

        // zobrazí pravidla hry
        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Pravidla hry blackjack (upraveno):" + Environment.NewLine + Environment.NewLine +
                "Hráč na začátku hry obdrží dvě karty a pak mu krupiér nabízí další karty, krupiér má pouze jednu kartu. Hráč se na začátku a po každé další kartě rozhoduje, zda bude chtít další kartu, nebo ne. Základní princip hry je, že hráč chce mít hodnotu karet blíže 21 než krupiér, ale přitom 21 nepřekročit. Vyhrává ten, kdo má po ukončení hry v ruce nejvyšší součet, aniž by překročil 21. Hráč, který má v ruce součet karet větší než 21, je tzv. „přes“." + Environment.NewLine +
                "Karty od 2 do 10 mají při počítání stejnou hodnotu, jaká je uvedena na kartě. Karty J, Q, K (spodek, královna a král) mají hodnotu 10. Eso (A) se počítá dle situace za 1 nebo za 11. Barvy karet nemají žádný význam." + Environment.NewLine +
                "Pokud je hráč „přes“, vždy prohrává, a to i tehdy, pokud je „přes“ i krupiér. Pokud mají hráč i krupiér stejný počet bodů, končí hra nerozhodně a nikdo nevyhrává. Součet 21 je vždy označen jako BLACKJACK a pokud jej dosáhne hráč, automaticky vyhrává." + Environment.NewLine +
                "Krupiér začíná hrát až hráč ukončí kolo (tlačítko SKONČIT). Narozdíl od hráče je při volbě dalšího postupu výrazně omezen. Pokud je součet jeho karet menší než 17, musí vždy vzít další kartu. Pokud má 17 a víc, nesmí brát další kartu, musí zůstat stát a ukončit tak hru." + Environment.NewLine +
                "Není možné hrát DOUBLE, SPLIT nebo POJIŠTĚNÍ. Hraje se se třemi balíčky.");
        }

        // resetuje skóre
        private void Button5_Click(object sender, EventArgs e)
        {
            UpdateScore(0,0,0);
        }

        // zobrazuje stav balíčků v okně, pouze pro vývoj
        private void DebugDecks()
        {
            richTextBox2.Text = "CD (Deck" + CurrentDeck.Id + "):" + Environment.NewLine;
            foreach (Card card in CurrentDeck.Cards)
            {
                richTextBox2.Text += card.Value + "." + card.Suit[0] + " ";
            }
            richTextBox2.Text += Environment.NewLine + Environment.NewLine + "D1: " + Environment.NewLine;
            foreach (Card card in Deck1.Cards)
            {
                richTextBox2.Text += card.Value + "." + card.Suit[0] + " ";
            }
            richTextBox2.Text += Environment.NewLine + Environment.NewLine + "D2: " + Environment.NewLine;
            foreach (Card card in Deck2.Cards)
            {
                richTextBox2.Text += card.Value + "." + card.Suit[0] + " ";
            }
            richTextBox2.Text += Environment.NewLine + Environment.NewLine + "D3: " + Environment.NewLine;
            foreach (Card card in Deck3.Cards)
            {
                richTextBox2.Text += card.Value + "." + card.Suit[0] + " ";
            }
        }
    }
}
