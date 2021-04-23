using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class Zawodnik
    {
        public int ID { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Data_Urodzenia { get; set; }

        public string Druzyny
        {
            get
            {
                return $"{ Nazwisko }";
            }
        }
    }
}
