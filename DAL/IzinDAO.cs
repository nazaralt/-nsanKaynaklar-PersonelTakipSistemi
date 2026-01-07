using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using IK.DOMAIN;

namespace IK.DAL
{
    public class IzinDAO
    {
        dbBaglanti db = new dbBaglanti();

        // 1) TÜM İZİNLER (YÖNETİCİ / İK GÖRÜR)
        public List<Izin> GetAll()
        {
            List<Izin> izinler = new List<Izin>();

            using (MySqlConnection conn = db.baglantiGetir())
            {
                conn.Open();
                string query = @"SELECT 
                            i.I_Id,
                            i.P_Id,
                            e.P_Ad,
                            e.P_Soyad,
                            i.IzinBas,
                            i.IzinBit,
                            i.IzinTuru,
                            i.TotalIzin,
                            i.Aciklama,
                            i.ApprovedByK_Id,
                            i.Olusturulma_Tarihi,
                            i.Durum
                         FROM izinler i
                         INNER JOIN employees e ON i.P_Id = e.P_Id"; ;

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    izinler.Add(MapIzin(dr));
                }
            }

            return izinler;
        }

        // 2) PERSONELE GÖRE İZİN GETİR
        public List<Izin> GetByPersonel(int pId)
        {
            List<Izin> izinler = new List<Izin>();

            using (MySqlConnection conn = db.baglantiGetir())
            {
                conn.Open();
                string query = "SELECT * FROM izinler WHERE P_Id = @P_Id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@P_Id", pId);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    izinler.Add(MapIzin(dr));
                }
            }

            return izinler;
        }

        // 3) YENİ İZİN EKLE
        public void AddIzin(Izin i)
        {
            using (MySqlConnection conn = db.baglantiGetir())
            {
                conn.Open();

                string query = @"INSERT INTO izinler 
                                (P_Id, IzinTuru, IzinBas, IzinBit, TotalIzin, Durum, Aciklama)
                                VALUES 
                                (@P_Id, @IzinTuru, @IzinBas, @IzinBit, @TotalIzin, @Durum, @Aciklama)";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@P_Id", i.P_Id);
                cmd.Parameters.AddWithValue("@IzinTuru", i.IzinTuru);
                cmd.Parameters.AddWithValue("@IzinBas", i.IzinBas);
                cmd.Parameters.AddWithValue("@IzinBit", i.IzinBit);
                cmd.Parameters.AddWithValue("@TotalIzin", i.TotalIzin);
                cmd.Parameters.AddWithValue("@Durum", "Beklemede");
                cmd.Parameters.AddWithValue("@Aciklama", i.Aciklama);

                cmd.ExecuteNonQuery();
            }
        }

        // 4) DURUM GÜNCELLE (ONAY / RED)
        public void UpdateDurum(int izinId, string durum, int onaylayanKId)
        {
            using (MySqlConnection conn = db.baglantiGetir())
            {
                conn.Open();

                string query = @"UPDATE izinler 
                                 SET Durum = @Durum, ApprovedByK_Id = @K_Id 
                                 WHERE I_Id = @I_Id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Durum", durum);
                cmd.Parameters.AddWithValue("@K_Id", onaylayanKId);
                cmd.Parameters.AddWithValue("@I_Id", izinId);

                cmd.ExecuteNonQuery();
            }
        }

        // 5) İZİN SİL
        public void DeleteIzin(int izinId)
        {
            using (MySqlConnection conn = db.baglantiGetir())
            {
                conn.Open();

                string query = "DELETE FROM izinler WHERE I_Id = @I_Id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@I_Id", izinId);
                cmd.ExecuteNonQuery();
            }
        }

        // -- Map fonksiyonu: DR → Izin nesnesi dönüştürücü
        public Izin MapIzin(MySqlDataReader dr)
        {
            return new Izin
            {
                I_Id = Convert.ToInt32(dr["I_Id"]),
                P_Id = Convert.ToInt32(dr["P_Id"]),
                IzinTuru = dr["IzinTuru"].ToString(),
                IzinBas = Convert.ToDateTime(dr["IzinBas"]),
                IzinBit = Convert.ToDateTime(dr["IzinBit"]),
                TotalIzin = Convert.ToInt32(dr["TotalIzin"]),
                Durum = dr["Durum"].ToString(),
                Aciklama = dr["Aciklama"] != DBNull.Value ? dr["Aciklama"].ToString() : "",
                ApprovedByK_Id = dr["ApprovedByK_Id"] != DBNull.Value ? Convert.ToInt32(dr["ApprovedByK_Id"]) : 0
            };
        }
    }
}
