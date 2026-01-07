using IK.DOMAIN;
using IK.SERVICE;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IK
{
    public partial class FrmDepartman : Form
    {
        private readonly DepartmanService _departmanService = new DepartmanService();

        public FrmDepartman()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            DepartmanListeyiYenile();

        }

        private void DepartmanListeyiYenile()
        {
            dgvDepartman.DataSource = _departmanService.GetAllDepartman();

            dgvDepartman.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDepartman.ReadOnly = true;
            dgvDepartman.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartman.MultiSelect = false;

            if (dgvDepartman.Columns["Departman_Id"] != null)
                dgvDepartman.Columns["Departman_Id"].HeaderText = "ID";

            if (dgvDepartman.Columns["DepartmanAdi"] != null)
                dgvDepartman.Columns["DepartmanAdi"].HeaderText = "Departman Adı";
        }

        private int SeciliDepartmanId
        {
            get
            {
                if (dgvDepartman.CurrentRow == null)
                    return 0;

                return Convert.ToInt32(dgvDepartman.CurrentRow.Cells["Departman_Id"].Value);
            }
        }

        private void dgvDepartman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepartmanAd.Text))
            {
                MessageBox.Show("Departman adı boş olamaz.");
                return;
            }

            departman d = new departman
            {
                DepartmanAdi = txtDepartmanAd.Text.Trim()
            };

            string sonuc = _departmanService.AddDepartman(d);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                DepartmanListeyiYenile();

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = SeciliDepartmanId;
            if (id == 0)
            {
                MessageBox.Show("Lütfen güncellenecek departmanı seçiniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDepartmanAd.Text))
            {
                MessageBox.Show("Departman adı boş olamaz.");
                return;
            }

            departman d = new departman
            {
                Departman_Id = id,
                DepartmanAdi = txtDepartmanAd.Text.Trim()
            };

            string sonuc = _departmanService.UpdateDepartman(d);
            MessageBox.Show(sonuc);

            if (sonuc.Contains("başarıyla"))
            {
                DepartmanListeyiYenile();

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = SeciliDepartmanId;
            if (id == 0)
            {
                MessageBox.Show("Lütfen silinecek departmanı seçiniz.");
                return;
            }

            if (MessageBox.Show("Bu departmanı silmek istiyor musunuz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sonuc = _departmanService.DeleteDepartman(id);
                MessageBox.Show(sonuc);

                if (sonuc.Contains("başarıyla"))
                {
                    DepartmanListeyiYenile();

                }
            }
        }

        private void dgvDepartman_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
