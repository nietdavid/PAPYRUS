using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPYRUS.Models
{
    public class Entcom
    {
        public int Numcom { get; set; }
        public string Obscom { get; set; }
        public DateTime Datcom { get; set; }
        public int Numfou { get; set; }

        public Entcom(int numcom, string obscom, DateTime datcom, int numfou)
        {
            Numcom = numcom;
            Obscom = obscom;
            Datcom = datcom;
            Numfou = numfou;
        }
    }
}

