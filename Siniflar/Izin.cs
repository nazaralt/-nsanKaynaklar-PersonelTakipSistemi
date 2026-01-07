using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IK.Siniflar
{
    public class Izin
    {
        public int I_Id { get; set; }
        public int P_Id { get; set; }               

        public string IzinTuru { get; set; }
        public DateTime IzinBas { get; set; }
        public DateTime IzinBit { get; set; }
        public int TotalIzin { get; set; }

        public string Durum { get; set; }            
        public string Aciklama { get; set; }

        public int? ApprovedByK_Id { get; set; }    
        public DateTime Olusturulma_Tarihi { get; set; }
    }
}
