namespace Blocco_Note___Progetto_Satta_Riccardo
{
    partial class Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_presentazione = new System.Windows.Forms.Label();
            this.lbl_versione = new System.Windows.Forms.Label();
            this.lbl_licenza = new System.Windows.Forms.Label();
            this.btn_accedereAlBloccoNote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 229);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_presentazione
            // 
            this.lbl_presentazione.AutoSize = true;
            this.lbl_presentazione.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_presentazione.Location = new System.Drawing.Point(284, 9);
            this.lbl_presentazione.Name = "lbl_presentazione";
            this.lbl_presentazione.Size = new System.Drawing.Size(431, 37);
            this.lbl_presentazione.TabIndex = 1;
            this.lbl_presentazione.Text = "Blocco Note di Riccardo Satta";
            // 
            // lbl_versione
            // 
            this.lbl_versione.AutoSize = true;
            this.lbl_versione.Location = new System.Drawing.Point(288, 60);
            this.lbl_versione.Name = "lbl_versione";
            this.lbl_versione.Size = new System.Drawing.Size(81, 16);
            this.lbl_versione.TabIndex = 2;
            this.lbl_versione.Text = "Versione 1.0";
            // 
            // lbl_licenza
            // 
            this.lbl_licenza.AutoSize = true;
            this.lbl_licenza.Location = new System.Drawing.Point(288, 76);
            this.lbl_licenza.Name = "lbl_licenza";
            this.lbl_licenza.Size = new System.Drawing.Size(94, 16);
            this.lbl_licenza.TabIndex = 3;
            this.lbl_licenza.Text = "Licenza Libera";
            // 
            // btn_accedereAlBloccoNote
            // 
            this.btn_accedereAlBloccoNote.BackColor = System.Drawing.Color.Navy;
            this.btn_accedereAlBloccoNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_accedereAlBloccoNote.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_accedereAlBloccoNote.Location = new System.Drawing.Point(371, 341);
            this.btn_accedereAlBloccoNote.Name = "btn_accedereAlBloccoNote";
            this.btn_accedereAlBloccoNote.Size = new System.Drawing.Size(356, 128);
            this.btn_accedereAlBloccoNote.TabIndex = 4;
            this.btn_accedereAlBloccoNote.Text = "CLICCA QUI PER ACCEDERE AL BLOCCO NOTE!";
            this.btn_accedereAlBloccoNote.UseVisualStyleBackColor = false;
            this.btn_accedereAlBloccoNote.Click += new System.EventHandler(this.btn_accedereAlBloccoNote_Click);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 538);
            this.Controls.Add(this.btn_accedereAlBloccoNote);
            this.Controls.Add(this.lbl_licenza);
            this.Controls.Add(this.lbl_versione);
            this.Controls.Add(this.lbl_presentazione);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informazioni sul blocco note di Riccardo Satta";
            this.Load += new System.EventHandler(this.Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_presentazione;
        private System.Windows.Forms.Label lbl_versione;
        private System.Windows.Forms.Label lbl_licenza;
        private System.Windows.Forms.Button btn_accedereAlBloccoNote;
    }
}