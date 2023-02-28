using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
    public class proceso
    {
        public int id { get; set; }
        public int TME { get; set; }
        public int TT { get; set; }
        public int TTB { get; set; }
        public int Llegada { get; set; }
        public int Espera { get; set; }//Retorno - Ejecucion
        public int Retorno { get; set; } //Finalizacion - Llegada | Tiempo Ejecucion + Tiempo de Espera

        public int Finalizacion { get; set; }
        public int TRespuesta { get; set; }
        public string operacion { get; set; }
        public float resultado { get; set; }
        public byte size { get; set; }
    }

    public class Memoria
    {
        public List<Frame> frames { get; private set; }
        public byte libres { get; }

        private byte actual;
        public Memoria() 
        { 
            List<Frame> frames = new List<Frame>(40);

            frames[39].espacio = 5;
            frames[38].espacio = 5;

            frames[39].uso = "Sistema Operativo";
            frames[38].uso = "Sistema Operativo";

            frames[39].avalible = false;
            frames[38].avalible = false;


            libres = 38;

        }

        bool Addprocess(proceso p) 
        {
            if (libres < (int)(p.size / 5))
                return false;

            while (p.size == 0)
            {

            }


            return true;
        }
                



    }
    public class Frame 
    {
        public byte espacio { get; set; }
        public object uso { get; set; }
        public bool avalible { get; set; } 
    }

}
