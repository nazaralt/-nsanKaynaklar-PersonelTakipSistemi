using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IK.DOMAIN
{
    public class DetayliRaporDTO
    {
        public int P_Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string DepartmanAd { get; set; }
        public string Pozisyon { get; set; }
        public decimal Maas { get; set; }
        public int ToplamIzin { get; set; }
        public DateTime? IseBaslangic { get; set; }
    }
}
