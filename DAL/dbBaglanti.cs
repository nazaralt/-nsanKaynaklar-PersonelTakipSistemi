using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IK.DAL
{
    public class dbBaglanti
    {
        private string connectionString =
            "Server=172.21.54.253; Database=26_132330048; Uid=26_132330048; Pwd=İnif123.;";

        public MySqlConnection baglantiGetir()
        {
            return new MySqlConnection(connectionString); // ❗ SADECE OLUŞTUR
        }
    


        public void BaglantiKapat(MySqlConnection baglanti)
        {
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
            }
        }
    }
}