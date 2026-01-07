using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IK.DAL;
using IK.DOMAIN;

namespace IK
{
    public partial class FrmRapor : Form
    {
        PersonelDAO personelDAO = new PersonelDAO();
        DepartmanDAO departmanDAO = new DepartmanDAO();
        MaasDAO maasDAO = new MaasDAO();
        IzinDAO izinDAO = new IzinDAO();

        List<Personel> personels;
        List<departman> departmans;
        List<Maas> maaslar;
        List<Izin> izinler;
        List<DetayliRaporDTO> detayliRaporListesi;

        public FrmRapor()
        {
            InitializeComponent();
            LoadData(); 
            LoadOverview(); 
            LoadFilters(); 
            ApplyGridStyling(); 
            
            // Başlangıçta tüm verileri yükle
            btnSorgula_Click(null, null);
        }

        private void LoadData()
        {
            personels = personelDAO.GetAll();
            departmans = departmanDAO.GetAll();
            maaslar = maasDAO.GetAll();
            izinler = izinDAO.GetAll();
        }

        private void ApplyGridStyling()
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadOverview()
        {
            decimal totalMaas = maaslar.Sum(x => x.M_NetMaas);
            label1.Text = "TOPLAM PERSONEL\n" + personels.Count;
            label2.Text = "TOPLAM DEPARTMAN\n" + departmans.Count;
            label4.Text = "TOPLAM GİDER (MAAŞ)\n" + totalMaas.ToString("C2");


            // GRAFİK 1: Departmanlara Göre Personel
            var deptPersonelCounts = from p in personels
                                     join d in departmans on p.DepartmentId equals d.Departman_Id
                                     group p by d.DepartmanAdi into g
                                     select new { DeptName = g.Key, Count = g.Count() };

            DprtPersonel.Series[0].Points.Clear();
            DprtPersonel.Series[0].Name = "Personel";
            foreach (var item in deptPersonelCounts)
                DprtPersonel.Series[0].Points.AddXY(item.DeptName, item.Count);

            // GRAFİK 2: İzin Günü
            var deptIzinCounts = from i in izinler
                                 join p in personels on i.P_Id equals p.P_Id
                                 join d in departmans on p.DepartmentId equals d.Departman_Id
                                 group i by d.DepartmanAdi into g
                                 select new { DeptName = g.Key, TotalDays = g.Sum(x => (x.IzinBit - x.IzinBas).TotalDays) };

            Departİzin.Series[0].Points.Clear();
            Departİzin.Series[0].Name = "İzin Günü";
            foreach (var item in deptIzinCounts)
                Departİzin.Series[0].Points.AddXY(item.DeptName, item.TotalDays);

            // GRAFİK 3: Maaş Dağılımı
            var deptMaasSums = from m in maaslar
                               join p in personels on m.P_Id equals p.P_Id
                               join d in departmans on p.DepartmentId equals d.Departman_Id
                               group m by d.DepartmanAdi into g
                               select new { DeptName = g.Key, TotalMaas = g.Sum(x => x.M_NetMaas) };

            DepartMaaş.Series[0].Points.Clear();
            DepartMaaş.Series[0].Name = "Maaş";
            foreach (var item in deptMaasSums)
                DepartMaaş.Series[0].Points.AddXY(item.DeptName, item.TotalMaas);
        }

        private void LoadFilters()
        {
            var deptList = new List<departman>();
            deptList.Add(new departman { Departman_Id = -1, DepartmanAdi = "Tüm Departmanlar" });
            deptList.AddRange(departmans);

            cmbDepartman.DataSource = deptList;
            cmbDepartman.DisplayMember = "DepartmanAdi";
            cmbDepartman.ValueMember = "Departman_Id";
            cmbDepartman.SelectedValue = -1;

            // Tarih başlangıç ayarları (Varsayılan olarak geniş bir aralık tutuyoruz)
            dtpBaslangic.Value = new DateTime(2000, 1, 1);
            dtpBitis.Value = DateTime.Now;
        }

