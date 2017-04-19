using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blackjack2
{
    public partial class Form1 : Form
    {
        public Deck CurrentDeck { get; set; }
        public Hand PlayerHand { get; set; }
        public Hand DealerHand { get; set; }

        int win;
        int loss;
        int tie;

        public Form1()
        {
            InitializeComponent();


            // při inicializaci zobrazí pouze tlačítko "Rozdat", vytvoří balíček a skryje karty
            button1.Visible = true;     // "Rozdat"
            button2.Visible = false;    // "Další kartu"
            button3.Visible = false;    // "Skončit"
            Hide_cards();
            CurrentDeck = new Deck();

            // zobrazení skóre
            win = 0;
            loss = 0;
            tie = 0;

// TODO: změnit na metodu
            label3.Text = "Výhry:" + Convert.ToString(win);
            label4.Text = "Prohry:" + Convert.ToString(loss);
            label5.Text = "Remízy:" + Convert.ToString(tie);
        }

// TODO: vylepšit?
        //skryje karty
        public void Hide_cards()
        {
            // hráčovy karty
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;

            // krupiérovy karty
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
        }

// TODO: vylepšit
        // zobrazí hráčovy karty
        public void DisplayHand(Hand playerhand)
        {
            int count = 1;
            string currentcard_picture = "";

            if (playerhand.CardsInHand != null && playerhand != null)
                // každé kartě určí příslušný název souboru podle její hodnoty a barvy
                foreach (Card currentcard in playerhand.CardsInHand)
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

                    // postupně zobrazí každou kartu
                    if (count == 1)
                    {

                        pictureBox1.Visible = true;                                                             // zviditelní pictureBox
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;  
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);                             
                        pictureBox1.Image = myImage;                                                            // přiřadí pictureBoxu příslušný soubor
                        pictureBox1.BringToFront();                                                             // pictureBox do popředí
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;                                 // přizpůsobí obrázek velikosti pictureBoxu
                    }
                    if (count == 2)
                    {
                        pictureBox2.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox2.Image = myImage;
                        pictureBox2.BringToFront();
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 3)
                    {
                        pictureBox3.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox3.BringToFront();
                        pictureBox3.Image = myImage;
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 4)
                    {
                        pictureBox4.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox4.BringToFront();
                        pictureBox4.Image = myImage;
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 5)
                    {
                        pictureBox5.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox5.BringToFront();
                        pictureBox5.Image = myImage;
                        pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 6)
                    {
                        pictureBox6.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox6.BringToFront();
                        pictureBox6.Image = myImage;
                        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 7)
                    {
                        pictureBox7.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox7.BringToFront();
                        pictureBox7.Image = myImage;
                        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 8)
                    {
                        pictureBox8.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox8.BringToFront();
                        pictureBox8.Image = myImage;
                        pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 9)
                    {
                        pictureBox9.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox9.BringToFront();
                        pictureBox9.Image = myImage;
                        pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 10)
                    {
                        pictureBox10.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox10.BringToFront();
                        pictureBox10.Image = myImage;
                        pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 11)
                    {
                        pictureBox11.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox11.BringToFront();
                        pictureBox11.Image = myImage;
                        pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 12)
                    {
                        pictureBox12.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox12.BringToFront();
                        pictureBox12.Image = myImage;
                        pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    count++;
                }
        }

// TODO: vylepšit
        // zobrazí krupiérovy karty (stejně jako display_hand)
        public void DisplayDealerHand(Hand dealerhand)
        {
            int count = 1;
            string currentcard_picture = "";

            if (dealerhand.CardsInHand != null && dealerhand != null)
                foreach (Card currentcard in dealerhand.CardsInHand)
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

                    if (count == 1)
                    {
                        pictureBox13.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox13.Image = myImage;
                        pictureBox13.BringToFront();
                        pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 2)
                    {
                        pictureBox14.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox14.Image = myImage;
                        pictureBox14.BringToFront();
                        pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 3)
                    {
                        pictureBox15.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox15.BringToFront();
                        pictureBox15.Image = myImage;
                        pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 4)
                    {
                        pictureBox16.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox16.BringToFront();
                        pictureBox16.Image = myImage;
                        pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 5)
                    {
                        pictureBox17.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox17.BringToFront();
                        pictureBox17.Image = myImage;
                        pictureBox17.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 6)
                    {
                        pictureBox18.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox18.BringToFront();
                        pictureBox18.Image = myImage;
                        pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 7)
                    {
                        pictureBox19.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox19.BringToFront();
                        pictureBox19.Image = myImage;
                        pictureBox19.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 8)
                    {
                        pictureBox20.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox20.BringToFront();
                        pictureBox20.Image = myImage;
                        pictureBox20.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 9)
                    {
                        pictureBox21.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox21.BringToFront();
                        pictureBox21.Image = myImage;
                        pictureBox21.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 10)
                    {
                        pictureBox22.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox22.BringToFront();
                        pictureBox22.Image = myImage;
                        pictureBox22.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 11)
                    {
                        pictureBox23.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox23.BringToFront();
                        pictureBox23.Image = myImage;
                        pictureBox23.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (count == 12)
                    {
                        pictureBox24.Visible = true;
                        System.Resources.ResourceManager rm = blackjack2.Properties.Resources.ResourceManager;
                        Bitmap myImage = (Bitmap)rm.GetObject(currentcard_picture);
                        pictureBox24.BringToFront();
                        pictureBox24.Image = myImage;
                        pictureBox24.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    count++;
                }
        }

        // tlačítko "ROZDAT"
        private void Button1_Click(object sender, EventArgs e)
        {
            
            //CurrentDeck = new Deck(); // vytvoří nový balíček
            PlayerHand = new Hand(2); 
            DealerHand = new Hand(1);

            PlayerHand.DealCards(CurrentDeck, 2); // rozdá hráči dvě karty
            DealerHand.DealCards(CurrentDeck, 1); // rozdá krupiérovi jednu kartu

            // zobrazí tlačítka a skryje karty (budou zobrazeny později)
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            Hide_cards();

            DisplayHand(PlayerHand);                                      // zobrazí hráčovy karty
            DisplayDealerHand(DealerHand);                               // zobrazí krupiérovy karty
            PlayerHand.EvaluateHand();                                    // vyhodnotí hráčovy karty
            richTextBox1.Text = PlayerHand.Result + Environment.NewLine;   // zobrazí hodnotu hráč. karet v richTextBoxu
            

            if (PlayerHand.Score == 21)        // pokud má hráč ihned po rozdání 21 (blackjack), ukončí kolo
            {
                EndGame(PlayerHand, DealerHand);
            }
        }

        // tlačítko "DALŠÍ KARTU"
        private void Button2_Click(object sender, EventArgs e)
        {
            PlayerHand.AddCard(CurrentDeck);                              // přidá kartu do ruky
            DisplayHand(PlayerHand);                                      // zobrazí karty v ruce
            PlayerHand.EvaluateHand();                                    // vyhodnotí hráčovy karty
            richTextBox1.Text = PlayerHand.Result + Environment.NewLine;   // zobrazí hodnotu hráč. karet v richTextBoxu

            if (PlayerHand.Score >= 21) // pokud je hráč přes 21, ukončí kolo
            {
                EndGame(PlayerHand, DealerHand);
            }
        }

        // tlačítko "UKONČIT KOLO"
        private void Button3_Click(object sender, EventArgs e)
        {
            EndGame(PlayerHand, DealerHand); // ukončí kolo
        }

        // konec kola
        private void EndGame(Hand player_hand, Hand dealer_hand)
        {
            // pokud má hráč více než 21, zobrazí hlášku o prohře a přičte 1 k počtu proher
            if (player_hand.Score > 21)
            {
                richTextBox1.Text = "Jsi přes, prohrál jsi." + Environment.NewLine;
                loss++;
            }
            // pokud má hráč 21 (blackjack), zobrazí hlášku o výhře a přičte 1 k počtu výher
            else if (player_hand.Score == 21)
            {
                richTextBox1.Text = "Máš BLACKJACK, vyhrál jsi." + Environment.NewLine;
                win++; 
            }
            // hraje krupiér, bere karty dokud nemá 17 a více
            else while (dealer_hand.Score < 17)
            {
                dealer_hand.AddCard(CurrentDeck);  // přidá kartu do ruky
                DisplayDealerHand(dealer_hand);   // zobrazí karty v ruce
                dealer_hand.EvaluateHand();        // vyhodnotí krupiérovy karty
            }
            // pokud má krupiér 21 (blackjack), zobrazí hlášku o prohře a přičte 1 k počtu proher             
            if (dealer_hand.Score == 21)
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má BLACKJACK, prohrál jsi." + Environment.NewLine;
                loss++;
            }
            // pokud má krupiér více než 21, zobrazí hlášku o výhře a přičte 1 k počtu výher
            else if (dealer_hand.Score > 21)
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + dealer_hand.Score + ", vyhrál jsi." + Environment.NewLine;
                win++;
            }
            // pokud má hráč více než krupiér, zobrazí hlášku o výhře a přičte 1 k počtu výher
            else if ((player_hand.Score > dealer_hand.Score) && (player_hand.Score <= 21) && (dealer_hand.Score > 0))
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + dealer_hand.Score + ", vyhrál jsi." + Environment.NewLine;
                win++;
            }
            // pokud má hráč méně než krupiér, zobrazí hlášku o prohře a přičte 1 k počtu proher
            else if ((player_hand.Score < dealer_hand.Score) && (player_hand.Score <= 21) && (dealer_hand.Score <= 21))
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + dealer_hand.Score + ", prohrál jsi." + Environment.NewLine;
                loss++;
            }
            // pokud mají hráč i krupiér stejně, zobrazí hlášku o remíze a přičte 1 k počtu remíz
            else if ((player_hand.Score == dealer_hand.Score) && (player_hand.Score <= 21) && (dealer_hand.Score <= 21))
            {
                richTextBox1.Text += Environment.NewLine + "Krupiér má " + dealer_hand.Score + ", remíza." + Environment.NewLine;
                tie++;
            }
