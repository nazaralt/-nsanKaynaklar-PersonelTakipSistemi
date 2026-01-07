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
    public partial class FrmMaas : Form
    {
        private readonly MaasService _maasService = new MaasService();
        private readonly PersonelService _personelService = new PersonelService();
        public FrmMaas()
        {
            InitializeComponent();
        }

        private void FrmMaas_Load(object sender, EventArgs e)
        {
            PersonelListeDoldur();
            YilAyDoldur();
            MaasListeYenile();

            txtPrim.Text = "0";
            txtKesinti.Text = "0";
        }
        private void PersonelListeDoldur()
        {
            var personeller = _personelService.GetAllPersonel();

            cmbPersonel.DataSource = personeller;
            // Personel DOMAIN sınıfında TamAd property’si varsa:
            // public string TamAd => P_Ad + " " + P_Soyad;
            cmbPersonel.DisplayMember = "TamAd";  // yoksa P_Ad/P_Soyad'a göre düzelt
            cmbPersonel.ValueMember = "P_Id";
            cmbPersonel.SelectedIndex = -1;
        }

        private void YilAyDoldur()
        {
            cmbYil.Items.Clear();
            int thisYear = DateTime.Now.Year;

            for (int y = thisYear - 2; y <= thisYear + 2; y++)
                cmbYil.Items.Add(y);

            cmbYil.SelectedItem = thisYear;

            cmbAy.Items.Clear();
            for (int ay = 1; ay <= 12; ay++)
                cmbAy.Items.Add(ay);

            cmbAy.SelectedItem = DateTime.Now.Month;
        }

        private void MaasListeYenile()
        {
            var liste = _maasService.GetAllMaas();

            dgvMaas.DataSource = liste;
            dgvMaas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaas.MultiSelect = false;
            dgvMaas.ReadOnly = true;

            if (dgvMaas.Columns["M_Id"] != null)
                dgvMaas.Columns["M_Id"].HeaderText = "ID";

            if (dgvMaas.Columns["P_Id"] != null)
                dgvMaas.Columns["P_Id"].Visible = false;

            if (dgvMaas.Columns["M_Yil"] != null)
                dgvMaas.Columns["M_Yil"].HeaderText = "Yıl";

            if (dgvMaas.Columns["M_Ay"] != null)
                dgvMaas.Columns["M_Ay"].HeaderText = "Ay";

            if (dgvMaas.Columns["M_TabanMaas"] != null)
                dgvMaas.Columns["M_TabanMaas"].HeaderText = "Taban Maaş";

            if (dgvMaas.Columns["M_Prim"] != null)
                dgvMaas.Columns["M_Prim"].HeaderText = "Prim";

            if (dgvMaas.Columns["M_Kesinti"] != null)
                dgvMaas.Columns["M_Kesinti"].HeaderText = "Kesinti";

            if (dgvMaas.Columns["M_NetMaas"] != null)
                dgvMaas.Columns["M_NetMaas"].HeaderText = "Net Maaş";
        }

        private int SeciliMaasId
        {
            get
            {
                if (dgvMaas.CurrentRow == null)
                    return 0;

                return Convert.ToInt32(dgvMaas.CurrentRow.Cells["M_Id"].Value);
            }
        }

        private decimal ParseDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0m;

            // Türkçe’de ondalık ayracı virgül, kullanıcı nokta da yazarsa kabul et
            if (decimal.TryParse(text.Replace(".", ","), out decimal value))
                return value;

            MessageBox.Show("Lütfen geçerli bir sayı giriniz.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0m;
        }

        private void HesaplaNetMaas()
        {
            decimal taban = ParseDecimal(txtTabanMaas.Text);
            decimal prim = ParseDecimal(txtPrim.Text);
            decimal kesinti = ParseDecimal(txtKesinti.Text);

            decimal net = taban + prim - kesinti;
            txtNetMaas.Text = net.ToString("0.00");
        }
        private void txtTabanMaas_TextChanged(object sender, EventArgs e)
        {
            HesaplaNetMaas();
        }

        private void txtPrim_TextChanged(object sender, EventArgs e)
        {
            HesaplaNetMaas();
        }

        private void txtKesinti_TextChanged(object sender, EventArgs e)
        {
            HesaplaNetMaas();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmbPersonel.SelectedIndex = -1;
            cmbYil.SelectedItem = DateTime.Now.Year;
            cmbAy.SelectedItem = DateTime.Now.Month;

            txtTabanMaas.Clear();
            txtPrim.Text = "0";
            txtKesinti.Text = "0";
            txtNetMaas.Clear();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbPersonel.SelectedValue == null)
            {
                MessageBox.Show("Lütfen personel seçiniz.");
                return;
            }

            if (cmbYil.SelectedItem == null || cmbAy.SelectedItem == null)
            {
                MessageBox.Show("Lütfen yıl ve ay seçiniz.");
                return;
            }

            decimal taban = ParseDecimal(txtTabanMaas.Text);
            if (taban <= 0)
            {
                MessageBox.Show("Taban maaş 0 olamaz.");
                return;
            }

            decimal prim = ParseDecimal(txtPrim.Text);
            decimal kesinti = ParseDecimal(txtKesinti.Text);
            decimal net = taban + prim - kesinti;

            Maas m = new Maas
            {
                P_Id = Convert.ToInt32(cmbPersonel.SelectedValue),
                M_Yil = Convert.ToInt32(cmbYil.SelectedItem),
                M_Ay = Convert.ToInt32(cmbAy.SelectedItem),
                M_TabanMaas = taban,
                M_Prim = prim,
                M_Kesinti = kesinti,
                M_NetMaas = net
            };

            string sonuc = _maasService.AddMaas(m);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                MaasListeYenile();
                btnTemizle_Click(null, null);
            }
        }

       

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = SeciliMaasId;
            if (id == 0)
            {
                MessageBox.Show("Lütfen güncellenecek kaydı seçiniz.");
                return;
            }

            if (cmbPersonel.SelectedValue == null ||
                cmbYil.SelectedItem == null ||
                cmbAy.SelectedItem == null)
            {
                MessageBox.Show("Personel, yıl ve ay seçili olmalıdır.");
                return;
            }

            decimal taban = ParseDecimal(txtTabanMaas.Text);
            decimal prim = ParseDecimal(txtPrim.Text);
            decimal kesinti = ParseDecimal(txtKesinti.Text);
            decimal net = taban + prim - kesinti;

            Maas m = new Maas
            {
                M_Id = id,
                P_Id = Convert.ToInt32(cmbPersonel.SelectedValue),
                M_Yil = Convert.ToInt32(cmbYil.SelectedItem),
                M_Ay = Convert.ToInt32(cmbAy.SelectedItem),
                M_TabanMaas = taban,
                M_Prim = prim,
                M_Kesinti = kesinti,
                M_NetMaas = net
            };

            string sonuc = _maasService.UpdateMaas(m);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                MaasListeYenile();
                btnTemizle_Click(null, null);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = SeciliMaasId;
            if (id == 0)
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz.");
                return;
            }

            if (MessageBox.Show("Bu maaş kaydını silmek istiyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sonuc = _maasService.DeleteMaas(id);
                MessageBox.Show(sonuc);

                if (sonuc.Contains("başarıyla"))
                {
                    MaasListeYenile();
                    btnTemizle_Click(null, null);
                }
            }
         }

        private void dgvMaas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvMaas.Rows[e.RowIndex];

            if (row.Cells["P_Id"] != null)
            {
                int pId = Convert.ToInt32(row.Cells["P_Id"].Value);
                cmbPersonel.SelectedValue = pId;
            }

            cmbYil.SelectedItem = Convert.ToInt32(row.Cells["M_Yil"].Value);
            cmbAy.SelectedItem = Convert.ToInt32(row.Cells["M_Ay"].Value);

            txtTabanMaas.Text = Convert
                .ToDecimal(row.Cells["M_TabanMaas"].Value)
                .ToString("0.00");

            txtPrim.Text = Convert
                .ToDecimal(row.Cells["M_Prim"].Value)
                .ToString("0.00");

            txtKesinti.Text = Convert
                .ToDecimal(row.Cells["M_Kesinti"].Value)
                .ToString("0.00");

            txtNetMaas.Text = Convert
                .ToDecimal(row.Cells["M_NetMaas"].Value)
                .ToString("0.00");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
