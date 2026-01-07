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
namespace IK
{
    public partial class FrmAnaMenu : Form
    {
        private readonly Kullanici _aktifKullanici;

        public FrmAnaMenu(Kullanici kullanici)
        {
            InitializeComponent();
            _aktifKullanici = kullanici;
        }

        private void FrmAnaMenu_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = "HOŞGELDİNİZ";
            RolYetkileriniAyarla();
        }

        private string RolAdiGetir()
        {
            switch (_aktifKullanici.Rol_Id)
            {
                case 1: return "";
                case 2: return "";
                case 3: return "";
                default: return "";
            }
        }

        private void RolYetkileriniAyarla()
        {
            // Hepsini önce kapat
            btnPersonel.Visible = false;
            btnDepartman.Visible = false;
            btnIzin.Visible = false;
            btnIzin.Visible = false;
            btnMaas.Visible = false;
            button1.Visible = false;
            

            switch (_aktifKullanici.Rol_Id)
            {
                case 1: // Yönetici → her şey açık
                    btnPersonel.Visible = true;
                    btnDepartman.Visible = true;
                    btnIzin.Visible = true;
                    btnIzin.Visible = true;
                    btnMaas.Visible = true;
                    button1.Visible = true;
                    
                    break;

                case 2: // İK → Personel + İzin
                    btnPersonel.Visible = true;
                    btnIzin.Visible = true;
                   
                    break;

                case 3: // Personel → sadece İzin
                    btnIzin.Visible = true;
                    break;
            }
        }


        private void btnPersonel_Click(object sender, EventArgs e)
        {
            using (FrmPersonel frm = new FrmPersonel())
            {
                frm.ShowDialog();
            }
        }

        private void btnDepartman_Click(object sender, EventArgs e)
        {
            using (FrmDepartman frm = new FrmDepartman())
            {
                frm.ShowDialog();
            }
        }

        private void btnIzin_Click(object sender, EventArgs e)
        {
            using (FrmIzin frm = new FrmIzin(_aktifKullanici)) // ileride kendi izinlerini filtrelemek için
                frm.ShowDialog();
        }

        private void btnMaas_Click(object sender, EventArgs e)
        {
            using (FrmMaas frm = new FrmMaas())
            {
                frm.ShowDialog();
            }
            using (FrmMaas frm = new FrmMaas())
            {
                frm.ShowDialog();
            }
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            using (FrmRapor frm = new FrmRapor())
            {
                frm.ShowDialog();
            }
        }

       
    }
}
