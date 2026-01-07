using IK.DOMAIN;
using IK.SERVICE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace IK
{
    public partial class FrmPersonel : Form
    {
        private readonly PersonelService _personelService = new PersonelService();
        private readonly DepartmanService _departmanService = new DepartmanService();

        public FrmPersonel()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            try
            {
                PersonelListeyiYenile();
                DepartmanlariYukle();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken hata oluştu: " + ex.Message);
            }
        }

        // PERSONEL LİSTESİ
        private void PersonelListeyiYenile()
        {
            var liste = _personelService.GetAllPersonel();
            dgvPersonel.DataSource = liste;

            dgvPersonel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonel.ReadOnly = true;
            dgvPersonel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonel.MultiSelect = false;

            if (dgvPersonel.Columns["P_Id"] != null) dgvPersonel.Columns["P_Id"].HeaderText = "ID";
            if (dgvPersonel.Columns["P_Ad"] != null) dgvPersonel.Columns["P_Ad"].HeaderText = "Ad";
            if (dgvPersonel.Columns["P_Soyad"] != null) dgvPersonel.Columns["P_Soyad"].HeaderText = "Soyad";
            if (dgvPersonel.Columns["P_TcNo"] != null) dgvPersonel.Columns["P_TcNo"].HeaderText = "TC No";
            if (dgvPersonel.Columns["P_Email"] != null) dgvPersonel.Columns["P_Email"].HeaderText = "E-Mail";
            if (dgvPersonel.Columns["P_Tel"] != null) dgvPersonel.Columns["P_Tel"].HeaderText = "Tel";
            if (dgvPersonel.Columns["P_DogumTarih"] != null) dgvPersonel.Columns["P_DogumTarih"].HeaderText = "Doğum Tarihi";
            if (dgvPersonel.Columns["P_IseBaslangic"] != null) dgvPersonel.Columns["P_IseBaslangic"].HeaderText = "İşe Giriş";
            if (dgvPersonel.Columns["DepartmentId"] != null) dgvPersonel.Columns["DepartmentId"].HeaderText = "Departman";
            if (dgvPersonel.Columns["P_Position"] != null) dgvPersonel.Columns["P_Position"].HeaderText = "Pozisyon";
            if (dgvPersonel.Columns["P_TMaas"] != null) dgvPersonel.Columns["P_TMaas"].HeaderText = "Maaş";
        }

        // DEPARTMAN COMBO
        private void DepartmanlariYukle()
        {
            var departmanlar = _departmanService.GetAllDepartman();

            cmbDepartman.DataSource = departmanlar;
            cmbDepartman.DisplayMember = "Departman";       // DOMAIN.Departman
            cmbDepartman.ValueMember = "Departman_Id";
            cmbDepartman.SelectedIndex = -1;
        }

        // SEÇİLİ PERSONEL ID
        private int SeciliPersonelId
        {
            get
            {
                if (dgvPersonel.CurrentRow == null)
                    return 0;

                return Convert.ToInt32(dgvPersonel.CurrentRow.Cells["P_Id"].Value);
            }
        }

        // GRID → TEXTBOXLARA DOLDUR
        private void dgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow satir = dgvPersonel.Rows[e.RowIndex];

            txtAd.Text = satir.Cells["P_Ad"].Value?.ToString();
            txtSoyad.Text = satir.Cells["P_Soyad"].Value?.ToString();
            txtTc.Text = satir.Cells["P_TcNo"].Value?.ToString();
            txtEmail.Text = satir.Cells["P_Email"].Value?.ToString();
            txtTel.Text = satir.Cells["P_Tel"].Value?.ToString();
            txtPozisyon.Text = satir.Cells["P_Position"].Value?.ToString();
            txtMaas.Text = satir.Cells["P_TMaas"].Value?.ToString();

            if (satir.Cells["P_DogumTarih"].Value != DBNull.Value &&
                satir.Cells["P_DogumTarih"].Value != null)
            {
                dtpDogum.Value = Convert.ToDateTime(satir.Cells["P_DogumTarih"].Value);
            }

            if (satir.Cells["P_IseBaslangic"].Value != DBNull.Value &&
                satir.Cells["P_IseBaslangic"].Value != null)
            {
                dtpIseBaslangic.Value = Convert.ToDateTime(satir.Cells["P_IseBaslangic"].Value);
            }

            if (satir.Cells["DepartmentId"].Value != DBNull.Value &&
                satir.Cells["DepartmentId"].Value != null)
            {
                cmbDepartman.SelectedValue =
                    Convert.ToInt32(satir.Cells["DepartmentId"].Value);
            }
            else
            {
                cmbDepartman.SelectedIndex = -1;
            }
        }

        

        // EKLE
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve Soyad zorunludur.");
                return;
            }

            decimal? maas = ParseMaas(txtMaas.Text);
            if (!string.IsNullOrWhiteSpace(txtMaas.Text) && maas == null)
            {
                MessageBox.Show("Maaş değeri geçerli sayı olmalıdır.");
                return;
            }

            int? depId = null;
            if (cmbDepartman.SelectedValue != null)
                depId = Convert.ToInt32(cmbDepartman.SelectedValue);

            Personel p = new Personel
            {
                P_Ad = txtAd.Text.Trim(),
                P_Soyad = txtSoyad.Text.Trim(),
                P_TcNo = txtTc.Text.Trim(),
                P_Email = txtEmail.Text.Trim(),
                P_Tel = txtTel.Text.Trim(),
                P_DogumTarih = dtpDogum.Value,
                P_IseBaslangic = dtpIseBaslangic.Value,
                DepartmentId = depId,
                P_Position = txtPozisyon.Text.Trim(),
                P_TMaas = maas
            };

            string sonuc = _personelService.AddPersonel(p);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                PersonelListeyiYenile();
                
            }
        }

        // GÜNCELLE
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = SeciliPersonelId;
            if (id == 0)
            {
                MessageBox.Show("Lütfen güncellenecek personeli seçiniz.");
                return;
            }

            decimal? maas = ParseMaas(txtMaas.Text);
            if (!string.IsNullOrWhiteSpace(txtMaas.Text) && maas == null)
            {
                MessageBox.Show("Maaş değeri geçerli sayı olmalıdır.");
                return;
            }

            int? depId = null;
            if (cmbDepartman.SelectedValue != null)
                depId = Convert.ToInt32(cmbDepartman.SelectedValue);

            Personel p = new Personel
            {
                P_Id = id,
                P_Ad = txtAd.Text.Trim(),
                P_Soyad = txtSoyad.Text.Trim(),
                P_TcNo = txtTc.Text.Trim(),
                P_Email = txtEmail.Text.Trim(),
                P_Tel = txtTel.Text.Trim(),
                P_DogumTarih = dtpDogum.Value,
                P_IseBaslangic = dtpIseBaslangic.Value,
                DepartmentId = depId,
                P_Position = txtPozisyon.Text.Trim(),
                P_TMaas = maas
            };

            string sonuc = _personelService.UpdatePersonel(p);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                PersonelListeyiYenile();
                
            }
        }

        // SİL
        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = SeciliPersonelId;
            if (id == 0)
            {
                MessageBox.Show("Lütfen silinecek personeli seçiniz.");
                return;
            }

            if (MessageBox.Show("Bu personeli silmek istiyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sonuc = _personelService.DeletePersonel(id);
                MessageBox.Show(sonuc);

                if (sonuc.Contains("başarıyla"))
                {
                    PersonelListeyiYenile();
                    
                }
            }
        }

        // Maaş parse yardımcı fonksiyonu
        private decimal? ParseMaas(string txt)
        {
            if (string.IsNullOrWhiteSpace(txt))
                return null;

            // Türkçe ondalık ve nokta varyasyonları için
            txt = txt.Replace(" ", "");

            if (decimal.TryParse(txt, NumberStyles.Any, CultureInfo.GetCultureInfo("tr-TR"), out decimal d))
                return d;

            if (decimal.TryParse(txt.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out d))
                return d;

            return null;
        }
    }
}
