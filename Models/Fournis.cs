using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAPYRUS.Models
{
    public class Fournis
        {
            public int Numfou { get; set; }
            public string Nomfou { get; set; }
            public string Ruefou { get; set; }
            public string Posfou { get; set; }
            public string Vilfou { get; set; }
            public string Confou { get; set; }
            public byte? Satisf { get; set; }

            public Fournis(int numfou, string nomfou, string ruefou, string posfou, string vilfou, string confou, byte? satisf)
            {
                Numfou = numfou;
                Nomfou = nomfou;
                Ruefou = ruefou;
                Posfou = posfou;
                Vilfou = vilfou;
                Confou = confou;
                Satisf = satisf;
            }
        }
}
