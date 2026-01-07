using IK.DAL;
using IK.DOMAIN;
using System;
using System.Collections.Generic;

namespace IK.SERVICE
{
    public class IzinService
    {
        private readonly IzinDAO _izinDAO = new IzinDAO();

        public List<Izin> GetIzinlerForAdmin()
        {
            return _izinDAO.GetAll();
        }

        public List<Izin> GetIzinlerForPersonel(int pId)
        {
            return _izinDAO.GetByPersonel(pId);
        }

        public string AddIzin(Izin izin)
        {
            try
            {
                if (izin.IzinBas.Date > izin.IzinBit.Date)
                    return "İzin başlangıç tarihi bitiş tarihinden büyük olamaz.";

                if (izin.TotalIzin <= 0)
                    return "Toplam izin günü 0 olamaz.";

                _izinDAO.AddIzin(izin);
                return "İzin talebi başarıyla oluşturuldu.";
            }
            catch (Exception ex)
            {
                return $"İzin eklenirken hata: {ex.Message}";
            }
        }

        public string OnaylaIzin(int izinId, int onaylayanKId)
        {
            try
            {
                _izinDAO.UpdateDurum(izinId, "Onaylandi", onaylayanKId);
                return "İzin talebi onaylandı.";
            }
            catch (Exception ex)
            {
                return $"Onay sırasında hata: {ex.Message}";
            }
        }

        public string ReddetIzin(int izinId, int onaylayanKId)
        {
            try
            {
                _izinDAO.UpdateDurum(izinId, "Reddedildi", onaylayanKId);
                return "İzin talebi reddedildi.";
            }
            catch (Exception ex)
            {
                return $"Red sırasında hata: {ex.Message}";
            }
        }

        public string DeleteIzin(int izinId)
        {
            try
            {
                _izinDAO.DeleteIzin(izinId);
                return "İzin talebi silindi.";
            }
            catch (Exception ex)
            {
                return $"İzin silinirken hata: {ex.Message}";
            }
        }
    }
}
