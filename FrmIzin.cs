using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IK.DOMAIN;
using IK.SERVICE;

namespace IK
{
    public partial class FrmIzin : Form
    {
        private readonly Kullanici _aktifKullanici;
        private readonly IzinService _izinService = new IzinService();
        private readonly PersonelService _personelService = new PersonelService();

        public FrmIzin(Kullanici aktifKullanici)
        {
            InitializeComponent();
            _aktifKullanici = aktifKullanici;
        }

        private void FrmIzin_Load(object sender, EventArgs e)
        {
            IzinTuruDoldur();
            PersonelDropDownDoldur();
            IzinListeYenile();
            RolYetkisiUygula();
        }

        private void IzinTuruDoldur()
        {
            cmbIzinTuru.Items.Clear();
            cmbIzinTuru.Items.Add("Yıllık");
            cmbIzinTuru.Items.Add("Raporlu");
            cmbIzinTuru.Items.Add("Ücretsiz");
            cmbIzinTuru.Items.Add("Mazeret");
            cmbIzinTuru.SelectedIndex = 0;
        }

        private void PersonelDropDownDoldur()
        {
            
        }

        private void RolYetkisiUygula()
        {
            if (_aktifKullanici.Rol_Id == 3)
            {
                // Personel: onay / red yapamaz
                btnOnayla.Visible = false;
                btnReddet.Visible = false;
            }
            else
            {
                btnOnayla.Visible = true;
                btnReddet.Visible = true;
            }
        }

        private void IzinListeYenile()
        {
            List<Izin> liste;

            if (_aktifKullanici.Rol_Id == 3 && _aktifKullanici.P_Id.HasValue)
            {
                liste = _izinService.GetIzinlerForPersonel(_aktifKullanici.P_Id.Value);
            }
            else
            {
                liste = _izinService.GetIzinlerForAdmin();
            }

            dgvIzinler.DataSource = liste;
            dgvIzinler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIzinler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIzinler.MultiSelect = false;
            dgvIzinler.ReadOnly = true;

            if (dgvIzinler.Columns["I_Id"] != null) dgvIzinler.Columns["I_Id"].HeaderText = "ID";
            if (dgvIzinler.Columns["PersonelAdSoyad"] != null) dgvIzinler.Columns["PersonelAdSoyad"].HeaderText = "Personel";
            if (dgvIzinler.Columns["IzinTuru"] != null) dgvIzinler.Columns["IzinTuru"].HeaderText = "Tür";
            if (dgvIzinler.Columns["IzinBas"] != null) dgvIzinler.Columns["IzinBas"].HeaderText = "Başlangıç";
            if (dgvIzinler.Columns["IzinBit"] != null) dgvIzinler.Columns["IzinBit"].HeaderText = "Bitiş";
            if (dgvIzinler.Columns["TotalIzin"] != null) dgvIzinler.Columns["TotalIzin"].HeaderText = "Gün";
            if (dgvIzinler.Columns["Durum"] != null) dgvIzinler.Columns["Durum"].HeaderText = "Durum";
            if (dgvIzinler.Columns["Aciklama"] != null) dgvIzinler.Columns["Aciklama"].HeaderText = "Açıklama";

            // Tekniğe çok gerek yok ama bazı kolonları gizlemek istersen:
            if (dgvIzinler.Columns["P_Id"] != null) dgvIzinler.Columns["P_Id"].Visible = false;
            if (dgvIzinler.Columns["ApprovedByK_Id"] != null) dgvIzinler.Columns["ApprovedByK_Id"].Visible = false;
            if (dgvIzinler.Columns["Olusturulma_Tarihi"] != null) dgvIzinler.Columns["Olusturulma_Tarihi"].HeaderText = "Oluşturma";
        }

        private int SeciliIzinId
        {
            get
            {
                if (dgvIzinler.CurrentRow == null) return 0;
                return Convert.ToInt32(dgvIzinler.CurrentRow.Cells["I_Id"].Value);
            }
        }

