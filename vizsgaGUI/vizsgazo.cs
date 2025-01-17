using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsgaGUI
{
    internal class vizsgazo
    {
        public string Nev { get; set; }
        public double ITesHalozatokIrasbeli { get; set; }
        public double ProgramozasIrasbeli { get; set; }
        public double HalozatokA { get; set; }
        public double HalozatokB { get; set; }
        public double HalozatokC { get; set; }
        public double HalozatokD { get; set; }
        public double SzobeliAngol { get; set; }
        public double SzobeliIT { get; set; }

        public List<double> Modulok { get; set; }

        public double vegeredmeny {
            get { return Modulok.Average(); }
        }

        public string erdemjegy(List<double> Modulok)
        {
            if (Modulok.Exists(m => m * 100 < 51))
            {
                return "elégtelen";
            }
            else
            {
                var atlagEredmeny = Modulok.Average() * 100;
                if (atlagEredmeny < 61)
                {
                    return "elégséges";
                }
                else if (atlagEredmeny < 71)
                {
                    return "közepes";
                }
                else if (atlagEredmeny < 81)
                {
                    return "jó";
                }
                else
                {
                    return "jeles";
                }
            }
        }

        public vizsgazo(string sor)
        {
            var x = sor.Split(';');
            Nev = x[0];
            ITesHalozatokIrasbeli = double.Parse(x[1]);
            ProgramozasIrasbeli = double.Parse(x[2]);
            HalozatokA = double.Parse(x[3]);
            HalozatokB = double.Parse(x[4]);
            HalozatokC = double.Parse(x[5]);
            HalozatokD = double.Parse(x[6]);
            SzobeliAngol = double.Parse(x[7]);
            SzobeliIT = double.Parse(x[8]);
            Modulok = new List<double>();
            for (int i = 1; i < 9; i++)
            {
                Modulok.Add(double.Parse(x[i]));
            }
        }

        
    }
}
