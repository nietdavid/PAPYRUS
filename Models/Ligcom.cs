using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPYRUS.Models
{
    public class Ligcom
        {
            public int Numcom { get; set; }
            public string Codart { get; set; }
            public byte Numlig { get; set; }
            public short Qteced { get; set; }
            public decimal Priuni { get; set; }
            public short Qteliv { get; set; }
            public DateTime Derliv { get; set; }

            public Ligcom(int numcom, string codart, byte numlig, short qteced, decimal priuni, short qteliv, DateTime derliv)
            {
                Numcom = numcom;
                Codart = codart;
                Numlig = numlig;
                Qteced = qteced;
                Priuni = priuni;
                Qteliv = qteliv;
                Derliv = derliv;
            }
    }
}
