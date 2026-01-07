using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IK.DAL;
using IK.DOMAIN;

using System.Windows.Forms;

namespace IK.SERVICE
{
    public class PersonelService
    {
        private PersonelDAO personelDAO = new PersonelDAO();

        public List<Personel> GetAllPersonel()
        {
            try
            {
                return personelDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Personeller alınırken bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Personel>();
            }
        }

        public string AddPersonel(Personel p)
        {
            if (string.IsNullOrWhiteSpace(p.P_Ad) || string.IsNullOrWhiteSpace(p.P_Soyad))
                return "Personel adı ve soyadı boş olamaz.";

            try
            {
                personelDAO.AddPersonel(p);
                return "Personel başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdatePersonel(Personel p)
        {
            if (p.P_Id <= 0)
                return "Geçerli bir personel ID'si belirtilmeli.";

            if (string.IsNullOrWhiteSpace(p.P_Ad) || string.IsNullOrWhiteSpace(p.P_Soyad))
                return "Personel adı ve soyadı boş olamaz.";

            try
            {
                personelDAO.UpdatePersonel(p);
                return "Personel başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeletePersonel(int personelId)
        {
            if (personelId <= 0)
                return "Geçerli bir personel ID'si belirtilmeli.";

            try
            {
                personelDAO.DeletePersonel(personelId);
                return "Personel başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
