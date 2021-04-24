using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class Test
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int Numer_Koszulki { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Pozycja { get; set; }
        public string Kapitan { get; set; }
        public string Rezerwowy { get; set; }

        public string Testowy
        {
            get
            {
                return $"{ Nazwisko } { Imie } { Pozycja } { Numer_Koszulki } { Kapitan } { Rezerwowy }";
            }
        }
    }
}
