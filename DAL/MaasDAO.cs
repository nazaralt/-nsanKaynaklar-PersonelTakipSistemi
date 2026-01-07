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
    public class MaasDAO
    {
        dbBaglanti db = new dbBaglanti();

        public List<Maas> GetAll()
        {
            List<Maas> maaslar = new List<Maas>();

            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Maas"; // tablo adı
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        maaslar.Add(new Maas
                        {
                            M_Id = int.Parse(reader["M_Id"].ToString()),
                            P_Id = int.Parse(reader["P_Id"].ToString()),
                            M_Yil = int.Parse(reader["M_Yil"].ToString()),
                            M_Ay = int.Parse(reader["M_Ay"].ToString()),
                            M_TabanMaas = Convert.ToDecimal(reader["M_TabanMaas"]),
                            M_Prim = Convert.ToDecimal(reader["M_Prim"]),
                            M_Kesinti = Convert.ToDecimal(reader["M_Kesinti"]),
                            M_NetMaas = Convert.ToDecimal(reader["M_NetMaas"]),
                            M_Olusturulma_Tarihi = Convert.ToDateTime(reader["M_Olusturulma_Tarihi"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Maaş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return maaslar;
        }

        public void AddMaas(Maas m)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = @"INSERT INTO Maas
                                    (P_Id, M_Yil, M_Ay, M_TabanMaas,
                                     M_Prim, M_Kesinti, M_NetMaas, M_Olusturulma_Tarihi)
                                    VALUES
                                    (@PId, @Yil, @Ay, @Taban,
                                     @Prim, @Kesinti, @Net, @Tarih)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@PId", m.P_Id);
                    cmd.Parameters.AddWithValue("@Yil", m.M_Yil);
                    cmd.Parameters.AddWithValue("@Ay", m.M_Ay);
                    cmd.Parameters.AddWithValue("@Taban", m.M_TabanMaas);
                    cmd.Parameters.AddWithValue("@Prim", m.M_Prim);
                    cmd.Parameters.AddWithValue("@Kesinti", m.M_Kesinti);
                    cmd.Parameters.AddWithValue("@Net", m.M_NetMaas);
                    cmd.Parameters.AddWithValue("@Tarih", m.M_Olusturulma_Tarihi);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Maaş SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateMaas(Maas m)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = @"UPDATE Maas SET
                                        P_Id = @PId,
                                        M_Yil = @Yil,
                                        M_Ay = @Ay,
                                        M_TabanMaas = @Taban,
                                        M_Prim = @Prim,
                                        M_Kesinti = @Kesinti,
                                        M_NetMaas = @Net
                                     WHERE M_Id = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", m.M_Id);
                    cmd.Parameters.AddWithValue("@PId", m.P_Id);
                    cmd.Parameters.AddWithValue("@Yil", m.M_Yil);
                    cmd.Parameters.AddWithValue("@Ay", m.M_Ay);
                    cmd.Parameters.AddWithValue("@Taban", m.M_TabanMaas);
                    cmd.Parameters.AddWithValue("@Prim", m.M_Prim);
                    cmd.Parameters.AddWithValue("@Kesinti", m.M_Kesinti);
                    cmd.Parameters.AddWithValue("@Net", m.M_NetMaas);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Maaş SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteMaas(int maasId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM Maas WHERE M_Id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", maasId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Maaş SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
