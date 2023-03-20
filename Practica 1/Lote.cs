using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public byte libres { get; private set; }

        private byte actual;
        public Memoria() 
        {
            frames = new Frame[40].ToList();
            for (int i = 0; i < 40; i++)
                frames[i] = new Frame();

            frames[39].espacio = 5;
            frames[38].espacio = 5;

            frames[39].uso = "Sistema Operativo";
            frames[38].uso = "Sistema Operativo";

            frames[39].used = true;
            frames[38].used = true;

            libres = 38;
        }

        public int[]? Addprocess(proceso p) 
        {
            
            if (libres < (int)(p.size / 5) + (p.size % 5 > 0? 1 : 0))
                return null;

            Frame frame;
            byte size = p.size;
            List<int> usedFrames = new List<int>();
            while (size > 0)
            {
                frame = nextFrame();
                if (frame.used)
                    continue;

                libres--;
                frame.used = true;
                
                if (size > 5)
                {
                    size -= 5;
                    frame.espacio = 5;  
                }
                else
                {
                    frame.espacio = size;
                    size = 0;
                }

                frame.uso = p;
                usedFrames.Add(frames.IndexOf(frame));
            }
            
            return usedFrames.ToArray();
        }

        private Frame nextFrame()
        {
            if (actual == 40)
                actual = 0;
            return frames[actual++];
        }

        public int[]? RemoveProcess(proceso p) 
        {
            List<int> wipedFrames = new List<int>();
            
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].uso != p)
                    continue;
                i = frames.IndexOf(frames[i]);
                wipedFrames.Add(i);
                frames[i] = new Frame();
                libres++;
            }

            if (wipedFrames.Count == 0)
                return null;
            return wipedFrames.ToArray();
        }
    }
    public class Frame 
    {
        public byte espacio { get; set; }
        public object uso { get; set; }
        public bool used { get; set; }

        public Frame() 
        {
        }
    }
        
    public static class Disco 
    {
        public static string FilePath;

        public static void Add(proceso proceso)
        {
            if (!File.Exists(FilePath)) 
                File.Create(FilePath).Close();
                
            
            var Json = System.Text.Json.JsonSerializer.Serialize(proceso);
            var file = File.AppendText(FilePath);
            file.WriteLine(Json);
            file.Close();
            
        }

        public static void DequeFile()
        {
            if (!File.Exists(FilePath))
                return;

            var lines = File.ReadAllLines(FilePath);
            File.WriteAllLines(FilePath, lines.Skip(1).ToArray());

        }

        public static void ResetFile()
        {
            if (!File.Exists(FilePath))
                return;

            
            File.Delete(FilePath);
            File.Create(FilePath).Close();

        }

        public static proceso? PeekFile() 
        {
            if (!File.Exists(FilePath))
                return null;

            using (StreamReader file = new StreamReader(FilePath))
            {
                string? json = file.ReadLine();
                if (json == null)
                    return null;
                
                return System.Text.Json.JsonSerializer.Deserialize<proceso>(json);
            }
        }    

    }
}
