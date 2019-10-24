using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyEngine
{
    public partial class MassImport : Form
    {
        public MassImport()
        {
            InitializeComponent();
        }

        public string[] Items
        {
            get
            {
                return entry.Lines;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
