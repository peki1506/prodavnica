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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (email_txt.Text == "" || lozinka_txt.Text == "")
            {
                MessageBox.Show("Unesite email i lozinku");
                return;
            }
            else
            {
                try
                {
                    SqlConnection veza = Konekcija.Connect();
                    SqlCommand komanda = new SqlCommand("SELECT * FROM korisnici WHERE email=@username", veza);
                    komanda.Parameters.AddWithValue("@username", email_txt.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    int brojac = tabela.Rows.Count;
                    if (brojac == 1)
                    {
                        if (string.Compare(tabela.Rows[0]["lozinka"].ToString(), lozinka_txt.Text) == 0)
                        {
                            MessageBox.Show("Login Successful!");
                            Program.user_ime = tabela.Rows[0]["ime"].ToString();
                            Program.user_prezime = tabela.Rows[0]["prezime"].ToString();
                            this.Hide();
                            Prodavnica forma = new Prodavnica();
                            forma.Show();
                        }
                        else
                        {
                            MessageBox.Show("Neispravna lozinka");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nepostojeci email!");
                    }
                }
                catch(Exception greska)
                {
                    MessageBox.Show(greska.Message);
                }
            }
        }
    }
}
