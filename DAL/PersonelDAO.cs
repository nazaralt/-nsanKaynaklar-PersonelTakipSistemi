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
    public class PersonelDAO
    {
        dbBaglanti db = new dbBaglanti();

        
        public List<Personel> GetAll()
        {
            List<Personel> personeller = new List<Personel>();

            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM employees";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        personeller.Add(new Personel
                        {
                            P_Id = int.Parse(reader["P_Id"].ToString()),
                            P_Ad = reader["P_Ad"].ToString(),
                            P_Soyad = reader["P_Soyad"].ToString(),
                            P_TcNo = reader["P_TcNo"] == DBNull.Value ? null : reader["P_TcNo"].ToString(),
                            P_Email = reader["P_Email"] == DBNull.Value ? null : reader["P_Email"].ToString(),
                            P_Tel = reader["P_Tel"] == DBNull.Value ? null : reader["P_Tel"].ToString(),
                            P_DogumTarih = reader["P_DogumTarih"] == DBNull.Value
                                           ? (DateTime?)null
                                           : Convert.ToDateTime(reader["P_DogumTarih"]),
                            P_IseBaslangic = reader["P_İseBaslangic"] == DBNull.Value
                                             ? (DateTime?)null
                                             : Convert.ToDateTime(reader["P_İseBaslangic"]),
                            DepartmentId = reader["DepartmentId"] == DBNull.Value
                                           ? (int?)null
                                           : int.Parse(reader["DepartmentId"].ToString()),
                            P_Position = reader["P_Position"] == DBNull.Value ? null : reader["P_Position"].ToString(),
                            P_TMaas = reader["P_TMaas"] == DBNull.Value
                                      ? (decimal?)null
                                      : Convert.ToDecimal(reader["P_TMaas"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return personeller;
        }

        // EKLE
        public void AddPersonel(Personel p)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = @"INSERT INTO employees
                                    (P_Ad, P_Soyad, P_TcNo, P_Email, P_Tel,
                                     P_DogumTarih, P_IseBaslangic, DepartmentId,
                                     P_Position, P_TMaas)
                                     VALUES
                                    (@Ad, @Soyad, @TcNo, @Email, @Tel,
                                     @DogumTarih, @IseBaslangic, @DepartmentId,
                                     @Position, @TMaas)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Ad", p.P_Ad);
                    cmd.Parameters.AddWithValue("@Soyad", p.P_Soyad);

                    // string alanlar
                    if (p.P_TcNo == null)
                        cmd.Parameters.AddWithValue("@TcNo", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@TcNo", p.P_TcNo);

                    if (p.P_Email == null)
                        cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Email", p.P_Email);

                    if (p.P_Tel == null)
                        cmd.Parameters.AddWithValue("@Tel", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Tel", p.P_Tel);

                    // tarih alanları
                    if (p.P_DogumTarih.HasValue)
                        cmd.Parameters.AddWithValue("@DogumTarih", p.P_DogumTarih.Value);
                    else
                        cmd.Parameters.AddWithValue("@DogumTarih", DBNull.Value);

                    if (p.P_IseBaslangic.HasValue)
                        cmd.Parameters.AddWithValue("@IseBaslangic", p.P_IseBaslangic.Value);
                    else
                        cmd.Parameters.AddWithValue("@IseBaslangic", DBNull.Value);

                    // int? DepartmentId
                    if (p.DepartmentId.HasValue)
                        cmd.Parameters.AddWithValue("@DepartmentId", p.DepartmentId.Value);
                    else
                        cmd.Parameters.AddWithValue("@DepartmentId", DBNull.Value);

                    // pozisyon
                    if (p.P_Position == null)
                        cmd.Parameters.AddWithValue("@Position", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Position", p.P_Position);

                    // decimal? maaş
                    if (p.P_TMaas.HasValue)
                        cmd.Parameters.AddWithValue("@TMaas", p.P_TMaas.Value);
                    else
                        cmd.Parameters.AddWithValue("@TMaas", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // GÜNCELLE
        public void UpdatePersonel(Personel p)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = @"UPDATE employees SET
                                        P_Ad = @Ad,
                                        P_Soyad = @Soyad,
                                        P_TcNo = @TcNo,
                                        P_Email = @Email,
                                        P_Tel = @Tel,
                                        P_DogumTarih = @DogumTarih,
                                        P_IseBaslangic = @IseBaslangic,
                                        DepartmentId = @DepartmentId,
                                        P_Position = @Position,
                                        P_TMaas = @TMaas
                                     WHERE P_Id = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", p.P_Id);
                    cmd.Parameters.AddWithValue("@Ad", p.P_Ad);
                    cmd.Parameters.AddWithValue("@Soyad", p.P_Soyad);

                    // string alanlar
                    if (p.P_TcNo == null)
                        cmd.Parameters.AddWithValue("@TcNo", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@TcNo", p.P_TcNo);

                    if (p.P_Email == null)
                        cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Email", p.P_Email);

                    if (p.P_Tel == null)
                        cmd.Parameters.AddWithValue("@Tel", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Tel", p.P_Tel);

                    // tarih alanları
                    if (p.P_DogumTarih.HasValue)
                        cmd.Parameters.AddWithValue("@DogumTarih", p.P_DogumTarih.Value);
                    else
                        cmd.Parameters.AddWithValue("@DogumTarih", DBNull.Value);

                    if (p.P_IseBaslangic.HasValue)
                        cmd.Parameters.AddWithValue("@IseBaslangic", p.P_IseBaslangic.Value);
                    else
                        cmd.Parameters.AddWithValue("@IseBaslangic", DBNull.Value);

                    // int? DepartmentId
                    if (p.DepartmentId.HasValue)
                        cmd.Parameters.AddWithValue("@DepartmentId", p.DepartmentId.Value);
                    else
                        cmd.Parameters.AddWithValue("@DepartmentId", DBNull.Value);

                    // pozisyon
                    if (p.P_Position == null)
                        cmd.Parameters.AddWithValue("@Position", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Position", p.P_Position);

                    // decimal? maaş
                    if (p.P_TMaas.HasValue)
                        cmd.Parameters.AddWithValue("@TMaas", p.P_TMaas.Value);
                    else
                        cmd.Parameters.AddWithValue("@TMaas", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SİL
        public void DeletePersonel(int personelId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM employees WHERE P_Id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", personelId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}