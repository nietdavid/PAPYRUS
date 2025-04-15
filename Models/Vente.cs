using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPYRUS.Models
{
    public class Vente
    {
            public string Codart { get; set; } = "";
            public int Numfou { get; set; }
            public short Delliv { get; set; }
            public short Qte1 { get; set; }
            public decimal? Prix1 { get; set; }
            public short? Qte2 { get; set; }
            public decimal? Prix2 { get; set; }
            public short? Qte3 { get; set; }
            public decimal? Prix3 { get; set; }

            public Vente(string codart, int numfou, short delliv, short qte1, decimal? prix1, short? qte2, decimal? prix2, short? qte3, decimal? prix3)
            {
                Codart = codart;
                Numfou = numfou;
                Delliv = delliv;
                Qte1 = qte1;
                Prix1 = prix1;
                Qte2 = qte2;
                Prix2 = prix2;
                Qte3 = qte3;
                Prix3 = prix3;
            }
            public Vente() 
            {
            }
    }
    
}
