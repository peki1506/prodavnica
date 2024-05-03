﻿using System;
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
            string user = Program.user_ime + " " + Program.user_prezime;
            lbl_user.Text = user;
            cmb_polPopulate();
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
            StringBuilder naredba = new StringBuilder("SELECT naziv, pol, brend, velicina, boja, cena  FROM lager ");
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
            //dataGridView.Columns["id"].Visible = false;
        }
    }
}