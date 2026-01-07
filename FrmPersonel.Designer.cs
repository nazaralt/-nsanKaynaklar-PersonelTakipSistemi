using System;
using System.Windows.Forms;

namespace IK
{
    partial class FrmPersonel
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
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.txtMaas = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPozisyon = new System.Windows.Forms.TextBox();
            this.dtpDogum = new System.Windows.Forms.DateTimePicker();
            this.dtpIseBaslangic = new System.Windows.Forms.DateTimePicker();
            this.cmbDepartman = new System.Windows.Forms.ComboBox();
            this.labelad = new System.Windows.Forms.Label();
            this.labelsoyad = new System.Windows.Forms.Label();
            this.labeltc = new System.Windows.Forms.Label();
            this.labelemail = new System.Windows.Forms.Label();
            this.labeltel = new System.Windows.Forms.Label();
            this.labelpozisyon = new System.Windows.Forms.Label();
            this.labelmaas = new System.Windows.Forms.Label();
            this.labeldt = new System.Windows.Forms.Label();
            this.labeligt = new System.Windows.Forms.Label();
            this.labeldprtmn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonel.Location = new System.Drawing.Point(354, 10);
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.RowHeadersWidth = 49;
            this.dgvPersonel.RowTemplate.Height = 24;
            this.dgvPersonel.Size = new System.Drawing.Size(1009, 422);
            this.dgvPersonel.TabIndex = 0;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(140, 51);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(173, 23);
            this.txtAd.TabIndex = 1;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(140, 75);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(173, 23);
            this.txtSoyad.TabIndex = 2;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Lime;
            this.btnEkle.Location = new System.Drawing.Point(169, 307);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(111, 39);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Blue;
            this.btnGuncelle.Location = new System.Drawing.Point(169, 352);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(111, 39);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSil.Location = new System.Drawing.Point(169, 397);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(111, 39);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(140, 199);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Size = new System.Drawing.Size(173, 23);
            this.txtMaas.TabIndex = 6;
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(140, 100);
            this.txtTc.Name = "txtTc";
            this.txtTc.Size = new System.Drawing.Size(173, 23);
            this.txtTc.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 124);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 23);
            this.txtEmail.TabIndex = 8;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(140, 149);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(173, 23);
            this.txtTel.TabIndex = 9;
            // 
            // txtPozisyon
            // 
            this.txtPozisyon.Location = new System.Drawing.Point(140, 173);
            this.txtPozisyon.Name = "txtPozisyon";
            this.txtPozisyon.Size = new System.Drawing.Size(173, 23);
            this.txtPozisyon.TabIndex = 10;
            // 
            // dtpDogum
            // 
            this.dtpDogum.Location = new System.Drawing.Point(140, 223);
            this.dtpDogum.Name = "dtpDogum";
            this.dtpDogum.Size = new System.Drawing.Size(173, 23);
            this.dtpDogum.TabIndex = 11;
            // 
            // dtpIseBaslangic
            // 
            this.dtpIseBaslangic.Location = new System.Drawing.Point(140, 248);
            this.dtpIseBaslangic.Name = "dtpIseBaslangic";
            this.dtpIseBaslangic.Size = new System.Drawing.Size(173, 23);
            this.dtpIseBaslangic.TabIndex = 12;
            // 
            // cmbDepartman
            // 
            this.cmbDepartman.FormattingEnabled = true;
            this.cmbDepartman.Location = new System.Drawing.Point(140, 272);
            this.cmbDepartman.Name = "cmbDepartman";
            this.cmbDepartman.Size = new System.Drawing.Size(173, 23);
            this.cmbDepartman.TabIndex = 13;
            // 
            // labelad
            // 
            this.labelad.AutoSize = true;
            this.labelad.Location = new System.Drawing.Point(97, 53);
            this.labelad.Name = "labelad";
            this.labelad.Size = new System.Drawing.Size(34, 15);
            this.labelad.TabIndex = 14;
            this.labelad.Text = "AD:";
            // 
            // labelsoyad
            // 
            this.labelsoyad.AutoSize = true;
            this.labelsoyad.Location = new System.Drawing.Point(69, 80);
            this.labelsoyad.Name = "labelsoyad";
            this.labelsoyad.Size = new System.Drawing.Size(65, 15);
            this.labelsoyad.TabIndex = 15;
            this.labelsoyad.Text = "SOYAD:";
            // 
            // labeltc
            // 
            this.labeltc.AutoSize = true;
            this.labeltc.Location = new System.Drawing.Point(97, 102);
            this.labeltc.Name = "labeltc";
            this.labeltc.Size = new System.Drawing.Size(32, 15);
            this.labeltc.TabIndex = 16;
            this.labeltc.Text = "TC:";
            // 
            // labelemail
            // 
            this.labelemail.AutoSize = true;
            this.labelemail.Location = new System.Drawing.Point(72, 130);
            this.labelemail.Name = "labelemail";
            this.labelemail.Size = new System.Drawing.Size(66, 15);
            this.labelemail.TabIndex = 17;
            this.labelemail.Text = "E-MAİL:";
            // 
            // labeltel
            // 
            this.labeltel.AutoSize = true;
            this.labeltel.Location = new System.Drawing.Point(91, 151);
            this.labeltel.Name = "labeltel";
            this.labeltel.Size = new System.Drawing.Size(42, 15);
            this.labeltel.TabIndex = 18;
            this.labeltel.Text = "TEL:";
            // 
            // labelpozisyon
            // 
            this.labelpozisyon.AutoSize = true;
            this.labelpozisyon.Location = new System.Drawing.Point(51, 178);
            this.labelpozisyon.Name = "labelpozisyon";
            this.labelpozisyon.Size = new System.Drawing.Size(88, 15);
            this.labelpozisyon.TabIndex = 19;
            this.labelpozisyon.Text = "POZİSYON:";
            // 
            // labelmaas
            // 
            this.labelmaas.AutoSize = true;
            this.labelmaas.Location = new System.Drawing.Point(77, 204);
            this.labelmaas.Name = "labelmaas";
            this.labelmaas.Size = new System.Drawing.Size(55, 15);
            this.labelmaas.TabIndex = 20;
            this.labelmaas.Text = "MAAŞ:";
            // 
            // labeldt
            // 
            this.labeldt.AutoSize = true;
            this.labeldt.Location = new System.Drawing.Point(17, 228);
            this.labeldt.Name = "labeldt";
            this.labeldt.Size = new System.Drawing.Size(122, 15);
            this.labeldt.TabIndex = 21;
            this.labeldt.Text = "DOĞUM TARİHİ:";
            // 
            // labeligt
            // 
            this.labeligt.AutoSize = true;
            this.labeligt.Location = new System.Drawing.Point(10, 253);
            this.labeligt.Name = "labeligt";
            this.labeligt.Size = new System.Drawing.Size(131, 15);
            this.labeligt.TabIndex = 22;
            this.labeligt.Text = "İŞE GİRİŞ TARİHİ:";
            // 
            // labeldprtmn
            // 
            this.labeldprtmn.AutoSize = true;
            this.labeldprtmn.Location = new System.Drawing.Point(33, 279);
            this.labeldprtmn.Name = "labeldprtmn";
            this.labeldprtmn.Size = new System.Drawing.Size(108, 15);
            this.labeldprtmn.TabIndex = 23;
            this.labeldprtmn.Text = "DEPARTMAN:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IK.Properties.Resources.Factory_icon_isolated_fotor_bg_remover_20251207163330;
            this.pictureBox1.Location = new System.Drawing.Point(-52, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 484);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1375, 443);
            this.Controls.Add(this.dgvPersonel);
            this.Controls.Add(this.labeldprtmn);
            this.Controls.Add(this.labeligt);
            this.Controls.Add(this.labeldt);
            this.Controls.Add(this.labelmaas);
            this.Controls.Add(this.labelpozisyon);
            this.Controls.Add(this.labeltel);
            this.Controls.Add(this.labelemail);
            this.Controls.Add(this.labeltc);
            this.Controls.Add(this.labelsoyad);
            this.Controls.Add(this.labelad);
            this.Controls.Add(this.cmbDepartman);
            this.Controls.Add(this.dtpIseBaslangic);
            this.Controls.Add(this.dtpDogum);
            this.Controls.Add(this.txtPozisyon);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.txtMaas);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 8.139131F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FrmPersonel";
            this.Text = "FrmPersonel";
            this.Load += new System.EventHandler(this.FrmPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonel;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtMaas;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtPozisyon;
        private System.Windows.Forms.DateTimePicker dtpDogum;
        private System.Windows.Forms.DateTimePicker dtpIseBaslangic;
        private System.Windows.Forms.ComboBox cmbDepartman;
        private System.Windows.Forms.Label labelad;
        private System.Windows.Forms.Label labelsoyad;
        private System.Windows.Forms.Label labeltc;
        private System.Windows.Forms.Label labelemail;
        private System.Windows.Forms.Label labeltel;
        private System.Windows.Forms.Label labelpozisyon;
        private System.Windows.Forms.Label labelmaas;
        private System.Windows.Forms.Label labeldt;
        private System.Windows.Forms.Label labeligt;
        private System.Windows.Forms.Label labeldprtmn;
        private PictureBox pictureBox1;
    }
}