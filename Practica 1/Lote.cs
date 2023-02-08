using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public struct proceso
    {
        public string nombre { get; set; }
        public  int id { get; set; }
        public int TME { get; set; }
        public string operacion { get; set; }
        public float resultado { get; set; }
        
    }
    public struct lote
    {
        public proceso[] procesos { get; set;}

    }
}
