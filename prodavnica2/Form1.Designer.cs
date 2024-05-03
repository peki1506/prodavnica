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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StvUKrp = new System.Windows.Forms.Button();
            this.lbl_user = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(52, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(725, 382);
            this.dataGridView1.TabIndex = 0;
            // 
            // StvUKrp
            // 
            this.StvUKrp.Location = new System.Drawing.Point(354, 459);
            this.StvUKrp.Name = "StvUKrp";
            this.StvUKrp.Size = new System.Drawing.Size(117, 59);
            this.StvUKrp.TabIndex = 1;
            this.StvUKrp.Text = "Stavi u korpu";
            this.StvUKrp.UseVisualStyleBackColor = true;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(902, 29);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(44, 16);
            this.lbl_user.TabIndex = 2;
            this.lbl_user.Text = "label1";
            // 
            // Prodavnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 530);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.StvUKrp);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Prodavnica";
            this.Text = "Prodavnica";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Prodavnica_FormClosed);
            this.Load += new System.EventHandler(this.Prodavnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button StvUKrp;
        private System.Windows.Forms.Label lbl_user;
    }
}

