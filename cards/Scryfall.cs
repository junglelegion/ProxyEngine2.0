using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

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

namespace ProxyEngine.Cards
{
    public class Scryfall
    {
        private WebClient wb = new WebClient();
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        public string makeSearch()
        {
            return wb.DownloadString("https://api.scryfall.com/cards/named?fuzzy=aust+com&version=png");
        }

        public sCard downloadImage(string cardname)
        {
            string query, set;
            if (cardname.Contains(":"))
            {
                // We're looking for a specific art...
                set = cardname.Split(':')[1].Trim();
                cardname = cardname.Split(':')[0].Trim().Replace(" ", "+");
                query = "https://api.scryfall.com/cards/named?fuzzy=" + cardname + "&set=" + set;
            }
            else
            {
                cardname = cardname.Replace(" ", "+");
                query = "https://api.scryfall.com/cards/named?fuzzy=" + cardname;
            }
            
            string resp = wb.DownloadString(query);
            sCard card = jss.Deserialize<sCard>(resp);
            if (card.status == 404)
            {
                throw new ArgumentException();
            }
            if (card.card_faces != null && card.image_uris == null)
            {
                wb.DownloadFile(card.card_faces[0].image_uris.png, "art\\scryfall\\" + card.id + "-front.png");
                card.localLinkFront = "art\\scryfall\\" + card.id + "-front.png";
                wb.DownloadFile(card.card_faces[1].image_uris.png, "art\\scryfall\\" + card.id + "-back.png");
                card.localLinkBack = "art\\scryfall\\" + card.id + "-back.png";
            }
            else
            {
                wb.DownloadFile(card.image_uris.png, "art\\scryfall\\" + card.id + ".png");
                card.localLinkFront = "art\\scryfall\\" + card.id + ".png";
            }
            
            return card;
        }

        public double getPrice(string cardname)
        {
            try
            {
                string resp = wb.DownloadString("https://api.scryfall.com/cards/named?fuzzy=" + cardname);
                sCard card = jss.Deserialize<sCard>(resp);
                return card.usd == 0 ? 100 : card.usd;
            }
            catch // Probably a 404 error
            {
                return 100;
            }            
        }

    }

    public class sCard
    {
        public string id;
        public string name;
        public sImageURIs image_uris;
        public List<sCardFace> card_faces;
        public string localLinkFront;
        public string localLinkBack;
        public double usd;
        public int status;
        public string set;
    }

    public class sCardFace
    {
        public string name;
        public sImageURIs image_uris;
    }

    public class sImageURIs
    {
        public string small;
        public string normal;
        public string large;
        public string png;
    }
}
