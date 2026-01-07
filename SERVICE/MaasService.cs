using IK.DAL;
using IK.DOMAIN;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IK.SERVICE
{
    public class MaasService
    {
        private MaasDAO maasDAO = new MaasDAO();

        public List<Maas> GetAllMaas()
        {
            try
            {
                return maasDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Maaşlar alınırken bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Maas>();
            }
        }

        public string AddMaas(Maas m)
        {
            if (m.P_Id <= 0)
                return "Geçerli bir personel seçilmelidir.";

            if (m.M_Yil <= 0 || m.M_Ay <= 0 || m.M_Ay > 12)
                return "Geçerli bir yıl ve ay girilmelidir.";

            if (m.M_TabanMaas <= 0)
                return "Taban maaş sıfırdan büyük olmalıdır.";

            // Net maaşı istersen burada hesaplayabilirsin:
            m.M_NetMaas = m.M_TabanMaas + m.M_Prim - m.M_Kesinti;

            try
            {
                if (m.M_Olusturulma_Tarihi == DateTime.MinValue)
                    m.M_Olusturulma_Tarihi = DateTime.Now;

                maasDAO.AddMaas(m);
                return "Maaş kaydı başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdateMaas(Maas m)
        {
            if (m.M_Id <= 0)
                return "Geçerli bir maaş ID'si belirtilmeli.";

            if (m.M_Yil <= 0 || m.M_Ay <= 0 || m.M_Ay > 12)
                return "Geçerli bir yıl ve ay girilmelidir.";

            if (m.M_TabanMaas <= 0)
                return "Taban maaş sıfırdan büyük olmalıdır.";

            m.M_NetMaas = m.M_TabanMaas + m.M_Prim - m.M_Kesinti;

            try
            {
                maasDAO.UpdateMaas(m);
                return "Maaş kaydı başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteMaas(int maasId)
        {
            if (maasId <= 0)
                return "Geçerli bir maaş ID'si belirtilmeli.";

            try
            {
                maasDAO.DeleteMaas(maasId);
                return "Maaş kaydı başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
