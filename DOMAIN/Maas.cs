using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IK.DOMAIN
{
    public class Maas
    {
        public int M_Id { get; set; }
        public int P_Id { get; set; }             

        public int M_Yil { get; set; }
        public int M_Ay { get; set; }

        public decimal M_TabanMaas { get; set; }
        public decimal M_Prim { get; set; }
        public decimal M_Kesinti { get; set; }
        public decimal M_NetMaas { get; set; }

        public DateTime M_Olusturulma_Tarihi { get; set; }
    }
}

