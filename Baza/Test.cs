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
        public int ID_Pozycja { get; set; }
        public string Nazwa { get; set; }
        public int Numer_Koszulki { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Pozycja { get; set; }
        public string Kapitan { get; set; }
        public bool CzyKapitan { get; set; }
        public string Rezerwowy { get; set; }
        public bool CzyRezerwowy { get; set; }
        public bool CzyGra { get; set; }

        public string Testowy1
        {
            get
            {
                return $"{ Nazwisko } { Imie }";
            }
        }
        public string Testowy2
        {
            get
            {
                return $"{ Numer_Koszulki } { Nazwisko } { Imie } { Pozycja } { Kapitan } { Rezerwowy }";
            }
        }
    }
}
