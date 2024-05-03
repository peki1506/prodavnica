using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prodavnica2
{
    public partial class Prodavnica : Form
    {
        public Prodavnica()
        {
            InitializeComponent();
        }

        private void Prodavnica_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Prodavnica_Load(object sender, EventArgs e)
        {
            string user = Program.user_ime + " " + Program.user_prezime;
            lbl_user.Text = user;
        }
    }
}
