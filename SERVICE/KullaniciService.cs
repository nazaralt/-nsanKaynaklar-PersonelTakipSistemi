using IK.DAL;
using IK.DOMAIN;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IK.SERVICE
{
    public class KullaniciService
    {
        private KullaniciDAO kullaniciDAO = new KullaniciDAO();

        public List<Kullanici> GetAllKullanici()
        {
            try
            {
                return kullaniciDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcılar alınırken bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Kullanici>();
            }
        }

        public string AddKullanici(Kullanici k)
        {
            if (string.IsNullOrWhiteSpace(k.Kullanici_Adi))
                return "Kullanıcı adı boş olamaz.";

            if (string.IsNullOrWhiteSpace(k.Sifre))
                return "Şifre boş olamaz.";

            try
            {
                if (k.Olusturulma_Tarihi == DateTime.MinValue)
                    k.Olusturulma_Tarihi = DateTime.Now;

                kullaniciDAO.AddKullanici(k);
                return "Kullanıcı başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdateKullanici(Kullanici k)
        {
            if (k.K_Id <= 0)
                return "Geçerli bir kullanıcı ID'si belirtilmeli.";

            if (string.IsNullOrWhiteSpace(k.Kullanici_Adi))
                return "Kullanıcı adı boş olamaz.";

            if (string.IsNullOrWhiteSpace(k.Sifre))
                return "Şifre boş olamaz.";

            try
            {
                kullaniciDAO.UpdateKullanici(k);
                return "Kullanıcı başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteKullanici(int kullaniciId)
        {
            if (kullaniciId <= 0)
                return "Geçerli bir kullanıcı ID'si belirtilmeli.";

            try
            {
                kullaniciDAO.DeleteKullanici(kullaniciId);
                return "Kullanıcı başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public Kullanici Login(string kullaniciAdi, string sifre, out string mesaj)
        {
            mesaj = "";

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                mesaj = "Kullanıcı adı ve şifre boş olamaz.";
                return null;
            }

            try
            {
                var k = kullaniciDAO.Login(kullaniciAdi, sifre);
                if (k == null)
                {
                    mesaj = "Kullanıcı adı veya şifre hatalı.";
                }
                else
                {
                    mesaj = "Giriş başarılı.";
                }

                return k;
            }
            catch (Exception ex)
            {
                mesaj = $"Hata: {ex.Message}";
                return null;
            }
        }
    }
}

