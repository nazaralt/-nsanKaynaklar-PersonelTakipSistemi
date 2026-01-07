using IK.DAL;
using IK.DOMAIN;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IK.SERVICE
{
    public class RolService
    {
        private RolDAO rolDAO = new RolDAO();

        public List<Rol> GetAllRol()
        {
            try
            {
                return rolDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Roller alınırken bir hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Rol>();
            }
        }

        public string AddRol(Rol r)
        {
            if (string.IsNullOrWhiteSpace(r.Kullanici_Rolu))
                return "Rol adı boş olamaz.";

            try
            {
                rolDAO.AddRol(r);
                return "Rol başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdateRol(Rol r)
        {
            if (r.Rol_Id <= 0)
                return "Geçerli bir rol ID'si belirtilmeli.";

            if (string.IsNullOrWhiteSpace(r.Kullanici_Rolu))
                return "Rol adı boş olamaz.";

            try
            {
                rolDAO.UpdateRol(r);
                return "Rol başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteRol(int rolId)
        {
            if (rolId <= 0)
                return "Geçerli bir rol ID'si belirtilmeli.";

            try
            {
                rolDAO.DeleteRol(rolId);
                return "Rol başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}

