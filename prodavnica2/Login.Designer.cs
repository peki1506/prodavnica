namespace prodavnica2
{
    partial class Login
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
            this.email_txt = new System.Windows.Forms.TextBox();
            this.lozinka_txt = new System.Windows.Forms.TextBox();
            this.Email_lbl = new System.Windows.Forms.Label();
            this.loznika_lbl = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(308, 159);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(158, 22);
            this.email_txt.TabIndex = 0;
            // 
            // lozinka_txt
            // 
            this.lozinka_txt.Location = new System.Drawing.Point(308, 197);
            this.lozinka_txt.Name = "lozinka_txt";
            this.lozinka_txt.PasswordChar = '*';
            this.lozinka_txt.Size = new System.Drawing.Size(158, 22);
            this.lozinka_txt.TabIndex = 1;
            // 
            // Email_lbl
            // 
            this.Email_lbl.AutoSize = true;
            this.Email_lbl.Font = new System.Drawing.Font("Rockwell Nova Cond", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Email_lbl.Location = new System.Drawing.Point(235, 156);
            this.Email_lbl.Name = "Email_lbl";
            this.Email_lbl.Size = new System.Drawing.Size(45, 24);
            this.Email_lbl.TabIndex = 2;
            this.Email_lbl.Text = "Email:";
            // 
            // loznika_lbl
            // 
            this.loznika_lbl.AutoSize = true;
            this.loznika_lbl.Font = new System.Drawing.Font("Rockwell Nova Cond", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loznika_lbl.Location = new System.Drawing.Point(235, 194);
            this.loznika_lbl.Name = "loznika_lbl";
            this.loznika_lbl.Size = new System.Drawing.Size(54, 24);
            this.loznika_lbl.TabIndex = 3;
            this.loznika_lbl.Text = "Lozinka";
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("Rockwell Nova Cond", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_login.Location = new System.Drawing.Point(320, 236);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(118, 45);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Loguj se";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell Nova Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dobro došli! Unesite sledece podatke: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(585, 39);
            this.label2.TabIndex = 6;
            this.label2.Text = "Prodavnica sportske garderobe";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(753, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.loznika_lbl);
            this.Controls.Add(this.Email_lbl);
            this.Controls.Add(this.lozinka_txt);
            this.Controls.Add(this.email_txt);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox lozinka_txt;
        private System.Windows.Forms.Label Email_lbl;
        private System.Windows.Forms.Label loznika_lbl;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}