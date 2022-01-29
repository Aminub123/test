using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test13
{
    public partial class acceuil : Form
    {
        Form1 f;
        public acceuil()
        {
            InitializeComponent();
        }

        private void acceuil_FormClosing(object sender, FormClosingEventArgs e)
        {
            f = new Form1();
            this.Hide();
            f.Show();
        }

        private void acceuil_Load(object sender, EventArgs e)
        {

        }

        private void controlelivre1_Load(object sender, EventArgs e)
        {

        }
    }
}
