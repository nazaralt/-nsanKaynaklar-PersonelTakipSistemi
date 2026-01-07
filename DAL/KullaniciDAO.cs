using IK.DOMAIN;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IK.DAL
{
    public class KullaniciDAO
    {
        dbBaglanti db = new dbBaglanti();

        public List<Kullanici> GetAll()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();

            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM kullanici"; // tablo adı
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        kullanicilar.Add(new Kullanici
                        {
                            K_Id = int.Parse(reader["K_Id"].ToString()),
                            Kullanici_Adi = reader["Kullanici_Adi"].ToString(),
                            Sifre = reader["Sifre"].ToString(),
                            Rol_Id = int.Parse(reader["Rol_Id"].ToString()),
                            P_Id = reader["P_Id"] == DBNull.Value ? (int?)null : int.Parse(reader["P_Id"].ToString()),
                            Olusturulma_Tarihi = Convert.ToDateTime(reader["Olusturulma_Tarihi"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Kullanıcı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return kullanicilar;
        }

        public void AddKullanici(Kullanici k)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = @"INSERT INTO kullanici
                                    (Kullanici_Adi, Sifre, Rol_Id, P_Id, Olusturulma_Tarihi)
                                    VALUES (@Adi, @Sifre, @RolId, @PId, @Tarih)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Adi", k.Kullanici_Adi);
                    cmd.Parameters.AddWithValue("@Sifre", k.Sifre);
                    cmd.Parameters.AddWithValue("@RolId", k.Rol_Id);

                    if (k.P_Id.HasValue)
                        cmd.Parameters.AddWithValue("@PId", k.P_Id.Value);
                    else
                        cmd.Parameters.AddWithValue("@PId", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Tarih", k.Olusturulma_Tarihi);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Kullanıcı SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateKullanici(Kullanici k)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = @"UPDATE kullanici SET
                                        Kullanici_Adi = @Adi,
                                        Sifre = @Sifre,
                                        Rol_Id = @RolId,
                                        P_Id = @PId
                                     WHERE K_Id = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", k.K_Id);
                    cmd.Parameters.AddWithValue("@Adi", k.Kullanici_Adi);
                    cmd.Parameters.AddWithValue("@Sifre", k.Sifre);
                    cmd.Parameters.AddWithValue("@RolId", k.Rol_Id);

                    if (k.P_Id.HasValue)
                        cmd.Parameters.AddWithValue("@PId", k.P_Id.Value);
                    else
                        cmd.Parameters.AddWithValue("@PId", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Kullanıcı SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteKullanici(int kullaniciId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM kullanici WHERE K_Id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", kullaniciId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Kullanıcı SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LOGIN için örnek metot
        public Kullanici Login(string kullaniciAdi, string sifre)
        {
            Kullanici bulunan = null;

            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM kullanici 
                                     WHERE Kullanici_Adi = @Adi AND Sifre = @Sifre";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Adi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        bulunan = new Kullanici
                        {
                            K_Id = int.Parse(reader["K_Id"].ToString()),
                            Kullanici_Adi = reader["Kullanici_Adi"].ToString(),
                            Sifre = reader["Sifre"].ToString(),
                            Rol_Id = int.Parse(reader["Rol_Id"].ToString()),
                            P_Id = reader["P_Id"] == DBNull.Value ? (int?)null : int.Parse(reader["P_Id"].ToString()),
                            Olusturulma_Tarihi = Convert.ToDateTime(reader["Olusturulma_Tarihi"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Login SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return bulunan;
        }
    }
}
