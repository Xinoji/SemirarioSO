using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class proceso
    {
        public  int id { get; set; }
        public int TME { get; set; }
        public int TR { get; set; }
        public string operacion { get; set; }
        public float resultado { get; set; }
        public bool terminado { get; set; }

        public proceso() 
        {
            terminado = true;
        }
    }

    public struct lote
    {
        public proceso[] procesos { get; set;}

    }
}