        // Tarih değiştiğinde gün sayısını hesapla
        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            GunHesapla();
        }

        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            GunHesapla();
        }

        private void GunHesapla()
        {
            var bas = dtpBaslangic.Value.Date;
            var bit = dtpBitis.Value.Date;

            int gun = (bit - bas).Days + 1;
            if (gun < 0) gun = 0;

            txtGun.Text = gun.ToString();
        }

        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvIzinler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var satir = dgvIzinler.Rows[e.RowIndex];

            // Onay / red için sadece ID önemli, istersen alanlara da doldurabilirsin
            dtpBaslangic.Value = Convert.ToDateTime(satir.Cells["IzinBas"].Value);
            dtpBitis.Value = Convert.ToDateTime(satir.Cells["IzinBit"].Value);
            txtGun.Text = satir.Cells["TotalIzin"].Value.ToString();
            cmbIzinTuru.SelectedItem = satir.Cells["IzinTuru"].Value.ToString();
            txtAciklama.Text = satir.Cells["Aciklama"].Value?.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
       
        {
            if (cmbIzinTuru.SelectedItem == null)
            {
                MessageBox.Show("Lütfen izin türünü seçiniz.");
                return;
            }

            int pId;

            if (_aktifKullanici.Rol_Id == 3) // personel
            {
                if (!_aktifKullanici.P_Id.HasValue)
                {
                    MessageBox.Show("Bu kullanıcıya bağlı personel bilgisi bulunamadı.");
                    return;
                }
                pId = _aktifKullanici.P_Id.Value;
            }
           

            if (!int.TryParse(txtGun.Text, out int gun) || gun <= 0)
            {
                MessageBox.Show("İzin gün sayısı geçersiz.");
                return;
            }

            Izin izin = new Izin
            {
                
               
                IzinTuru = cmbIzinTuru.SelectedItem.ToString(),
                IzinBas = dtpBaslangic.Value.Date,
                IzinBit = dtpBitis.Value.Date,
                TotalIzin = gun,
                Durum = "Beklemede",
                Aciklama = string.IsNullOrWhiteSpace(txtAciklama.Text) ? null : txtAciklama.Text.Trim(),
                ApprovedByK_Id = null
            };

            string sonuc = _izinService.AddIzin(izin);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                IzinListeYenile();
                FormuTemizle();
            }
        }

        private void FormuTemizle()
        {
            if (_aktifKullanici.Rol_Id != 3)
              

            cmbIzinTuru.SelectedIndex = 0;
            dtpBaslangic.Value = DateTime.Today;
            dtpBitis.Value = DateTime.Today;
            txtGun.Text = "1";
            txtAciklama.Clear();
        }
        

        private void btnSil_Click(object sender, EventArgs e)
        {
            int izinId = SeciliIzinId;
            if (izinId == 0)
            {
                MessageBox.Show("Lütfen silinecek izni seçiniz.");
                return;
            }

            if (MessageBox.Show("Bu izin talebini silmek istiyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sonuc = _izinService.DeleteIzin(izinId);
                MessageBox.Show(sonuc);
                IzinListeYenile();
            }
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (_aktifKullanici.Rol_Id == 3)
            {
                MessageBox.Show("İzin reddetme yetkiniz yok.");
                return;
            }

            int izinId = SeciliIzinId;
            if (izinId == 0)
            {
                MessageBox.Show("Lütfen reddedilecek izni seçiniz.");
                return;
            }

            string sonuc = _izinService.ReddetIzin(izinId, _aktifKullanici.K_Id);
            MessageBox.Show(sonuc);
            IzinListeYenile();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (_aktifKullanici.Rol_Id == 3)
            {
                MessageBox.Show("İzin onaylama yetkiniz yok.");
                return;
            }

            int izinId = SeciliIzinId;
            if (izinId == 0)
            {
                MessageBox.Show("Lütfen onaylanacak izni seçiniz.");
                return;
            }

            string sonuc = _izinService.OnaylaIzin(izinId, _aktifKullanici.K_Id);
            MessageBox.Show(sonuc);
            IzinListeYenile();
        }
    }
}