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
    public partial class FrmGiris : Form
    {

        private readonly KullaniciService _kullaniciService = new KullaniciService();

        public FrmGiris()
        {
            InitializeComponent();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            string mesaj;
            Kullanici giren = _kullaniciService.Login(kullaniciAdi, sifre, out mesaj);

            if (giren == null)
            {
                MessageBox.Show(mesaj, "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(mesaj, "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmAnaMenu ana = new FrmAnaMenu(giren);
            ana.Show();
            this.Hide();
        
    }
    }
}
