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
    public partial class Racun : Form
    {
        public Racun()
        {
            InitializeComponent();
        }

        private void Racun_Load(object sender, EventArgs e)
        {

        }

        private void btn_Plati_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uspesno ste obavili kupovinu!" +
                            "Posetite nas ponovo! ");
        }
    }
}
