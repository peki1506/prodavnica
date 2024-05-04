namespace prodavnica2
{
    partial class Prodavnica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.StvUKrp = new System.Windows.Forms.Button();
            this.lbl_user = new System.Windows.Forms.Label();
            this.cmb_vrsta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_brend = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_pol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Zavrsi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(213, 137);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(868, 382);
            this.dataGridView.TabIndex = 0;
            // 
            // StvUKrp
            // 
            this.StvUKrp.Location = new System.Drawing.Point(607, 537);
            this.StvUKrp.Name = "StvUKrp";
            this.StvUKrp.Size = new System.Drawing.Size(117, 59);
            this.StvUKrp.TabIndex = 1;
            this.StvUKrp.Text = "Stavi u korpu";
            this.StvUKrp.UseVisualStyleBackColor = true;
            this.StvUKrp.Click += new System.EventHandler(this.StvUKrp_Click);
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(1004, 54);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(44, 16);
            this.lbl_user.TabIndex = 2;
            this.lbl_user.Text = "label1";
            // 
            // cmb_vrsta
            // 
            this.cmb_vrsta.FormattingEnabled = true;
            this.cmb_vrsta.Location = new System.Drawing.Point(485, 54);
            this.cmb_vrsta.Name = "cmb_vrsta";
            this.cmb_vrsta.Size = new System.Drawing.Size(130, 24);
            this.cmb_vrsta.TabIndex = 3;
            this.cmb_vrsta.SelectedValueChanged += new System.EventHandler(this.cmb_vrsta_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vrsta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1004, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Korisnik:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Izaberite \r\nodgovarajuce kategorije";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(784, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Brend";
            // 
            // cmb_brend
            // 
            this.cmb_brend.FormattingEnabled = true;
            this.cmb_brend.Location = new System.Drawing.Point(787, 54);
            this.cmb_brend.Name = "cmb_brend";
            this.cmb_brend.Size = new System.Drawing.Size(130, 24);
            this.cmb_brend.TabIndex = 12;
            this.cmb_brend.SelectedValueChanged += new System.EventHandler(this.cmb_brend_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pol";
            // 
            // cmb_pol
            // 
            this.cmb_pol.FormattingEnabled = true;
            this.cmb_pol.Location = new System.Drawing.Point(213, 53);
            this.cmb_pol.Name = "cmb_pol";
            this.cmb_pol.Size = new System.Drawing.Size(121, 24);
            this.cmb_pol.TabIndex = 14;
            this.cmb_pol.SelectedValueChanged += new System.EventHandler(this.cmb_pol_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "PROIZVODI";
            // 
            // btn_Zavrsi
            // 
            this.btn_Zavrsi.Location = new System.Drawing.Point(1159, 537);
            this.btn_Zavrsi.Name = "btn_Zavrsi";
            this.btn_Zavrsi.Size = new System.Drawing.Size(130, 71);
            this.btn_Zavrsi.TabIndex = 17;
            this.btn_Zavrsi.Text = "Zavrsi kupovinu";
            this.btn_Zavrsi.UseVisualStyleBackColor = true;
            this.btn_Zavrsi.Click += new System.EventHandler(this.btn_Zavrsi_Click);
            // 
            // Prodavnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 620);
            this.Controls.Add(this.btn_Zavrsi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_pol);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_brend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_vrsta);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.StvUKrp);
            this.Controls.Add(this.dataGridView);
            this.Name = "Prodavnica";
            this.Text = "Prodavnica";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Prodavnica_FormClosed);
            this.Load += new System.EventHandler(this.Prodavnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button StvUKrp;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.ComboBox cmb_vrsta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_brend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_pol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Zavrsi;
    }
}

