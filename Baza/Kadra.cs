using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class Kadra
    {
        public int ID_Druzyny { get; set; }
        public int ID_Zawodnika { get; set; }
        public int Numer_Koszulki { get; set; }
        public int Pozycja { get; set; }
        public string Data_P { get; set; }
        public string Data_K { get; set; }
        public int Is_Current { get; set; }

    }
}
