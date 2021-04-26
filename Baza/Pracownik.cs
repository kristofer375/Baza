using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class Pracownik
    {
        public int ID { get; set; }
        public int ID_Kluby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }

        public string Pracownicy
        {
            get
            {
                return $"{ Nazwisko } { Imie }";
            }
        }
    }
}
