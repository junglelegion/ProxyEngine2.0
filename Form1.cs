using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Root.Reports;
using System.Reflection;
using ProxyEngine.Cards;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ProxyEngine
{
    public partial class MainFrm : Form
    {
        private DeckList decklist = new DeckList();
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        private CardDatabase cdb = new CardDatabase();
        private Scryfall sf = new Scryfall();

        /*
         * 
         * Open and close the form
         * 
         */

        public MainFrm()
        {
            InitializeComponent();
            if (!Directory.Exists("json"))
            {
                Directory.CreateDirectory("json");
            }
            if (!Directory.Exists("scripts"))
            {
                Directory.CreateDirectory("scripts");
            }
            if (!Directory.Exists("decks"))
            {
                Directory.CreateDirectory("decks");
            }
            if (!Directory.Exists("art"))
            {
                Directory.CreateDirectory("art");
            }
            if (!Directory.Exists("art\\scryfall"))
            {
                Directory.CreateDirectory("art\\scryfall");
            }
            if (!Directory.Exists("art\\custom"))
            {
                Directory.CreateDirectory("art\\custom");
            }
            cardImage.SizeMode = PictureBoxSizeMode.StretchImage;

            // MTG JSON FILE PARSER
            jss.MaxJsonLength = Int32.MaxValue;
            //loadMTGJson();

            // Downloaded Cards Dict
            if (File.Exists("json\\downloaded.json"))
            {
                FileStream fs = new FileStream("json\\downloaded.json", FileMode.Open);
                cdb.downloadedCards = jss.Deserialize<Dictionary<string, sCard>>(new StreamReader(fs).ReadToEnd());
                fs.Close();
            }

        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllText("json\\downloaded.json", jss.Serialize(cdb.downloadedCards));
        }

        // On Click Event Functions

        #region Misc

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            string curItem = listBox1.SelectedItem.ToString();
            if (decklist.ContainsKey(curItem))
            {
                if (cardImage.Image != null) { cardImage.Image.Dispose(); }
                if (File.Exists(decklist[curItem].filePathFront))
                {
                    cardImage.Image = new Bitmap(decklist[curItem].filePathFront);
                }
                displayCardNameBox.Text = decklist[curItem].cardName;
                DisplayCardQtyBox.Value = decklist[curItem].cardQty;
            }
        }

        public void updateListBox()
        {
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            foreach (string name in decklist.Keys)
            {
                listBox1.Items.Add(name);
            }
            listBox1.EndUpdate();
        }

        public void toggleControls(bool onoff)
        {
            listBox1.Enabled = onoff;
            button1.Enabled = onoff;
            CommandBox.Enabled = onoff;
            menuStrip1.Enabled = onoff;
            displayCardNameBox.Enabled = onoff;
            DisplayCardQtyBox.Enabled = onoff;
            displayCardUpdate.Enabled = onoff;
            displayCardRemove.Enabled = onoff;
        }

        private async void loadMTGJson()
        {
            toggleControls(false);
            if (cdb.mtgJsonCards != null) { cdb.mtgJsonCards.Clear(); }
            printToScriptLog("Beginning to load card database...");
            if (File.Exists("json//AllCards-x.json"))
            {
                FileStream json = new FileStream("json//AllCards-x.json", FileMode.Open);
                StreamReader lx = new StreamReader(json);
                cdb.mtgJsonCards = jss.Deserialize<Dictionary<string, jCard>>(await lx.ReadToEndAsync());
                printToScriptLog("Loaded " + cdb.mtgJsonCards.Keys.Count + " cards into Memory!");
                json.Close();
            }
            toggleControls(true);
        }

        private void printToScriptLog(string msg)
        {
            scriptLogger.AppendText(msg.TrimEnd() + "\n");
            scriptLogger.ScrollToCaret();
        }

        private void executScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\scripts";
            openFileDialog1.Title = "Open Script...";
            openFileDialog1.Filter = "Script files (*.script)|*.script|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                printToScriptLog("Executing " + Path.GetFileName(openFileDialog1.FileName));
            }
        }

        private void displayCardUpdate_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            if (decklist.ContainsKey(curItem))
            {
                decklist[curItem].cardQty = (int)DisplayCardQtyBox.Value;
                decklist.Add(decklist[curItem].cardQty.ToString() + "x " + decklist[curItem].cardName + " [" + decklist[curItem].set + "]", decklist[curItem]);
                decklist.Remove(curItem);
                updateListBox();
            }
        }

        private string getImage(string cardName)
        {
            return "";
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printToScriptLog(sf.downloadImage("Thaumatic Compass").localLinkFront);
        }

        private void reloadIntoMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMTGJson();
        }

        #endregion

        #region Command Box

        private void AddOneFromCommandBox(object sender, EventArgs e)
        {
            string[] parameters = CommandBox.Text.Split();
            if (parameters.Length > 0)
            {
                addCard(CommandBox.Text, true);
                printToScriptLog("$" + sf.getPrice(CommandBox.Text).ToString());
                updateListBox();
                CommandBox.Text = "";
            }
        }

        private void CommandBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                AddOneFromCommandBox(sender, e);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Display Box

        private void displayCardRemove_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            if (decklist.ContainsKey(curItem))
            {
                decklist.Remove(curItem);
                updateListBox();
            }
        }

        private void saveDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Generation

        private void generateUsingBasicLandsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DeckList sendToGen = (DeckList)decklist.Clone();
            if (sendToGen == decklist)
            {
                printToScriptLog("HEY...");
                return;
            }
            List<Card> basics;
            foreach (Card c in sendToGen.Values.ToList())
            {
                if (typeof(Basics).GetEnumNames().Contains<string>(c.cardName))
                {
                    sendToGen.Remove(c.cardQty.ToString() + "x " + c.cardName);
                    basics = cdb.RandomBasics(c.cardName, Series.FULLART, c.cardQty);
                    foreach (Card basic in basics)
                    {
                        if (sendToGen.ContainsKey(basic.cardName))
                        {
                            sendToGen[basic.cardName].cardQty += basic.cardQty;
                        }
                        else
                        {
                            sendToGen.Add(basic.cardName, basic);
                        }

                    }
                }
            }
            Generate(sendToGen);
        }

        private void generateWithoutBasicLandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Generate(decklist);
        }

        private void Generate(DeckList d)
        {
            new pdfGenerator(d).begin();
        }

        // Generate a pdf using double sided processing...
        private void doubleSidedCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeckList sendToGen = (DeckList)decklist.Clone();
            if (sendToGen == decklist)
            {
                printToScriptLog("HEY...");
                return;
            }
            List<Card> basics;
            foreach (Card c in sendToGen.Values.ToList())
            {
                if (typeof(Basics).GetEnumNames().Contains<string>(c.cardName))
                {
                    sendToGen.Remove(c.cardQty.ToString() + "x " + c.cardName);
                    basics = cdb.RandomBasics(c.cardName, Series.FULLART, c.cardQty);
                    foreach (Card basic in basics)
                    {
                        if (sendToGen.ContainsKey(basic.cardName))
                        {
                            sendToGen[basic.cardName].cardQty += basic.cardQty;
                        }
                        else
                        {
                            sendToGen.Add(basic.cardName, basic);
                        }

                    }
                }
            }
            sendToGen.doublesided = true;
            Generate(sendToGen);
        }

        #endregion

        #region Analytics

        private void priceDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double thresh, amount;
            double total = 0;
            int num = 0;
            if (double.TryParse(toolStripTextBox1.Text, out thresh))
            {
                scriptLogger.Clear();
                foreach (Card c in decklist.Values)
                {
                    amount = sf.getPrice(c.cardName);
                    if (amount < thresh)
                    {
                        total += amount * c.cardQty;
                        num += c.cardQty;
                        printToScriptLog(c.cardQty.ToString() + "x " + c.cardName);
                    }
                }
                printToScriptLog("Total Price (" + num.ToString() + " cards): $" + total.ToString());
            }
        }

        #endregion

        #region Cards

        private void addCard(string currCard, bool singleton = false)
        {
            string[] parameters;
            int qty;
            Card c;

            if (currCard.StartsWith("#"))
            {
                return;
            }

            parameters = currCard.Split();
            try
            {
                if (singleton)
                {
                    qty = 1;
                }
                else
                {
                    if (parameters[0].EndsWith("x"))
                    {
                        qty = Int32.Parse(parameters[0].Substring(0, parameters[0].Length - 1));
                        currCard = currCard.Replace(qty.ToString() + "x ", "");
                    }
                    else
                    {
                        qty = Int32.Parse(parameters[0]);
                        currCard = currCard.Replace(qty.ToString() + " ", "");
                    }
                }
                if (parameters.Count() > 1 && parameters[1].ToLower() == "random")
                {
                    currCard = currCard.Substring(7, currCard.Length - 7);
                    var cards = Directory.GetFiles(currCard).TakeWhile((string s) => { return s.Contains("png"); }).ToArray();
                    var pool = new List<string>();
                    pool.AddRange(cards);
                    var rand = new Random();
                    var dict = new Dictionary<string, int>();
                    for (int i = 0; i < qty; i++)
                    {
                        do
                        {
                            if (pool.Count() == 0)
                            {
                                pool.AddRange(cards);
                            }
                            var index = pool[rand.Next(0, pool.Count() - 1)];
                            if (dict.ContainsKey(index) && dict.Count() == cards.Count())
                            {
                                dict[index]++;
                                break;
                            }
                            else if (!dict.ContainsKey(index))
                            {
                                dict.Add(index, 1);
                                pool.Remove(index);
                                break;
                            }
                        } while (dict.Count() < cards.Count());
                    }
                    foreach (string key in dict.Keys)
                    {
                        var str = Path.GetFileName(key);
                        decklist.Add(dict[key].ToString() + "x " + str, new Card(str, key, dict[key]));
                    }
                }
                else
                {
                    c = cdb.findCard(currCard, qty);
                    decklist.Add(qty + "x " + c.cardName + "[" + c.set.ToUpper() + "]", c);
                }
                // printToScriptLog("  " + currCard);
            }
            catch (Exception)
            {
                Helpers.Print("  Unable to find " + currCard + "!");
            }
        }

        #endregion

        #region Decks

        private void clearDeck(object sender, EventArgs e)
        {
            decklist.Clear();
            updateListBox();
        }

        private void addToDeck(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\decks";
            openFileDialog1.Title = "Open Deck...";
            openFileDialog1.Filter = "Deck files (*.txt or *.dec)|*.txt; *.dec|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            string currCard;
            string[] parameters;
            int qty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                printToScriptLog("Loading " + Path.GetFileName(openFileDialog1.FileName));
                Text = "Proxy Engine v2.0 (" + Path.GetFileName(openFileDialog1.FileName) + ")";
                StreamReader sr = new StreamReader(new FileStream(openFileDialog1.FileName, FileMode.Open));
                while (!sr.EndOfStream)
                {
                    currCard = sr.ReadLine();
                    printToScriptLog("  " + currCard);
                    parameters = currCard.Split();
                    try
                    {
                        qty = Int32.Parse(parameters[0]);
                        currCard = currCard.Replace(qty.ToString() + " ", "");
                        decklist.Add(qty + "x " + currCard, cdb.findCard(currCard, qty));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                sr.BaseStream.Close();
                updateListBox();
            }
        }

        private void loadDeck(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\decks";
            openFileDialog1.Title = "Open Deck...";
            openFileDialog1.Filter = "Deck files (*.txt or *.dec)|*.txt; *.dec|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            string currCard;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                decklist.Clear();
                printToScriptLog("Loading " + Path.GetFileName(openFileDialog1.FileName));
                Text = "Proxy Engine v2.0 (" + Path.GetFileName(openFileDialog1.FileName) + ")";
                StreamReader sr = new StreamReader(new FileStream(openFileDialog1.FileName, FileMode.Open));
                while (!sr.EndOfStream)
                {
                    currCard = sr.ReadLine();
                    addCard(currCard);
                }
                sr.BaseStream.Close();
                updateListBox();
            }
        }

        private void importSingletonDeck(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\decks";
            openFileDialog1.Title = "Open Deck...";
            openFileDialog1.Filter = "Deck files (*.txt or *.dec)|*.txt; *.dec|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            string currCard;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                decklist.Clear();
                printToScriptLog("Loading " + Path.GetFileName(openFileDialog1.FileName));
                Text = "Proxy Engine v2.0 (" + Path.GetFileName(openFileDialog1.FileName) + ")";
                StreamReader sr = new StreamReader(new FileStream(openFileDialog1.FileName, FileMode.Open));
                while (!sr.EndOfStream)
                {
                    currCard = sr.ReadLine();
                    addCard(currCard, true);
                }
                sr.BaseStream.Close();
                updateListBox();
            }
        }

        private void diffDecks(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\decks";
            openFileDialog1.Filter = "Deck files (*.txt or *.dec)|*.txt; *.dec|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            string currCard;
            string[] parameters;
            int qty;

            string deckfnA;
            string deckfnB;
            DeckList A = new DeckList();
            DeckList B = new DeckList();

            openFileDialog1.Title = "Choose original deck ...";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                deckfnA = openFileDialog1.FileName;
                openFileDialog1.Title = "Choose new / modified deck ...";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    deckfnB = openFileDialog1.FileName;

                    if (deckfnA != deckfnB)
                    {
                        printToScriptLog("Diffing " + Path.GetFileName(deckfnA) + " vs. " + Path.GetFileName(deckfnB));
                        // Loads Deck A first
                        StreamReader sr = new StreamReader(new FileStream(deckfnA, FileMode.Open));
                        while (!sr.EndOfStream)
                        {
                            currCard = sr.ReadLine();
                            printToScriptLog("  " + currCard);
                            parameters = currCard.Split();
                            try
                            {
                                qty = Int32.Parse(parameters[0]);
                                currCard = currCard.Replace(qty.ToString() + " ", "");
                                A.Add(qty + "x " + currCard, cdb.findCard(currCard, qty));
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        sr.BaseStream.Close();

                        // Loads Deck B First
                        sr = new StreamReader(new FileStream(deckfnB, FileMode.Open));
                        while (!sr.EndOfStream)
                        {
                            currCard = sr.ReadLine();
                            printToScriptLog("  " + currCard);
                            parameters = currCard.Split();
                            try
                            {
                                qty = Int32.Parse(parameters[0]);
                                currCard = currCard.Replace(qty.ToString() + " ", "");
                                B.Add(qty + "x " + currCard, cdb.findCard(currCard, qty));
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        sr.BaseStream.Close();

                        // Diff then update
                        A.Diff(B);
                        decklist.Merge(A);
                        updateListBox();
                    }
                    else
                    {
                        printToScriptLog("Unable to diff. Same file.");
                    }
                }
            }
        }

        private void subtractDecks(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory() + "\\decks";
            openFileDialog1.Filter = "Deck files (*.txt or *.dec)|*.txt; *.dec|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            string currCard;

            string deckfnA;
            string deckfnB;
            DeckList A = new DeckList();
            DeckList B = new DeckList();

            openFileDialog1.Title = "Choose positive deck...";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                deckfnA = openFileDialog1.FileName;
                openFileDialog1.Title = "Choose negative deck...";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    deckfnB = openFileDialog1.FileName;

                    if (deckfnA != deckfnB)
                    {
                        printToScriptLog("Diffing " + Path.GetFileName(deckfnA) + " vs. " + Path.GetFileName(deckfnB));
                        decklist.Clear();

                        // Loads Deck A first
                        StreamReader sr = new StreamReader(new FileStream(deckfnA, FileMode.Open));
                        while (!sr.EndOfStream)
                        {
                            currCard = sr.ReadLine();
                            addCard(currCard);
                        }
                        sr.BaseStream.Close();

                        A = new DeckList(decklist);
                        decklist.Clear();

                        // Loads Deck B First
                        sr = new StreamReader(new FileStream(deckfnB, FileMode.Open));
                        while (!sr.EndOfStream)
                        {
                            currCard = sr.ReadLine();
                            addCard(currCard);
                        }
                        sr.BaseStream.Close();
                        B = new DeckList(decklist);

                        // Diff then update
                        A.Subtract(B);
                        decklist = new DeckList(A);
                        updateListBox();
                    }
                    else
                    {
                        printToScriptLog("Unable to diff. Same file.");
                    }
                }
            }
        }

        #endregion

        private void mPCGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                mpcCardEditor.make(@"C:\Users\Nate\Desktop\Projects\Magic The Gathering\Alters\Basic Lands\Forest\forest1.png", dialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MassImport mi = new MassImport();
            if (mi.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in mi.Items)
                {
                    addCard(s.Trim(), true);
                    updateListBox();
                }
                mi.Close();
            }
        }
    }
}
