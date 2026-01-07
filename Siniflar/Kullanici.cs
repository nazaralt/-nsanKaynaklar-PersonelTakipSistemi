using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IK.Siniflar
{
    public class Kullanici
    {
        public int K_Id { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Sifre { get; set; }

        public int Rol_Id { get; set; }      
        public int? P_Id { get; set; }       

        public DateTime Olusturulma_Tarihi { get; set; }
    }
}