// TODO?
            // znovu zobrazí tlačítko "ROZDAT" a skryje tlačítka "DALŠÍ KARTU" a "UKONČIT KOLO"
            button1.Visible = true; 
            button2.Visible = false;
            button3.Visible = false;
// TODO 
            // aktualizuje skóre
            label3.Text = "Výhry:" + Convert.ToString(win);
            label4.Text = "Prohry:" + Convert.ToString(loss);
            label5.Text = "Remízy:" + Convert.ToString(tie);
        }

        // zobrazí pravidla hry
        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Pravidla hry blackjack (upraveno):" + Environment.NewLine + Environment.NewLine + 
                "Hráč na začátku hry obdrží dvě karty a pak mu krupiér nabízí další karty, krupiér má pouze jednu kartu. Hráč se po každé rozhoduje, zda bude chtít další, nebo ne. Základní princip hry je, že hráč chce mít hodnotu karet blíže 21 než krupiér, ale přitom 21 nepřekročit. Vyhrává ten, kdo má po ukončení hry v ruce nejvyšší součet, aniž by překročil 21. Hráč, který má v ruce součet karet větší než 21, je tzv. „přes“." + Environment.NewLine + 
                "Karty od 2 do 10 mají při počítání stejnou hodnotu, jaká je uvedena na kartě. Karty J, Q, K (spodek, královna a král) mají hodnotu 10. Eso (A) se počítá dle situace za 1 nebo za 11. Barvy karet nemají žádný význam." + Environment.NewLine + 
                "Pokud je hráč „přes“, vždy prohrává, a to i tehdy, pokud je „přes“ i krupiér. Pokud mají hráč i krupiér stejný počet bodů, končí hra nerozhodně a nikdo nevyhrává. Součet 21 je vždy označen jako BLACKJACK a pokud jej dosáhne hráč, automaticky vyhrává." + Environment.NewLine + 
                "Krupiér začíná hrát až hráč ukončí kolo (tlačítko SKONČIT). Na rozdíl od hráče je při volbě dalšího postupu výrazně omezen. Pokud je jeho součet menší než 17, musí vždy vzít další kartu, pokud je 17 a výše, nesmí brát další kartu, musí zůstat stát a ukončit tak hru." + Environment.NewLine + 
                "Není možné hrát DOUBLE, SPLIT nebo POJIŠTĚNÍ. Při každém rozdání jsou karty znovu zamíchány, hraje se s jedním balíčkem.");
        }

// TODO
        // resetuje skóre
        private void Button5_Click(object sender, EventArgs e)
        {
            win = 0;
            loss = 0;
            tie = 0;

            label3.Text = "Výhry:" + Convert.ToString(win);
            label4.Text = "Prohry:" + Convert.ToString(loss);
            label5.Text = "Remízy:" + Convert.ToString(tie);
        }
    }
}
