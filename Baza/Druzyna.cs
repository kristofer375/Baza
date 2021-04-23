using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class Druzyna
    {
        public int ID { get; set; }
        public int ID_Kluby { get; set; }
        public string Nazwa { get; set; }
        public string Liga { get; set; }

        public string Druzyny
        {
            get
            {
                return $"{ Nazwa }";
            }
        }
    }
}
