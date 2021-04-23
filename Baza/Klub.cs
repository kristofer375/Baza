using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class Klub
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Ikona { get; set; }
        public string Skrot { get; set; }

        public string Kluby
        {
            get
            {
                return $"{ Nazwa } { Skrot }";
            }
        }
    }
}
