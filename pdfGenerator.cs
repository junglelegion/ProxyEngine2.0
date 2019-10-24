using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Reports;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ProxyEngine.Cards;

// Creation date: 6/29/2018
// Checked: 6/29/2018
// Author: Nate Christianson
// Version: 1.00
// Copyright(c) 2018 Nate Christianson

//    Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

//    The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace ProxyEngine
{

    public class pdfGenerator
    {
        // Public Parameters
        public DeckList decklist;

        // Private Parameters
        private Thread t;
        
        // Constructors
        public pdfGenerator(DeckList deck)
        {
            decklist = deck;
            t = new Thread(() => { begin(); });
        }

        // Public Methods
        public void begin()
        {
            DialogResult result;
            string message;
            string caption;
            MessageBoxButtons buttons;
            SaveFileDialog ss = new SaveFileDialog();
            ss.Filter = "PDF files(*.pdf) | *.pdf | All files(*.*) | *.*";

            if (decklist.getCardCount() == 0)
            {
                message = "Your deck contains 0 cards. I cannot generate a pdf with 0 cards...";
                caption = "Error Detected in Input";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else if (decklist.getCardCount() % 6 != 0)
            {
                message = "There are pages with empty space. Consider adding " + (6 - decklist.getCardCount() % 6) + " more cards.\nPress Cancel to abort.\nPress OK to continue.";
                caption = "Error Detected in Input";
                buttons = MessageBoxButtons.OKCancel;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (ss.ShowDialog() == DialogResult.OK)
                    {
                        pdfOutput doc = new pdfOutput();
                        doc.decklist = decklist;
                        doc.Run();
                        RT.ViewPDF(doc, ss.FileName);
                    }
                }
            }
            else
            {
                if (ss.ShowDialog() == DialogResult.OK)
                {
                    pdfOutput doc = new pdfOutput();
                    doc.decklist = decklist;
                    doc.Run();
                    RT.ViewPDF(doc, ss.FileName);
                }
            }
        }
    }

    public class pdfOutput : Report
    {
        public DeckList decklist;
        public MemoryStream overcard = loadImageFile("\\art\\overcard.png");

        public async void Run(DeckList d)
        {
            decklist = d;
            await Task.Factory.StartNew(Run);
        }

        public void Run()
        {
            MemoryStream stream;
            MemoryStream refbg = loadImageFile("\\art\\reference.png");

            FontDef fd = new FontDef(this, FontDef.StandardFont.Courier);
            FontProp fp = new FontPropMM(fd, 2.1);
            BrushProp bp = new BrushProp(this, Color.LightGray);
            PenProp pp = new PenProp(this, 0.2, Color.FromArgb(235, 235, 235));
            PenProp pp_Black = new PenProp(this, 0.2, Color.Black);

            bool deckdbl = decklist.doublesided;

            List<Card> cards = decklist.Values.ToList();
            List<string> cardArts = new List<string>();
            List<string> cardArtsBack = new List<string>();

            foreach (Card c in cards)
            {
                for (int i = 0; i < c.cardQty; i++)
                {
                    cardArts.Add(c.filePathFront);
                    // if the card has a flip but we're not doing double sided
                    if (c.twin && !deckdbl)
                    {
                        cardArts.Add(c.filePathBack);
                    }
                    // if the card has a flip and we're doing double sided
                    else if (c.twin && deckdbl)
                    {
                        cardArtsBack.Add(c.filePathBack);
                    }
                    // if the card doesn't have a flip and we're doing double sided
                    else if (!c.twin && deckdbl)
                    {
                        cardArtsBack.Add("\\art\\pback.png");
                    }
                }
            }

            int cardid = 0;
            int cardidback = 0;

            for (int pageNum = 0; pageNum < decklist.getPageCount(); pageNum++)
            {
                // Make a page
                new Page(this);
                page_Cur.rWidthMM = 215.9;
                page_Cur.rHeightMM = 279.4;
                page_Cur.AddMM(0, 279.4, new RepImageMM(refbg, 215.9, 279.4));
                page_Cur.AddAlignedMM(215.9 / 2, RepObj.rAlignCenter, 27.5, RepObj.rAlignTop, new RepString(fp, "Print on 12pt Matte -- No Scaling -- Full Color -- One Copy"));
                page_Cur.AddAlignedMM(215.9 / 2, RepObj.rAlignCenter, 22.5, RepObj.rAlignTop, new RepString(fp, "Print Coated 3 -- Maximum Printer Density -- 100% Color"));

                // Layout the Cards
                for (int cardPos = 0; cardPos < decklist.getCardsOnPage(pageNum); cardPos++)
                {
                    if (cardArts[cardid] == null)
                    {
                        cardid++;
                    }
                    stream = loadImageFile(cardArts[cardid]);
                    if (stream != null)
                    {
                        AddCardToPage(stream, Center(cardPos));
                    }
                    cardid++;
                }

                if (deckdbl)
                {

                    page_Cur.AddAlignedMM(215.9 / 2, RepObj.rAlignCenter, 279.4 - 27.5, RepObj.rAlignTop, new RepString(fp, "Double sided -- Flipped on Short Edge"));

                    // Make a page
                    new Page(this);
                    page_Cur.rWidthMM = 215.9;
                    page_Cur.rHeightMM = 279.4;
                    page_Cur.AddMM(0, 279.4, new RepImageMM(refbg, 215.9, 279.4));
                    page_Cur.AddAlignedMM(215.9 / 2, RepObj.rAlignCenter, 27.5, RepObj.rAlignTop, new RepString(fp, "Print on 12pt Matte -- No Scaling -- Full Color -- One Copy"));

                    // Layout the Cards
                    for (int cardPos = 0; cardPos < decklist.getCardsOnPage(pageNum); cardPos++)
                    {
                        stream = loadImageFile(cardArtsBack[cardidback]);
                        AddCardToPage(stream, CenterBackA(cardPos), 3.75);
                        cardidback++;
                    }

                    page_Cur.AddAlignedMM(215.9 / 2, RepObj.rAlignCenter, 279.4 - 27.5, RepObj.rAlignTop, new RepString(fp, "Double sided -- Flipped on Short Edge"));

                }
            }

        }

        private void AddCardToPage(MemoryStream s, double X, double Y, int rot = 90)
        {
            StaticContainer sc = new StaticContainer(64, 89);
            BrushProp bp = new BrushProp(this, Color.FromArgb(21, 20, 22));
            BrushProp bW = new BrushProp(this, Color.FromArgb(255, 255, 255));
            // Full Cover
            //page_Cur.AddAlignedMM(X, RepObj.rAlignCenter, Y, RepObj.rAlignCenter, new RepRectMM(bp, 89, 64));
            // Image
            page_Cur.AddMM(X, Y, sc);
            sc.RotateTransform(rot);
            Bitmap m = new Bitmap(Image.FromStream(s));
            Color v = m.GetPixel(20, 20);
            sc.AddAlignedMM(0, RepObj.rAlignCenter, 0, RepObj.rAlignCenter, new RepImageMM(s, 63, 88));
            if (v.R < 40 && v.G < 40 && v.B < 40)
            {
                // Cover Corners
                // Left
                page_Cur.AddAlignedMM(X - 44.5, RepObj.rAlignLeft, Y, RepObj.rAlignCenter, new RepRectMM(bp, 1.5, 64));
                // Right
                page_Cur.AddAlignedMM(X + 44.5, RepObj.rAlignRight, Y, RepObj.rAlignCenter, new RepRectMM(bp, 1.5, 64));
                // Top
                page_Cur.AddAlignedMM(X, RepObj.rAlignCenter, Y - 32, RepObj.rAlignTop, new RepRectMM(bp, 89, 1.5));
                // Bottom
                page_Cur.AddAlignedMM(X, RepObj.rAlignCenter, Y + 32, RepObj.rAlignBottom, new RepRectMM(bp, 89, 1.5));
            }
        }

        private void AddCardToPage(MemoryStream s, Tuple<double, double> coords, bool bg = true)
        {
            AddCardToPage(s, coords.Item1, coords.Item2);
        }

        private void AddCardToPage(MemoryStream s, Tuple<double, double> coords, int rot)
        {
            AddCardToPage(s, coords.Item1, coords.Item2, rot);
        }

        private void AddCardToPage(MemoryStream s, Tuple<double, double> coords, double offsetY)
        {
            AddCardToPage(s, coords.Item1, coords.Item2 + offsetY);
        }

        private static MemoryStream loadImageFile(string fn)
        {
            MemoryStream stream = new MemoryStream();
            Image cardPicture;
            if (File.Exists(fn))
            {
                cardPicture = Image.FromFile(fn);
            }
            else if (File.Exists(Directory.GetCurrentDirectory() + "\\" + fn))
            {
                cardPicture = Image.FromFile(Directory.GetCurrentDirectory() + "\\" + fn);
            }
            else
            {
                return null;
            }
            cardPicture.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return stream;
        }

        private Tuple<double, double> Center(int position)
        {
            switch (position)
            {
                case 0:
                    return new Tuple<double, double>(154, 70);
                case 1:
                    return new Tuple<double, double>(63, 70);
                case 2:
                    return new Tuple<double, double>(154, 138);
                case 3:
                    return new Tuple<double, double>(63, 138);
                case 4:
                    return new Tuple<double, double>(154, 206);
                case 5:
                    return new Tuple<double, double>(63, 206);
                default:
                    return new Tuple<double, double>(0, 0);
            }
        }

        private Tuple<double, double> CenterBackA(int position)
        {
            switch (position)
            {
                case 4:
                    return new Tuple<double, double>(154, 70);
                case 5:
                    return new Tuple<double, double>(63, 70);
                case 2:
                    return new Tuple<double, double>(154, 138);
                case 3:
                    return new Tuple<double, double>(63, 138);
                case 0:
                    return new Tuple<double, double>(154, 206);
                case 1:
                    return new Tuple<double, double>(63, 206);
                default:
                    return new Tuple<double, double>(0, 0);
            }
        }

        private Tuple<double, double> CenterBackB(int position)
        {
            switch (position)
            {
                case 1:
                    return new Tuple<double, double>(154, 70);
                case 0:
                    return new Tuple<double, double>(63, 70);
                case 3:
                    return new Tuple<double, double>(154, 138);
                case 2:
                    return new Tuple<double, double>(63, 138);
                case 5:
                    return new Tuple<double, double>(154, 206);
                case 4:
                    return new Tuple<double, double>(63, 206);
                default:
                    return new Tuple<double, double>(0, 0);
            }
        }
    }
}