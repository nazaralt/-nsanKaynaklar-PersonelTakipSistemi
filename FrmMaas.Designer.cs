namespace IK
{
    partial class FrmMaas
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
            this.lblPersonel = new System.Windows.Forms.Label();
            this.lblYil = new System.Windows.Forms.Label();
            this.lblAy = new System.Windows.Forms.Label();
            this.lblTabanMaas = new System.Windows.Forms.Label();
            this.lblPrim = new System.Windows.Forms.Label();
            this.lblKesinti = new System.Windows.Forms.Label();
            this.lblNetMaas = new System.Windows.Forms.Label();
            this.cmbPersonel = new System.Windows.Forms.ComboBox();
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.cmbAy = new System.Windows.Forms.ComboBox();
            this.txtNetMaas = new System.Windows.Forms.TextBox();
            this.txtPrim = new System.Windows.Forms.TextBox();
            this.txtKesinti = new System.Windows.Forms.TextBox();
            this.txtTabanMaas = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvMaas = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPersonel
            // 
            this.lblPersonel.AutoSize = true;
            this.lblPersonel.Location = new System.Drawing.Point(34, 49);
            this.lblPersonel.Name = "lblPersonel";
            this.lblPersonel.Size = new System.Drawing.Size(95, 16);
            this.lblPersonel.TabIndex = 0;
            this.lblPersonel.Text = "PERSONEL:";
            // 
            // lblYil
            // 
            this.lblYil.AutoSize = true;
            this.lblYil.Location = new System.Drawing.Point(93, 86);
            this.lblYil.Name = "lblYil";
            this.lblYil.Size = new System.Drawing.Size(40, 16);
            this.lblYil.TabIndex = 1;
            this.lblYil.Text = "YIL:";
            // 
            // lblAy
            // 
            this.lblAy.AutoSize = true;
            this.lblAy.Location = new System.Drawing.Point(95, 126);
            this.lblAy.Name = "lblAy";
            this.lblAy.Size = new System.Drawing.Size(36, 16);
            this.lblAy.TabIndex = 2;
            this.lblAy.Text = "AY:";
            // 
            // lblTabanMaas
            // 
            this.lblTabanMaas.AutoSize = true;
            this.lblTabanMaas.Location = new System.Drawing.Point(75, 170);
            this.lblTabanMaas.Name = "lblTabanMaas";
            this.lblTabanMaas.Size = new System.Drawing.Size(58, 16);
            this.lblTabanMaas.TabIndex = 3;
            this.lblTabanMaas.Text = "MAAŞ:";
            // 
            // lblPrim
            // 
            this.lblPrim.AutoSize = true;
            this.lblPrim.Location = new System.Drawing.Point(79, 221);
            this.lblPrim.Name = "lblPrim";
            this.lblPrim.Size = new System.Drawing.Size(50, 16);
            this.lblPrim.TabIndex = 4;
            this.lblPrim.Text = "PRİM:";
            // 
            // lblKesinti
            // 
            this.lblKesinti.AutoSize = true;
            this.lblKesinti.Location = new System.Drawing.Point(60, 260);
            this.lblKesinti.Name = "lblKesinti";
            this.lblKesinti.Size = new System.Drawing.Size(73, 16);
            this.lblKesinti.TabIndex = 5;
            this.lblKesinti.Text = "KESİNTİ:";
            // 
            // lblNetMaas
            // 
            this.lblNetMaas.AutoSize = true;
            this.lblNetMaas.Location = new System.Drawing.Point(38, 302);
            this.lblNetMaas.Name = "lblNetMaas";
            this.lblNetMaas.Size = new System.Drawing.Size(95, 16);
            this.lblNetMaas.TabIndex = 6;
            this.lblNetMaas.Text = "NET MAAŞ:";
            // 
            // cmbPersonel
            // 
            this.cmbPersonel.FormattingEnabled = true;
            this.cmbPersonel.Location = new System.Drawing.Point(135, 42);
            this.cmbPersonel.Name = "cmbPersonel";
            this.cmbPersonel.Size = new System.Drawing.Size(197, 23);
            this.cmbPersonel.TabIndex = 7;
            // 
            // cmbYil
            // 
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Location = new System.Drawing.Point(135, 82);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(197, 23);
            this.cmbYil.TabIndex = 8;
            // 
            // cmbAy
            // 
            this.cmbAy.FormattingEnabled = true;
            this.cmbAy.Location = new System.Drawing.Point(135, 122);
            this.cmbAy.Name = "cmbAy";
            this.cmbAy.Size = new System.Drawing.Size(197, 23);
            this.cmbAy.TabIndex = 9;
            // 
            // txtNetMaas
            // 
            this.txtNetMaas.Location = new System.Drawing.Point(135, 299);
            this.txtNetMaas.Name = "txtNetMaas";
            this.txtNetMaas.ReadOnly = true;
            this.txtNetMaas.Size = new System.Drawing.Size(197, 24);
            this.txtNetMaas.TabIndex = 10;
            // 
            // txtPrim
            // 
            this.txtPrim.Location = new System.Drawing.Point(135, 218);
            this.txtPrim.Name = "txtPrim";
            this.txtPrim.Size = new System.Drawing.Size(197, 24);
            this.txtPrim.TabIndex = 11;
            // 
            // txtKesinti
            // 
            this.txtKesinti.Location = new System.Drawing.Point(135, 257);
            this.txtKesinti.Name = "txtKesinti";
            this.txtKesinti.Size = new System.Drawing.Size(197, 24);
            this.txtKesinti.TabIndex = 12;
            // 
            // txtTabanMaas
            // 
            this.txtTabanMaas.Location = new System.Drawing.Point(135, 167);
            this.txtTabanMaas.Name = "txtTabanMaas";
            this.txtTabanMaas.Size = new System.Drawing.Size(197, 24);
            this.txtTabanMaas.TabIndex = 13;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.Lime;
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(134, 339);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(80, 33);
            this.btnEkle.TabIndex = 14;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.Blue;
            this.btnGuncelle.Location = new System.Drawing.Point(220, 339);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(112, 33);
            this.btnGuncelle.TabIndex = 15;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.Location = new System.Drawing.Point(135, 380);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(79, 33);
            this.btnSil.TabIndex = 16;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.Yellow;
            this.btnTemizle.Location = new System.Drawing.Point(220, 378);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(112, 33);
            this.btnTemizle.TabIndex = 17;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgvMaas
            // 
            this.dgvMaas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMaas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaas.Location = new System.Drawing.Point(338, 42);
            this.dgvMaas.Name = "dgvMaas";
            this.dgvMaas.RowHeadersWidth = 49;
            this.dgvMaas.RowTemplate.Height = 24;
            this.dgvMaas.Size = new System.Drawing.Size(1046, 371);
            this.dgvMaas.TabIndex = 18;
            this.dgvMaas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaas_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IK.Properties.Resources.Factory_icon_isolated_fotor_bg_remover_20251207163330;
            this.pictureBox1.Location = new System.Drawing.Point(-164, -41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 484);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmMaas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1396, 440);
            this.Controls.Add(this.lblAy);
            this.Controls.Add(this.lblYil);
            this.Controls.Add(this.lblPersonel);
            this.Controls.Add(this.txtTabanMaas);
            this.Controls.Add(this.txtPrim);
            this.Controls.Add(this.txtKesinti);
            this.Controls.Add(this.txtNetMaas);
            this.Controls.Add(this.lblNetMaas);
            this.Controls.Add(this.lblKesinti);
            this.Controls.Add(this.lblPrim);
            this.Controls.Add(this.lblTabanMaas);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.dgvMaas);
            this.Controls.Add(this.cmbAy);
            this.Controls.Add(this.cmbYil);
            this.Controls.Add(this.cmbPersonel);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 8.765218F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMaas";
            this.Text = "FrmMaas";
            this.Load += new System.EventHandler(this.FrmMaas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPersonel;
        private System.Windows.Forms.Label lblYil;
        private System.Windows.Forms.Label lblAy;
        private System.Windows.Forms.Label lblTabanMaas;
        private System.Windows.Forms.Label lblPrim;
        private System.Windows.Forms.Label lblKesinti;
        private System.Windows.Forms.Label lblNetMaas;
        private System.Windows.Forms.ComboBox cmbPersonel;
        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.ComboBox cmbAy;
        private System.Windows.Forms.TextBox txtNetMaas;
        private System.Windows.Forms.TextBox txtPrim;
        private System.Windows.Forms.TextBox txtKesinti;
        private System.Windows.Forms.TextBox txtTabanMaas;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgvMaas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}