        // --- FILTER & QUERY LOGIC ---

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            LoadData(); // Verileri tazele

            // 1. Veri Birleştirme (Join Logic)
            // Not: Maaş ve İzin bilgileri personel bazında özetlenecek.
            // En son maaşı ve toplam izin gününü alacağız.
            
            var query = from p in personels
                        join d in departmans on p.DepartmentId equals d.Departman_Id into deptGroup
                        from d in deptGroup.DefaultIfEmpty() // LEFT JOIN
                        let sonMaas = maaslar.Where(m => m.P_Id == p.P_Id).OrderByDescending(m => m.M_Olusturulma_Tarihi).FirstOrDefault()
                        let toplamIzin = izinler.Where(i => i.P_Id == p.P_Id).Sum(i => i.TotalIzin)
                        select new DetayliRaporDTO
                        {
                            P_Id = p.P_Id,
                            Ad = p.P_Ad,
                            Soyad = p.P_Soyad,
                            TC = p.P_TcNo,
                            DepartmanAd = d != null ? d.DepartmanAdi : "DEPARTMANSIZ",
                            Pozisyon = p.P_Position,
                            Maas = sonMaas != null ? sonMaas.M_NetMaas : 0,
                            ToplamIzin = toplamIzin,
                            IseBaslangic = p.P_IseBaslangic
                        };

            // 2. Filtreleme
            
            // A) Departman Filtresi
            if (cmbDepartman.SelectedValue != null && (int)cmbDepartman.SelectedValue != -1)
            {
                int selectedDeptId = (int)cmbDepartman.SelectedValue;
                // DTO'da departman ID yok, isimden gidebiliriz veya yukarıdaki query'i id ile yapabilirdik.
                // Basitlik için string karşılaştırma ve Id uyumu:
                // Ancak DTO'ya DepartmanId eklemedik, o yüzden join scope'unda filtrelemek daha doğru olurdu.
                // Düzeltme: Query'i materialize etmeden önce filtrelemek lazım ama List<Personel> in memory olduğu için:
                var pIdsInDept = personels.Where(p => p.DepartmentId == selectedDeptId).Select(p => p.P_Id).ToList();
                query = query.Where(x => pIdsInDept.Contains(x.P_Id)); 
            }

            // B) Arama (TC veya Ad Soyad)
            if (!string.IsNullOrEmpty(txtArama.Text))
            {
                string searchKey = txtArama.Text.ToLower();
                query = query.Where(x => (x.Ad.ToLower() + " " + x.Soyad.ToLower()).Contains(searchKey) || 
                                         (x.TC != null && x.TC.Contains(searchKey)));
            }

            // C) Tarih Filtresi (İşe Başlangıç Tarihine göre filtreliyoruz - Personel Raporu olduğu için en mantıklısı)
            // Eğer "Maaş Raporu" olsaydı maaş tarihine bakardık. Kullanıcı "Zaman Filtresi" dedi.
            // Opsiyonel: Checkbox yoksa her zaman filtreler.
            DateTime start = dtpBaslangic.Value.Date;
            DateTime end = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1); // Gün sonu
            
            // Eğer işe giriş tarihine göre filtrele
            // query = query.Where(x => x.IseBaslangic.HasValue && x.IseBaslangic.Value >= start && x.IseBaslangic.Value <= end);
            
            // Ancak kullanıcı "Maaş toplamı bu ay" gibi istiyorsa, bu yapı personel listesini filtereler.
            // Varsayılan olarak listeyi filtrelemeyelim, sadece "Sorgula"ya basınca uygulasın.

             query = query.Where(x => x.IseBaslangic.HasValue && x.IseBaslangic.Value >= start && x.IseBaslangic.Value <= end);

            detayliRaporListesi = query.ToList();
            dataGridView1.DataSource = detayliRaporListesi;

