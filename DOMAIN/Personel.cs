using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IK.DOMAIN
{
    public class Personel
    {
        public int P_Id { get; set; }
        public string P_Ad { get; set; }
        public string P_Soyad { get; set; }
        public string P_TcNo { get; set; }
        public string P_Email { get; set; }
        public string P_Tel { get; set; }

        public DateTime? P_DogumTarih { get; set; }
        public DateTime? P_IseBaslangic { get; set; }

        public int? DepartmentId { get; set; }   // Departman_Id ile ilişkili
        public string P_Position { get; set; }
        public decimal? P_TMaas { get; set; }
    }
}
