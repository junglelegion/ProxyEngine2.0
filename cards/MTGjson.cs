using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyEngine.Cards
{
    public class jCard
    {
        public string layout;
        public string name;
        public List<string> names;
        public string manaCost;
        public string cmc;
        public List<string> colors;
        public string type;
        public List<string> types;
        public List<string> subtypes;
        public string text;
        public string power;
        public string toughness;
        public string imageName;
        public List<jRuling> rulings;
        public List<string> printings;
        public List<jLegality> legalities;
    }

    public class jRuling
    {
        public string date;
        public string text;
    }

    public class jLegality
    {
        public string format;
        public string legality;
    }
}