            // 3. Durum Çubuğu Güncelleme
            UpdateStatusLabel();
        }

        private void UpdateStatusLabel()
        {
            if (detayliRaporListesi != null)
            {
                decimal totalMaas = detayliRaporListesi.Sum(x => x.Maas);
                lblStatus.Text = $"Toplam {detayliRaporListesi.Count} kayıt bulundu.\n" +
                                 $"Filtrelenen Personel Maaş Toplamı: {totalMaas:C2}";
            }
        }

        // Canlı Arama
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            // Veri zaten yüklü ise sadece liste içinde filtrele (Performans için tekrar sorgu atılabilir veya in-memory)
            // Basitlik için butona tıklama mantığını çağırıyoruz ama performansı korumak için in-memory filter daha iyi.
            // Fakat "Sorgula" metodumuz zaten in-memory listelerden çalışıyor (LoadData hariç).
            // LoadData'yı skip edersek daha hızlı olur.
            
            // Tekrar sorgula butonunu tetikleyelim (LoadData cachelenebilir ama şimdilik hızlı çalışır)
            btnSorgula_Click(null, null);
        }

        // Hızlı Seçim Butonları
        private void btnBuAy_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpBaslangic.Value = new DateTime(now.Year, now.Month, 1);
            dtpBitis.Value = dtpBaslangic.Value.AddMonths(1).AddDays(-1);
            btnSorgula_Click(null, null);
        }

        private void btnBuYil_Click(object sender, EventArgs e)
        {
            dtpBaslangic.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpBitis.Value = new DateTime(DateTime.Now.Year, 12, 31);
            btnSorgula_Click(null, null);
        }

        // Excel Export (CSV)
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (detayliRaporListesi == null || detayliRaporListesi.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyası|*.csv|Excel Dosyası|*.xlsx";
            sfd.FileName = "PersonelRaporu_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    
                    // Başlıklar
                    sb.AppendLine("ID;Ad;Soyad;TC;Departman;Pozisyon;Maaş;Toplam İzin");

                    // Satırlar
                    foreach (var item in detayliRaporListesi)
                    {
                        sb.AppendLine($"{item.P_Id};{item.Ad};{item.Soyad};{item.TC};{item.DepartmanAd};{item.Pozisyon};{item.Maas};{item.ToplamIzin}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Veriler başarıyla dışa aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // PDF Export (Basic Grid Printing)
        private void btnPdf_Click(object sender, EventArgs e)
        {
             if (detayliRaporListesi == null || detayliRaporListesi.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Basit yazdırma işlemi (PDF Yazıcısı seçilerek PDF kaydedilebilir)
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDocument_PrintPage);
            
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Basit Tablo Çizimi
            int x = 20, y = 20;
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font contentFont = new Font("Arial", 9);
            Brush brush = Brushes.Black;
            int rowHeight = 25;

            // Başlıklar
            e.Graphics.DrawString("Personel Raporu", new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline), brush, x, y);
            y += 40;

            string headers = "Ad Soyad | Departman | Pozisyon | Maaş | İzin";
            e.Graphics.DrawString(headers, headerFont, brush, x, y);
            y += 30;
            e.Graphics.DrawLine(Pens.Black, x, y, 750, y);
            y += 5;

            // Veriler (Sadece ilk sayfa basit çizimi - Gelişmiş PDF kütüphanesi olmadığı için)
            foreach (var item in detayliRaporListesi)
            {
                if (y > e.MarginBounds.Bottom) break; // Sayfa taşarsa dur (Pagination yok)

                string line = $"{item.Ad} {item.Soyad} | {item.DepartmanAd} | {item.Pozisyon} | {item.Maas:C2} | {item.ToplamIzin}";
                e.Graphics.DrawString(line, contentFont, brush, x, y);
                y += rowHeight;
            }
        }

        // Boilerplate empty events
        private void chart1_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }
        private void DprtPersonel_Click(object sender, EventArgs e) { }
        private void Departİzin_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
