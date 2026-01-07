using IK.DAL;
using IK.DOMAIN;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IK.SERVICE
{
    public class DepartmanService
    {
        private DepartmanDAO departmanDAO = new DepartmanDAO();

        public List<departman> GetAllDepartman()
        {
            try
            {
                return departmanDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Departmanlar alınırken bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<departman>();
            }
        }

        public string AddDepartman(departman d)
        {
            if (string.IsNullOrWhiteSpace(d.DepartmanAdi))
                return "Departman adı boş olamaz.";

            try
            {
                departmanDAO.AddDepartman(d);
                return "Departman başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdateDepartman(departman d)
        {
            if (d.Departman_Id <= 0)
                return "Geçerli bir departman ID'si belirtilmeli.";

            if (string.IsNullOrWhiteSpace(d.DepartmanAdi))
                return "Departman adı boş olamaz.";

            try
            {
                departmanDAO.UpdateDepartman(d);
                return "Departman başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteDepartman(int departmanId)
        {
            if (departmanId <= 0)
                return "Geçerli bir departman ID'si belirtilmeli.";

            try
            {
                departmanDAO.DeleteDepartman(departmanId);
                return "Departman başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
