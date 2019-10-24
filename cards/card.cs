using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ProxyEngine.Cards
{
    public class Card
    {
        public string cardName;
        public string filePathFront;
        public string filePathBack;
        public int cardQty;
        public bool twin;
        public string set;

        public Card(sCard sf, int num, bool t = false)
        {
            cardName = sf.name;
            filePathFront = sf.localLinkFront;
            filePathBack = sf.localLinkBack;
            cardQty = num;
            set = sf.set;
            twin = t;
        }

        public Card(string name, string path, int num)
        {
            cardName = name;
            filePathFront = path;
            cardQty = num;
            twin = false;
            set = "";
        }

        public Card(string name, string pathfront, string pathback, int num)
        {
            cardName = name;
            filePathFront = pathfront;
            filePathBack = pathback;
            cardQty = num;
            set = "";
            twin = true;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(set))
            {
                return string.Format("{0}x {1}", cardQty, cardName);
            }
            else
            {
                return string.Format("{0}x {1} [{2}]", cardQty, cardName, set.ToUpper());
            }            
        }

    }

    public class DeckList : Dictionary<string, Card> , ICloneable
    {

        public bool doublesided = false;

        public int getCardCount()
        {
            int sum = 0;
            foreach (Card c in Values)
            {
                sum += c.cardQty * (doublesided ? 1 : (c.twin ? 2 : 1));
            }
            return sum;
        }

        public DeckList()
        {

        }

        public DeckList(DeckList d)
        {
            foreach(string k in d.Keys)
            {
                Add(k, d[k]);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int getPageCount()
        {
            return (int) Math.Ceiling((decimal) getCardCount() / 6);
        }

        public int getCardsOnPage(int pageNum)
        {
            int cc = getCardCount();
            if (cc - ( pageNum * 6 ) > 0 && cc - (pageNum * 6) > 6)
            {
                return 6;
            }
            else if (cc - (pageNum * 6) > 0)
            {
                return cc - (pageNum * 6);
            }
            else
            {
                return 0;
            }
        }

        public void Diff(DeckList B)
        {
            Dictionary<string, Card> diff = new Dictionary<string, Card>();
            foreach (Card c in B.Values)
            {
                diff.Add(c.cardName, c);
            }
            foreach (Card c in Values)
            {
                if(diff.ContainsKey(c.cardName))
                {
                    if(diff[c.cardName].cardQty-c.cardQty > 0)
                    {
                        diff[c.cardName].cardQty = Math.Abs(diff[c.cardName].cardQty - c.cardQty);
                    }
                    else
                    {
                        diff.Remove(c.cardName); 
                    }
                }
            }
            Clear();
            foreach (Card c in diff.Values)
            {
                Add(c.cardQty.ToString() + "x " + c.cardName, c);
            }
        }

        public void Merge(DeckList B)
        {
            Dictionary<string, Card> merged = new Dictionary<string, Card>();
            foreach (Card c in B.Values)
            {
                merged.Add(c.cardName, c);
            }
            foreach (Card c in Values)
            {
                if (merged.ContainsKey(c.cardName))
                {
                    merged[c.cardName].cardQty = Math.Abs(merged[c.cardName].cardQty + c.cardQty);
                }
                else
                {
                    merged.Add(c.cardName, c);
                }
            }
            Clear();
            foreach (Card c in merged.Values)
            {
                Add(c.cardQty.ToString() + "x " + c.cardName, c);
            }
        }

        public void Subtract(DeckList B)
        {
            Dictionary<string, Card> diff = new Dictionary<string, Card>();
            foreach (Card c in Values)
            {
                diff.Add(c.cardName, c);
            }
            foreach (Card c in B.Values)
            {
                if (diff.ContainsKey(c.cardName))
                {
                    if (diff[c.cardName].cardQty - c.cardQty > 0)
                    {
                        diff[c.cardName].cardQty = diff[c.cardName].cardQty - c.cardQty;
                    }
                    else
                    {
                        diff.Remove(c.cardName);
                    }
                }
            }
            Clear();
            foreach (Card c in diff.Values)
            {
                Add(c.cardQty.ToString() + "x " + c.cardName, c);
            }
        }
    }

    public enum Basics
    {
        Island,
        Swamp,
        Mountain,
        Forest,
        Plains
    }

    public enum Series
    {
        ICELEA,
        FULLART,
        UNSTABLE,
        SET
    }

    public class CardDatabase
    {
        public Dictionary<string, sCard> downloadedCards = new Dictionary<string, sCard>();
        public Dictionary<string, jCard> mtgJsonCards = new Dictionary<string, jCard>();

        private Scryfall sf = new Scryfall();

        public List<Card> RandomBasics(string type, Series ser, int qty)
        {
            switch (type)
            {
                case "Mountain":
                    return RandomBasics(Basics.Mountain, ser, qty);
                case "Plains":
                    return RandomBasics(Basics.Plains, ser, qty);
                case "Forest":
                    return RandomBasics(Basics.Forest, ser, qty);
                case "Swamp":
                    return RandomBasics(Basics.Swamp, ser, qty);
                case "Island":
                    return RandomBasics(Basics.Island, ser, qty);
            }
            return new List<Card>();
        }

        public List<Card> RandomBasics(Basics type, Series ser, int qty)
        {
            Dictionary<string, Card> output = new Dictionary<string, Card>();
            string BASIC_TYPE = "";
            string SERIES_TYPE = "";
            int randomchoices = 0;
            string path;
            string sel;
            int choice;

            int count = 0;

            switch (type)
            {
                case Basics.Forest:
                    BASIC_TYPE = "FOREST";
                    break;
                case Basics.Mountain:
                    BASIC_TYPE = "MOUNTAIN";
                    break;
                case Basics.Plains:
                    BASIC_TYPE = "PLAINS";
                    break;
                case Basics.Island:
                    BASIC_TYPE = "ISLAND";
                    break;
                case Basics.Swamp:
                    BASIC_TYPE = "SWAMP";
                    break;
            }

            switch (ser)
            {
                case Series.ICELEA:
                    SERIES_TYPE = "ICELEA";
                    randomchoices = 10;
                    break;
                case Series.FULLART:
                    SERIES_TYPE = "FULLART";
                    randomchoices = 11;
                    break;
                case Series.UNSTABLE:
                    SERIES_TYPE = "UNSTABLE";
                    randomchoices = 1;
                    break;
                case Series.SET:
                    SERIES_TYPE = "SET";
                    randomchoices = 0;
                    break;
            }

            path = "art\\basics\\" + SERIES_TYPE + "\\" + BASIC_TYPE + "\\";

            Random r = new Random();
            for (int i = 0; i < qty; i++)
            {
                choice = r.Next(0, randomchoices);
                sel = path + choice.ToString() + ".png";
                if (output.ContainsKey(BASIC_TYPE + "_" + choice.ToString()) && count >= randomchoices)
                {
                    output[BASIC_TYPE + "_" + choice.ToString()].cardQty++;
                }
                else if (!output.ContainsKey(BASIC_TYPE + "_" + choice.ToString()) || count >= randomchoices)
                {
                    output.Add(BASIC_TYPE + "_" + choice.ToString(), new Card(BASIC_TYPE + "_" + choice.ToString(), sel, 1));
                    count++;
                }
                else
                {
                    qty++;
                }
            }

            return output.Values.ToList();
        }

        public Card findCard(string name, int howmany)
        {
            Card output;
            sCard download;
            string sub;

            WebClient wb = new WebClient();

            // is this a debug card?
            if (name.ToLower() == "reference")
            {
                return new Card(name, "\\art\\refcard.png", "\\art\\refcard.png", howmany);
            }

            // custom art
            if (name.ToLower().Contains("custom\\"))
            {
                sub = name.ToLower();
                Helpers.Print("\\art\\" + sub);
                return new Card(name, "\\art\\" + sub, howmany);
            }

            // download custom art
            if (name.ToLower().Contains("http") && name.ToLower().Contains("png"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\art\\downloads\\");
                wb.DownloadFile(name, Directory.GetCurrentDirectory() + "\\art\\downloads\\" + name.GetHashCode() + ".png");
                return new Card(name, Directory.GetCurrentDirectory() + "\\art\\downloads\\" + name.GetHashCode() + ".png", howmany);
            }

            // Is it already downloaded?
            if (downloadedCards.ContainsKey(name))
            {
                if (downloadedCards[name].card_faces != null && File.Exists(downloadedCards[name].localLinkFront) && File.Exists(downloadedCards[name].localLinkBack))
                {
                    output = new Card(downloadedCards[name].name, downloadedCards[name].localLinkFront, downloadedCards[name].localLinkBack, howmany);
                    return output;
                }
                else if (File.Exists(downloadedCards[name].localLinkFront))
                {
                    output = new Card(downloadedCards[name].name, downloadedCards[name].localLinkFront, howmany);
                    return output;
                }
            }
            // Do we already have an exact match from MTGJson?

            // Just Search...
            download = sf.downloadImage(name);
            if (download.card_faces != null)
            {
                output = new Card(download, howmany, true);
            }
            else
            {
                output = new Card(download, howmany);
            }

            if (downloadedCards.ContainsKey(name))
            {
                downloadedCards.Remove(name);
            }
            downloadedCards.Add(name, download);

            return output;

        }

    }
}
