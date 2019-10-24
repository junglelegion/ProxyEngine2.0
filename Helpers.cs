using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyEngine
{
    public abstract class Helpers
    {
        public static void Print(string text)
        {
            if (Application.OpenForms.Count > 0)
            {
                RichTextBox t = Application.OpenForms["MainFrm"].Controls["scriptLogger"] as RichTextBox;
                t.AppendText(text.TrimEnd() + "\n");
            }
        }
    }
}
