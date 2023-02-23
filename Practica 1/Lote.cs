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
        public int TT { get; set; }
        public int TTB { get; set; }
        public int Llegada { get; set; }
        public int Espera { get; set; }//Retorno - Ejecucion
        public int Retorno { get; set; } //Finalizacion - Llegada | Tiempo Ejecion + Tiempo de Espera
       
        public int Finalizacion { get; set; }
        public int TRespuesta { get; set; }
        public string operacion { get; set; }
        public float resultado { get; set; }

    }

    public struct lote
    {
        public proceso[] procesos { get; set;}

    }
}
