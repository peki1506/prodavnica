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
            naredba.Append(" lager.cena, racun_stavke.id, racun_stavke.kolicina, klijenti.popust, racun.datum, ");
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
            dataGridView.Columns["id1"].Visible = false;
            txtBox.Text = dataGridView.Rows[0].Cells["ukupno"].Value.ToString();
            txtBox2.Text = dataGridView.Rows[0].Cells["datum"].Value.ToString();
            txtBox3.Text = dataGridView.Rows[0].Cells["popust"].Value.ToString();
        }
        private void btn_Plati_Click(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.Connect(); 
            string updateQuery = "UPDATE racun SET gotovo = 1 WHERE id = (SELECT MAX(ID) FROM racun)";

                using (veza)
                {
                    try
                    {
                        veza.Open();
                        using (SqlCommand command = new SqlCommand(updateQuery, veza))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Uspesno azuriranje
                            }
                            else
                            {
                                MessageBox.Show("Nema promena u bazi podataka.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška: " + ex.Message);
                    }
                }
                MessageBox.Show("Uspešno ste obavili kupovinu! Posetite nas ponovo!");
                Application.Exit();
        }

        private void btn_Obrisi_Click(object sender, EventArgs e)
        {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int selectedRowId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id1"].Value);
                    SqlConnection veza = Konekcija.Connect();
                    string deleteQuery = "DELETE FROM racun_stavke WHERE id = @id";
                    using (veza)
                    {
                        try
                        {
                            veza.Open();
                            using (SqlCommand command = new SqlCommand(deleteQuery, veza))
                            {
                                command.Parameters.AddWithValue("@id", selectedRowId);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                                    MessageBox.Show("Stavka je uspešno obrisana.");
                                    dataGridPopulate();
                                }
                                else
                                {
                                    MessageBox.Show("Nije pronađen red za brisanje.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Greška: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Molimo vas da izaberete red za brisanje.");
                }
        }
    }
}