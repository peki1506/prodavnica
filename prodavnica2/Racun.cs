using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            string user = Program.user_ime + " " + Program.user_prezime;
            lbl_user.Text = user;
            dataGridPopulate();
        }
        private void dataGridPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder(" SELECT racun.id, artikli.naziv, tipovi.boja, tipovi.velicina, tipovi.brend, "); 
            naredba.Append(" lager.cena, racun_stavke.kolicina, klijenti.popust, racun.datum, ");
            naredba.Append(" (SELECT SUM(cena)*(100-klijenti.popust)/100 FROM racun_stavke where id_racuna = (SELECT MAX(id) FROM racun)) AS ukupno ");
            naredba.Append(" FROM racun_stavke ");
            naredba.Append(" JOIN artikli ON racun_stavke.id_artikla = artikli.id JOIN tipovi ON tipovi.id = artikli.id_tipa ");
            naredba.Append(" JOIN lager ON lager.id_artikla = artikli.id JOIN racun ON racun.id = racun_stavke.id_racuna ");
            naredba.Append(" JOIN klijenti on klijenti.id = racun.id_klijenta ");
            naredba.Append(" WHERE racun.id = (SELECT MAX(id) FROM racun) ");

            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            DataTable dt_grid = new DataTable();
            adapter.Fill(dt_grid);
            dataGridView.DataSource = dt_grid;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Columns["id"].Visible = false;
            dataGridView.Columns["ukupno"].Visible = false;
            dataGridView.Columns["popust"].Visible = false;
            dataGridView.Columns["datum"].Visible = false;
            txtBox.Text = dataGridView.Rows[0].Cells["ukupno"].Value.ToString();
            txtBox2.Text = dataGridView.Rows[0].Cells["datum"].Value.ToString();
            txtBox3.Text = dataGridView.Rows[0].Cells["popust"].Value.ToString();
        }
        private void btn_Plati_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uspesno ste obavili kupovinu!" +
                            "Posetite nas ponovo! ");
            Application.Exit();
        }
    }
}
