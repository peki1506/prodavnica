using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            SqlConnection veza = Konekcija.Connect();
            veza.Open();
            string user = Program.user_ime + " " + Program.user_prezime;
            lbl_user.Text = user;
            cmb_polPopulate();
            popuniRacun(GetCurrentRacunID(veza) + 1, DateTime.Now, getKlijentID(veza));
            MessageBox.Show("Pazite prilikom kupovine! " +
                "Nije moguce obrisati artikal iz korpe! ");
            //cmb_vrstaPopulate();
            //cmb_bojaPopulate();
            //cmb_brendPopulate();
        }
        private void cmb_polPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT pol FROM  tipovi", veza);
            DataTable dt_pol = new DataTable();
            adapter.Fill(dt_pol);
            cmb_pol.DataSource = dt_pol;
            cmb_pol.ValueMember = "pol";
            cmb_pol.DisplayMember = "pol";
            cmb_pol.SelectedIndex = -1;
        }
        private void cmb_pol_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_pol.IsHandleCreated && cmb_pol.Focused)
            {
                cmb_vrstaPopulate();
            }
        }
        private void cmb_vrstaPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("SELECT DISTINCT naziv FROM  artikli ");
            naredba.Append(" JOIN tipovi on id_tipa = tipovi.id ");
            naredba.Append(" WHERE pol = @comboboxVrednost");
            //textBox1.Text = cmb_pol.SelectedValue.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            adapter.SelectCommand.Parameters.AddWithValue("@comboboxVrednost", cmb_pol.SelectedValue.ToString());
            DataTable dt_vrsta = new DataTable();
            adapter.Fill(dt_vrsta);
            cmb_vrsta.DataSource = dt_vrsta;
            cmb_vrsta.ValueMember = "naziv";
            cmb_vrsta.DisplayMember = "naziv";
            cmb_vrsta.SelectedIndex = -1;
        }
        private void cmb_vrsta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_vrsta.IsHandleCreated && cmb_vrsta.Focused)
            {
                cmb_brendPopulate();
            }
        }
        private void cmb_brendPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("SELECT DISTINCT brend FROM  artikli ");
            naredba.Append(" JOIN tipovi on id_tipa = tipovi.id ");
            naredba.Append(" WHERE naziv = @comboboxVrednost");
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            adapter.SelectCommand.Parameters.AddWithValue("@comboboxVrednost", cmb_vrsta.SelectedValue.ToString());
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT brend FROM  tipovi", veza);
            //textBox1.Text = cmb_pol.SelectedValue.ToString();
            DataTable dt_brend = new DataTable();
            adapter.Fill(dt_brend);
            cmb_brend.DataSource = dt_brend;
            cmb_brend.ValueMember = "brend";
            cmb_brend.DisplayMember = "brend";
            cmb_brend.SelectedIndex = -1;
        }
        private void cmb_brend_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_brend.IsHandleCreated && cmb_brend.Focused)
            {
                dataGridPopulate();
            }
        }
        private void dataGridPopulate()
        {
            SqlConnection veza = Konekcija.Connect();
            StringBuilder naredba = new StringBuilder("SELECT artikli.id, naziv, pol, brend, velicina, boja, cena, kolicina  FROM lager ");
            naredba.Append(" JOIN artikli on id_artikla = artikli.id ");
            naredba.Append(" JOIN tipovi on artikli.id_tipa = tipovi.id ");
            naredba.Append(" WHERE pol = @comboboxVrednost1 ");
            naredba.Append(" AND naziv = @comboboxVrednost2 ");
            naredba.Append(" AND brend = @comboboxVrednost3");
            SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
            adapter.SelectCommand.Parameters.AddWithValue("@comboboxVrednost1", cmb_pol.SelectedValue.ToString());
            adapter.SelectCommand.Parameters.AddWithValue("@comboboxVrednost2", cmb_vrsta.SelectedValue.ToString());
            adapter.SelectCommand.Parameters.AddWithValue("@comboboxVrednost3", cmb_brend.SelectedValue.ToString());
            DataTable dt_grid = new DataTable();
            adapter.Fill(dt_grid);
            dataGridView.DataSource = dt_grid;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Columns["kolicina"].Visible = false;
            dataGridView.Columns["id"].Visible = false;
        }
        //private static SqlConnection veza = Konekcija.Connect();
        //private static int br_racuna = GetCurrentRacunID(veza) + 1;
        private int GetCurrentRacunID(SqlConnection veza)
        {
            //veza.Open();
            SqlCommand command = new SqlCommand("SELECT MAX(id) FROM racun", veza);
            object result = command.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                return Convert.ToInt32(result);
            }
            else
            {
                // Ako nema postojećih računa, vratimo 0
                return 0;
            }
            //veza.Close();
        }
        private int getKlijentID(SqlConnection veza)
        {
            int klijentID = 1;
            /*string[] labela = lbl_user.Text.Split(' ');
            string ime = labela[0];
            string prezime = labela[1];*/
            string query = "SELECT id FROM klijenti WHERE ime = @ime AND prezime = @prezime ";
            using (SqlCommand command = new SqlCommand(query, veza))
            {
                command.Parameters.AddWithValue("@ime", Program.user_ime);
                command.Parameters.AddWithValue("@prezime", Program.user_prezime);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                  klijentID = Convert.ToInt32(reader["id"]);
                }
                reader.Close();
            }
            return klijentID;
        }
        private void popuniRacun(int racunID,  DateTime datum, int klijentID)
        {
            string query = "INSERT INTO racun (id, datum, id_klijenta) VALUES (@RacunID, @Datum, @KlijentID)";
            SqlConnection veza = Konekcija.Connect();
            veza.Open();
            // Kreiranje SqlCommand objekta sa SQL naredbom i konekcijom
            using (SqlCommand command = new SqlCommand(query, veza))
            {
                // Dodavanje parametara za vrednosti ID-a računa i datuma
                command.Parameters.AddWithValue("@RacunID", racunID);
                command.Parameters.AddWithValue("@Datum", DateTime.Now);
                command.Parameters.AddWithValue("@KlijentID", klijentID);
                // Izvršavanje SQL naredbe za umetanje
                command.ExecuteNonQuery();
            }
            veza.Close();
        }
        private void StvUKrp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection veza = Konekcija.Connect();
                veza.Open();
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                    int artikalID = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    int kolicina = Convert.ToInt32(selectedRow.Cells["kolicina"].Value);

                    // Dodavanje u tabelu racun_stavke
                    StringBuilder naredba = new StringBuilder("INSERT INTO racun_stavke (kolicina, cena, id_magacina, id_artikla, id_racuna) ");
                    naredba.Append(" VALUES (@Kolicina, @Cena, @MagacinID, @ArtikalID, @RacunID)");
                    SqlDataAdapter adapter = new SqlDataAdapter(naredba.ToString(), veza);
                    adapter.SelectCommand.Parameters.AddWithValue("@Kolicina", 1);
                    adapter.SelectCommand.Parameters.AddWithValue("@Cena", Convert.ToDouble(selectedRow.Cells["cena"].Value));
                    adapter.SelectCommand.Parameters.AddWithValue("@MagacinID", 1);
                    adapter.SelectCommand.Parameters.AddWithValue("@ArtikalID", artikalID);
                    //popuniRacun(GetCurrentRacunID(veza)+1, DateTime.Now);
                    adapter.SelectCommand.Parameters.AddWithValue("@RacunID", GetCurrentRacunID(veza)); 
                    adapter.SelectCommand.ExecuteNonQuery();

                    // Ažuriranje vrednosti u tabeli lager
                    StringBuilder naredba3 = new StringBuilder("UPDATE lager SET kolicina = @Kolicina WHERE id_artikla = @ArtikalID");
                    SqlDataAdapter adapter3 = new SqlDataAdapter(naredba3.ToString(), veza);
                    adapter3.SelectCommand.Parameters.AddWithValue("@Kolicina", kolicina - 1);
                    adapter3.SelectCommand.Parameters.AddWithValue("@ArtikalID", artikalID);
                    adapter3.SelectCommand.ExecuteNonQuery();

                    // Osvežavanje DataGridView
                    dataGridPopulate();
                    MessageBox.Show("Stavka je uspesno dodata u korpu. ");
                    /*DataTable dt_grid = new DataTable();
                    adapter2.Fill(dt_grid);
                    dataGridView.DataSource = dt_grid;
                    dataGridView.AllowUserToAddRows = false;
                    //dataGridView.Columns["kolicina"].Visible = false;
                    dataGridView.Columns["id"].Visible = false;*/
                }
                else
                {
                    MessageBox.Show("Nije izabran red za dodavanje.");
                }
                veza.Close();
            }
            catch(Exception greska)
            {
                MessageBox.Show("Greska pri dodavanju stavke u korpu ", greska.Message);
            }
        }
        private void btn_Zavrsi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Racun forma = new Racun();
            forma.Show();
        }
    }
}