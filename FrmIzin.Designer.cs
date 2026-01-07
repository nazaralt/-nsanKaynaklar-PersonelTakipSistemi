namespace IK
{
    partial class FrmIzin
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
            this.lblIzinTuru = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIzinBitis = new System.Windows.Forms.Label();
            this.lblGun = new System.Windows.Forms.Label();
            this.lblAcıklama = new System.Windows.Forms.Label();
            this.cmbIzinTuru = new System.Windows.Forms.ComboBox();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.txtGun = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnReddet = new System.Windows.Forms.Button();
            this.dgvIzinler = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIzinTuru
            // 
            this.lblIzinTuru.AutoSize = true;
            this.lblIzinTuru.Location = new System.Drawing.Point(50, 83);
            this.lblIzinTuru.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIzinTuru.Name = "lblIzinTuru";
            this.lblIzinTuru.Size = new System.Drawing.Size(100, 18);
            this.lblIzinTuru.TabIndex = 1;
            this.lblIzinTuru.Text = "İZİN TÜRÜ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "İZİN BAŞLANGIÇ:";
            // 
            // lblIzinBitis
            // 
            this.lblIzinBitis.AutoSize = true;
            this.lblIzinBitis.Location = new System.Drawing.Point(59, 149);
            this.lblIzinBitis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIzinBitis.Name = "lblIzinBitis";
            this.lblIzinBitis.Size = new System.Drawing.Size(91, 18);
            this.lblIzinBitis.TabIndex = 3;
            this.lblIzinBitis.Text = "İZİN BİTİŞ:";
            // 
            // lblGun
            // 
            this.lblGun.AutoSize = true;
            this.lblGun.Location = new System.Drawing.Point(102, 183);
            this.lblGun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGun.Name = "lblGun";
            this.lblGun.Size = new System.Drawing.Size(53, 18);
            this.lblGun.TabIndex = 4;
            this.lblGun.Text = "GÜN:";
            // 
            // lblAcıklama
            // 
            this.lblAcıklama.AutoSize = true;
            this.lblAcıklama.Location = new System.Drawing.Point(45, 215);
            this.lblAcıklama.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAcıklama.Name = "lblAcıklama";
            this.lblAcıklama.Size = new System.Drawing.Size(112, 18);
            this.lblAcıklama.TabIndex = 5;
            this.lblAcıklama.Text = "AÇIKLAMA:";
            // 
            // cmbIzinTuru
            // 
            this.cmbIzinTuru.FormattingEnabled = true;
            this.cmbIzinTuru.Location = new System.Drawing.Point(153, 83);
            this.cmbIzinTuru.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbIzinTuru.Name = "cmbIzinTuru";
            this.cmbIzinTuru.Size = new System.Drawing.Size(150, 26);
            this.cmbIzinTuru.TabIndex = 6;
            // 
            // dtpBitis
            // 
            this.dtpBitis.Location = new System.Drawing.Point(156, 149);
            this.dtpBitis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(195, 27);
            this.dtpBitis.TabIndex = 7;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Location = new System.Drawing.Point(153, 113);
            this.dtpBaslangic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(195, 27);
            this.dtpBaslangic.TabIndex = 9;
            // 
            // txtGun
            // 
            this.txtGun.Location = new System.Drawing.Point(153, 183);
            this.txtGun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGun.Name = "txtGun";
            this.txtGun.Size = new System.Drawing.Size(124, 27);
            this.txtGun.TabIndex = 10;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(153, 215);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(195, 114);
            this.txtAciklama.TabIndex = 11;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Cyan;
            this.btnEkle.Location = new System.Drawing.Point(53, 363);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(93, 34);
            this.btnEkle.TabIndex = 12;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Yellow;
            this.btnSil.Location = new System.Drawing.Point(154, 363);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(93, 34);
            this.btnSil.TabIndex = 13;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnOnayla
            // 
            this.btnOnayla.BackColor = System.Drawing.Color.Lime;
            this.btnOnayla.Location = new System.Drawing.Point(356, 363);
            this.btnOnayla.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(93, 34);
            this.btnOnayla.TabIndex = 14;
            this.btnOnayla.Text = "ONAYLA";
            this.btnOnayla.UseVisualStyleBackColor = false;
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // btnReddet
            // 
            this.btnReddet.BackColor = System.Drawing.Color.Red;
            this.btnReddet.Location = new System.Drawing.Point(255, 363);
            this.btnReddet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReddet.Name = "btnReddet";
            this.btnReddet.Size = new System.Drawing.Size(93, 34);
            this.btnReddet.TabIndex = 15;
            this.btnReddet.Text = "REDDET";
            this.btnReddet.UseVisualStyleBackColor = false;
            this.btnReddet.Click += new System.EventHandler(this.btnReddet_Click);
            // 
            // dgvIzinler
            // 
            this.dgvIzinler.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvIzinler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzinler.Location = new System.Drawing.Point(477, 12);
            this.dgvIzinler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvIzinler.Name = "dgvIzinler";
            this.dgvIzinler.RowHeadersWidth = 49;
            this.dgvIzinler.RowTemplate.Height = 24;
            this.dgvIzinler.Size = new System.Drawing.Size(830, 402);
            this.dgvIzinler.TabIndex = 16;
            this.dgvIzinler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIzinler_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IK.Properties.Resources.Factory_icon_isolated_fotor_bg_remover_20251207163330;
            this.pictureBox1.Location = new System.Drawing.Point(-143, -32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 484);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // FrmIzin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1320, 442);
            this.Controls.Add(this.btnReddet);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.dgvIzinler);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtGun);
            this.Controls.Add(this.dtpBaslangic);
            this.Controls.Add(this.dtpBitis);
            this.Controls.Add(this.cmbIzinTuru);
            this.Controls.Add(this.lblAcıklama);
            this.Controls.Add(this.lblGun);
            this.Controls.Add(this.lblIzinBitis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIzinTuru);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmIzin";
            this.Text = "S";
            this.Load += new System.EventHandler(this.FrmIzin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblIzinTuru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIzinBitis;
        private System.Windows.Forms.Label lblGun;
        private System.Windows.Forms.Label lblAcıklama;
        private System.Windows.Forms.ComboBox cmbIzinTuru;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.TextBox txtGun;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.Button btnReddet;
        private System.Windows.Forms.DataGridView dgvIzinler;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}