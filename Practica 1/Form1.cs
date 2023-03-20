using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practica_1
{
    public partial class Form1 : Form
    {
        #region atributos
        (int actual, int total) time;
        int tm;
        int Quantum;
        List<int> id;
        List<proceso> Listos;
        proceso Ejecucion;
        List<proceso> Bloqueados;
        Queue<proceso> Nuevos;
        Memoria memoria;
        #endregion

        public Form1()
        {
            InitializeComponent();
            Nuevos = new Queue<proceso>();
            Bloqueados = new List<proceso>();
            Listos = new List<proceso>();
            id = new List<int>();
            memoria = new Memoria();
            Disco.FilePath = "Suspendidos.json";
            Disco.ResetFile();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DataGridViewRowCollection Rows = dataGridView1.Rows;
            int row;
            Random nums = new Random();
            char op;
            bool a;

            while (numericUpDown1.Value > Rows.Count)
            {
                switch (nums.Next(0, 5))
                {
                    case 1: op = '+'; break;
                    case 2: op = '-'; break;
                    case 3: op = '*'; break;
                    case 4: op = '/'; break;
                    case 5: op = '%'; break;
                    default: op = '+'; break;
                }

                row = Rows.Add();
                Rows[row].Cells[0].Value = row;
                Rows[row].Cells[1].Value = $"{nums.Next(0, 100)} {op} {nums.Next(0, 100)}";
                Rows[row].Cells[2].Value = nums.Next(5, 16);
                Rows[row].Cells[3].Value = nums.Next(6, 25);
            }

            while (numericUpDown1.Value < dataGridView1.Rows.Count)
                Rows.RemoveAt(Rows.Count - 1);
        

        }

        void createProcess(DataGridViewRow row)
        {
            proceso temp;

            temp = new proceso();
            var cells = row.Cells;

            try
            {
                temp.TME = (int)cells[2].Value;

                if (temp.TME < 1)
                    throw new Exception();

                if (id.Contains((int)cells[0].Value))
                    throw new Exception();

                temp.operacion = (string)cells[1].Value;

                temp.resultado = getOP(temp.operacion);
                temp.size = Convert.ToByte(cells[3].Value);
                temp.id = (int)cells[0].Value;
                tm += temp.TME;
                id.Add((int)cells[0].Value);
                Nuevos.Enqueue(temp);
                AddToBCP(temp);
            }
            catch (Exception)
            {
                reProcess(row);
                createProcess(row);
            }
        }
   
        
        private void reProcess(DataGridViewRow row)
        {
            Random nums = new Random();
            char op;

            switch (nums.Next(0, 5))
            {
                case 1: op = '+'; break;
                case 2: op = '-'; break;
                case 3: op = '*'; break;
                case 4: op = '/'; break;
                case 5: op = '%'; break;
                default: op = '+'; break;
            }

            row.Cells[1].Value = $"{nums.Next(0, 100)} {op} {nums.Next(0, 100)}";
            row.Cells[2].Value = nums.Next(5, 16);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
                createProcess(row);

            if (Nuevos.Count == 0)
                return;

            InitializeFrames();
            panelProcesos.Visible = !panelProcesos.Visible;

            time = (0, 0);

            AddProcess();

            next_process();
            
            updateProcess();

            lblTT.Text = "0";
            lblTranscurrido.Text = "0";
            lblRestante.Text = (Ejecucion.TME - 0).ToString();
            Quantum = (int)numericUpDown2.Value;
            button1.Enabled = false;
            timer1.Start();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            numericUpDown1.Maximum = 999999;
        }

        private void AddProcess() 
        {
            proceso p;
            int[]? frames;
            if (entry.Checked)
            {
                returnProcessToMemory();
            }

            if(Nuevos.Count > 0) 
            {
                if ((frames = memoria.Addprocess(Nuevos.Peek())) == null) 
                    return;

            
                p = Nuevos.Dequeue();
                p.Llegada = time.total;
                Listos.Add(p);
                lblLotes.Text = Nuevos.Count().ToString();
                AddToBCP(p,1);
                dgvProcessAdd(p);
                //agregar a tabla de marcos
                AddtoFrames(frames);
                AddProcess();
            }

        }

        private void InitializeFrames()
        {
            var row = dataGridView6.Rows;
            for (int i = 0; i < 20; i++)
            {
                row.Add();
                row[i].Cells[0].Value = i * 2 + 1;
                row[i].Cells[7].Value = i * 2 + 2;
            }


            var so = dataGridView6.Rows[19];
            so.Cells[1].Value = "SO";
            so.Cells[8].Value = "SO";

            for (int i = 0; i < 5; i++)
                so.Cells[2 + i].Style.BackColor = Color.Black;

            for (int i = 0; i < 5; i++)
                so.Cells[9 + i].Style.BackColor = Color.Black;

        }

        private void AddtoFrames(int[] frames)
        {
            int mod, index;
            foreach (int frame in frames) 
            {
                mod = frame % 2;
                index = (frame - mod) / 2;
                int cell = 1;
                int espacio = memoria.frames[frame].espacio;
                var id = ((proceso)memoria.frames[frame].uso).id;
                dataGridView6.Rows[index].Cells[(mod * 7) + cell++].Value = id;
                while (espacio-- > 0)
                {
                    dataGridView6.Rows[index].Cells[(mod * 7) + cell++].Style.BackColor = Color.Green;
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelProcesar.Visible = !panelProcesar.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool vacio = false;
            countTime();

            if (Ejecucion == null) 
            {
                updateTime(Vacio: true);
                return;
            }
            

            if (Ejecucion.TT == Ejecucion.TME)
            {
                Ejecucion.Finalizacion = time.total;

                addResultado(Ejecucion);

                ProcessEnd();
                
                if (!KeyPreview) 
                    return;

                if (Ejecucion == null)
                    vacio = true;

                updateProcess(vacio);

            }

            if (time.actual == Quantum)
            {
                Listos.Add(Ejecucion);
                dgvProcessAdd(Ejecucion);
                AddToBCP(Ejecucion,1);
                next_process();
                time.actual = 0;
            }

            if (Ejecucion == null)
                vacio = true;
            
            updateTime(vacio);
        }

        private void countTime()
        {
            
            time.total++;
            
            //conteo de bloqueados
            for (int i = 0; i < Listos.Count(); i++)
            {
                Listos[i].Espera++;
                Listos[i].Retorno++;
                dataGridView4.Rows[Listos[i].id].Cells[8].Value = Listos[i].Espera;
            }

            for (int i = 0; i < Bloqueados.Count(); i++)
            {
                Bloqueados[i].TTB++;
                Bloqueados[i].Espera++;
                Bloqueados[i].Retorno++;
                dataGridView5.Rows[i].Cells[1].Value = Bloqueados[i].TTB;
                dataGridView4.Rows[Bloqueados[i].id].Cells[2].Value = 8 - Bloqueados[i].TTB;
                dataGridView4.Rows[Bloqueados[i].id].Cells[8].Value = Bloqueados[i].Espera;

                if (Bloqueados[i].TTB == 8)
                {
                    proceso p = Bloqueados[i];
                    dataGridView5.Rows.RemoveAt(i);
                    Bloqueados.Remove(p);
                    p.TTB = 0;
                    Listos.Add(p);
                    dgvProcessAdd(p);
                    i--;
                    AddToBCP(p,1);
                }

            }

            if (Ejecucion == null)
            {
                next_process();
                tm++;
                return;
            }
            Ejecucion.TT++;
            dataGridView4.Rows[Ejecucion.id].Cells[9].Value = Ejecucion.TT;
            Ejecucion.Retorno++;
            time.actual++;
            if (Ejecucion.TT == 1)
                Ejecucion.TRespuesta = time.total - 1;
            
        }

        private void ProcessEnd()
        {
            if (Ejecucion != null)
                WipeFrames(Ejecucion);

            next_process();   
            
            if (Nuevos.Count > 0 | entry.Checked)
            {
                AddProcess();
            }
            
        }

        private void next_process() 
        {
            if (Listos.Count > 0) 
            {
                
                Ejecucion = Listos.First();
                Listos.RemoveAt(0);
                dataGridView2.Rows.RemoveAt(0);
                AddToBCP(Ejecucion,2);
                updateProcess();
                return;
            }

            Ejecucion = null;
            updateProcess(Vacio: true);

            if (ProcessInMemory() == 0)
                terminar();
        }

        private void WipeFrames(proceso p)
        {
            int mod, index;
            foreach (int frame in memoria.RemoveProcess(p))
            {
                mod = frame % 2;
                index = (frame - mod) / 2;
                int cell = 1;
                int espacio = 5;
                dataGridView6.Rows[index].Cells[(mod * 7) + cell++].Value = null;
                while (espacio-- > 0)
                {
                    dataGridView6.Rows[index].Cells[(mod * 7) + cell++].Style.BackColor = Color.White;
                }

            }
        }
        private void addResultado(proceso p, bool Error = false)
        {
            int i;
            i = dataGridView3.Rows.Add( p.id, 
                                        p.operacion, 
                                        Error ? "Error" : p.resultado);

            AddToBCP(p,Error ? (byte)4 : (byte)5);
                
                
                
        }

        //nuevo - listo - ejecucion - bloqueado - terminadoError - terminadoCorrecto

        /// <sumary>
        ///  Cambia o agrega el estado del BCP
        ///  0 - nuevo 
        ///  1 - listo 
        ///  2 - ejecucion 
        ///  3 - bloqueado 
        ///  4 - terminado por error 
        ///  5 - terminado correctamente 
        ///  6 - suspendido
        /// </sumary>
        void AddToBCP(proceso p, byte type = 0) 
        {

           
            switch (type) 
            {
                case 0: dataGridView4.Rows.Add(p.id, 
                                               "Nuevo");
                    break;
                case 1:
                    dataGridView4.Rows[p.id].SetValues(    p.id,
                                                           "Listo",
                                                           null,
                                                           p.operacion,
                                                           null,
                                                           p.Llegada,
                                                           null,
                                                           null,
                                                           p.Espera,
                                                           p.TT,
                                                           p.TME - p.TT,
                                                           p.TT > 0? p.TRespuesta: null
                                                           );
                    break;
                case 2: dataGridView4.Rows[p.id].SetValues(p.id,
                                                           "Ejecucion",
                                                           Quantum - time.actual,
                                                           p.operacion,
                                                           null,
                                                           p.Llegada,
                                                           null,
                                                           null,
                                                           p.Espera,
                                                           p.TT,
                                                           p.TME - p.TT,
                                                           p.TT > 0 ? p.TRespuesta : null
                                                           );
                    break;
                case 3:
                    dataGridView4.Rows[p.id].SetValues(    p.id,
                                                           "Bloqueado",
                                                           8 - p.TTB,
                                                           p.operacion,
                                                           null,
                                                           p.Llegada,
                                                           null,
                                                           null,
                                                           p.Espera,
                                                           p.TT,
                                                           p.TME - p.TT,
                                                           p.TT > 0 ? p.TRespuesta : null
                                                           );
                    break;
                case 4:
                    dataGridView4.Rows[p.id].SetValues(p.id,
                                                           "Terminado",
                                                           "Error",
                                                           "Error",
                                                           p.operacion,
                                                           p.Llegada,
                                                           p.Finalizacion,
                                                           p.Retorno,
                                                           p.Espera,
                                                           p.TT,
                                                           p.TME - p.TT,
                                                           p.TT > 0 ? p.TRespuesta : null
                                                           );
                    break;
                case 5:
                    dataGridView4.Rows[p.id].SetValues(     p.id,
                                                           "Terminado",
                                                           "Correctamente",
                                                           p.operacion,
                                                           p.resultado,
                                                           p.Llegada,
                                                           p.Finalizacion,
                                                           p.Retorno,
                                                           p.Espera,
                                                           p.TT,
                                                           p.TME - p.TT,
                                                           p.TT > 0 ? p.TRespuesta : null
                                                           );
                    break;
                case 6:
                    dataGridView4.Rows[p.id].SetValues(p.id,
                                                           "Suspendido",
                                                           null,
                                                           p.operacion,
                                                           null,
                                                           p.Llegada,
                                                           null,
                                                           null,
                                                           p.Espera,
                                                           p.TT,
                                                           p.TME - p.TT,
                                                           p.TT > 0 ? p.TRespuesta : null
                                                           );
                    break;
            }
        }

        private void dgvProcessAdd(proceso p)
        {
            dataGridView2.Rows.Add(p.id, p.TME, p.TT);
           
        }

        private void dgvBloquedAdd(proceso p)
        {
                                        //ID   TTB
            _ = dataGridView5.Rows.Add(p.id, 0);

        }


        private void terminar()
        {
            KeyPreview = false;
            lblTT.Text = time.total.ToString();
            lblTranscurrido.Text = time.actual.ToString();
            progressBarTotal.Value = 100;
            updateTime(Vacio: true);            

            button2.Enabled = true;
            timer1.Stop();
            MessageBox.Show($"Tiempo total de ejecucion: {time.total}", "Tiempo total", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView4.Sort(ColId,ListSortDirection.Ascending);

        }

        private void updateTime(bool Vacio = false)
        {
            lblTT.Text = time.total.ToString();
            lblTranscurrido.Text = Vacio ? "" : (Ejecucion.TT).ToString();
            lblRestante.Text = Vacio ? "" : (Ejecucion.TME - Ejecucion.TT).ToString();
            progressBarProcess.Value = Vacio ? 0 : ((Ejecucion.TT) * 100 / Ejecucion.TME);

            if (tm > 0 )
                progressBarTotal.Value = ((time.total) * 100 / tm);

            lblQuantum.Text = time.actual.ToString();
        }

        private void updateProcess(bool Vacio = false)
        {
            lblID.Text = Vacio ? "" : Ejecucion.id.ToString();
            lblOperacion.Text = Vacio ? "" : Ejecucion.operacion;
            lblTME.Text = Vacio ? "" : Ejecucion.TME.ToString();

        }

        private float getOP(string operacion)
        {
            string[] nums = new string[2];
            nums[0] = "error";
            if (operacion.Contains('*')) 
            { 
                nums = (string[])operacion.Split('*');
                return float.Parse(nums[0]) * float.Parse(nums[1]);
            }

            if (operacion.Contains('%'))
            {
                nums = (string[])operacion.Split('%');
                return float.Parse(nums[0]) % float.Parse(nums[1]);
            }

            if (operacion.Contains('+'))
            { 
                nums = (string[])operacion.Split('+');
                return (float.Parse(nums[0]) + float.Parse(nums[1]));

            }

            if (operacion.Contains('-'))
            { 
                nums = (string[])operacion.Split('-');
                return (float.Parse(nums[0]) - float.Parse(nums[1]));

            }

            if (operacion.Contains('/'))
            {
                nums = (string[])operacion.Split('/');
                if (float.Parse(nums[1]) == 0)
                {
                    return (0);
                }
                return (float.Parse(nums[0]) / float.Parse(nums[1]));

            }

            return (0);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #region keyboard
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData) 
            {
                case Keys.P: timer1.Enabled = false;                                break;
                case Keys.C: timer1.Enabled = true;  panelProcesar.Visible = true;
                             panelFrames.Visible = false;                           break;
                case Keys.E: if (timer1.Enabled)     processError();                break;
                case Keys.I: if (timer1.Enabled)     processInterruption();         break;
                case Keys.T: if (Ejecucion != null)  AddToBCP(Ejecucion, 2);
                             timer1.Enabled = false; panelProcesar.Visible = false; break;
                case Keys.A: timer1.Enabled = false; panelFrames.Visible = true; 
                                                                                    break;
                case Keys.N: if (timer1.Enabled)     newProcess();                  break;
                case Keys.S: if (timer1.Enabled) suspendProcess();  break;
                case Keys.R: if (timer1.Enabled) returnProcess(); break;

            }
        }

        private void suspendProcess() 
        {
            proceso p;
            
            if (Bloqueados.Count == 0)
                return;
            
            p = Bloqueados[0];
            Bloqueados.RemoveAt(0);
            dataGridView5.Rows.RemoveAt(0);
           
            Disco.Add(p);
            WipeFrames(p);
            AddToBCP(p, 6);
            UpdateSuspendidos();

            if (Nuevos.Count > 0)
            {
                AddProcess();
            }
        }

        private void UpdateSuspendidos()
        {
            if (idSus.Text != "")
                return;
            
            proceso? p = Disco.PeekFile();
            if (p == null)
                return;
            idSus.Text = p.id.ToString();
            sizeSus.Text = p.size.ToString();
        }

        private void returnProcess() 
        {
            entry.Checked = true;
            returnProcessToMemory();

        }

        private bool returnProcessToMemory()
        {
            proceso p;
            int[]? frames;

            if (idSus.Text == "") 
            {
                entry.Checked = false;
                return true;
            }


            p = Disco.PeekFile();
           
            if ((frames = memoria.Addprocess(p)) == null)
                return false;

            entry.Checked = false;

            Disco.DequeFile();

            Listos.Add(p);
            AddToBCP(p, 1);
            AddtoFrames(frames);
            dgvProcessAdd(p);

            idSus.Text = "";
            sizeSus.Text = "";
            UpdateSuspendidos();
            return true;
        }

        private void newProcess()
        {
            int i = (int)numericUpDown1.Value;
            numericUpDown1.Value += 1;

            createProcess(dataGridView1.Rows[i]);

            lblLotes.Text = Nuevos.Count.ToString();

            AddProcess();
        }

        private int ProcessInMemory() 
        {
            return (Ejecucion == null ? 0 : 1) + 
                    Bloqueados.Count + 
                    Listos.Count +
                   (idSus.Text == "" ? 0 : 1);
        }

        private void processInterruption()
        {
            bool vacio;

            if (Ejecucion == null)
                return;

            time.actual = 0;

            Bloqueados.Add(Ejecucion);
            AddToBCP(Ejecucion,3);
            dgvBloquedAdd(Ejecucion);
            
            Ejecucion = null;

            next_process();
            vacio = Ejecucion == null;
                
            updateProcess(vacio);
            updateTime(vacio);
            
        }

        private void processError()
        {
            if (Ejecucion == null)
                return;

            time.actual = 0;
            int i;
            tm -= (Ejecucion.TME - Ejecucion.TT);

            Ejecucion.Finalizacion = time.total;
            addResultado(Ejecucion, Error: true);
            
            ProcessEnd();

            if (!KeyPreview)
                return;

            updateTime(Ejecucion == null);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        #endregion keyboard
    }
}