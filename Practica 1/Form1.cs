using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Practica_1
{
    public partial class Form1 : Form
    {
        #region atributos
        (int actual, int total) time;
        int proceso;
        int loteActual;
        int tm;
        List<proceso> Listos;
        proceso Ejecucion;
        List<proceso> Bloqueados;
        Queue<proceso> Nuevos;
        #endregion

        public Form1()
        {
            InitializeComponent();
            Nuevos = new Queue<proceso>();
            Bloqueados = new List<proceso>();
            Listos = new List<proceso>();
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
            
            while (numericUpDown1.Value > Rows.Count)
            {
                switch (nums.Next(0, 5))
                {
                    case 1: op = '+'; break;
                    case 2: op = '-'; break;
                    case 3: op = '*'; break;
                    case 4: op = '/'; break;
                    case 5: op = '%'; break;
                    default:op = '+'; break;
                }

                row = Rows.Add();
                Rows[row].Cells[0].Value = row;
                Rows[row].Cells[1].Value = $"{nums.Next(0, 100)} {op} {nums.Next(0, 100)}";
                Rows[row].Cells[2].Value = nums.Next(5, 16);
            }

            while (numericUpDown1.Value < dataGridView1.Rows.Count)
            {
                Rows.RemoveAt(Rows.Count - 1);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (createLotes() | (Nuevos.Count < 0))
            {
                return;
            }
            panelProcesos.Visible = !panelProcesos.Visible;

            time = (0, 0);

            AddProcess();
            AddProcess();
            AddProcess();
            AddProcess();

            foreach (proceso p in Listos)
                dgvProcessAdd(p);

            next_process();

            
            updateProcess();

            lblTT.Text = "0";
            lblTranscurrido.Text = "0";
            lblRestante.Text = (Ejecucion.TME - 0).ToString();
            
            button1.Enabled = false;
            timer1.Start();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

        }

        private bool createLotes()
        {
            List<int> id = new List<int>();
            proceso temp;
            
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                temp = new proceso();
                bool valid = true;
                var row = rows.Cells;

                try
                {
                    temp.TME = (int)row[2].Value;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Formato  TME: {dataGridView1.Rows.IndexOf(rows)}",
                        "Error TME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

                if (temp.TME < 1)
                {
                    MessageBox.Show($"Tiempo invalido en: {dataGridView1.Rows.IndexOf(rows)}",
                        "Tiempo invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                try
                {
                    if (id.Contains((int)row[0].Value))
                    {
                        MessageBox.Show($"ID repetido: {row[0].Value} en el proceso numero: {dataGridView1.Rows.IndexOf(rows)}",
                                        "ID repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Formato ID : {dataGridView1.Rows.IndexOf(rows)}",
                        "Error TME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                                            
                temp.operacion = (string)row[1].Value;
                try
                {
                    (temp.resultado, valid) = getOP(temp.operacion);
                }
                catch (Exception)
                {
                    valid = false;
                }

                if (!valid)
                {
                    MessageBox.Show($"Operacion erronea en el proceso numero: {dataGridView1.Rows.IndexOf(rows)}",
                        "ID repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

                temp.id = (int)row[0].Value;
                tm += temp.TME;
                id.Add((int)row[0].Value);
                Nuevos.Enqueue(temp);

            }
            return false;
        }

        private void AddProcess() 
        {
            proceso p;

            if(Nuevos.Count > 0) 
            {
                p = Nuevos.Dequeue();
                p.Llegada = time.total;
                Listos.Add(p);
                //agregar tiempo de llegada
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panelProcesar.Visible = !panelProcesar.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool vacio = false;

            time.total++;
            countTime();

            if (Ejecucion == null) 
            {
                next_process();
                tm++;
            }

            else 
            {
                Ejecucion.TT++;
                if (Ejecucion.TT == 1)
                    Ejecucion.TRespuesta = time.total - 1;
            }
                

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

                if (proceso == Listos.Count())
                    vacio = true;

                updateProcess(vacio);

            }

            

            if (Ejecucion == null)
                vacio = true;
            
                updateTime(vacio);
        }

        private void countTime()
        {
            //conteo de bloqueados

            for (int i = 0; i < Bloqueados.Count(); i++)
            {
                Bloqueados[i].TTB++;
                Bloqueados[i].Espera++;
                Bloqueados[i].Retorno++;
                dataGridView5.Rows[i].Cells[1].Value = Bloqueados[i].TTB;
                if (Bloqueados[i].TTB == 8)
                {
                    proceso p = Bloqueados[i];
                    dataGridView5.Rows.RemoveAt(i);
                    Bloqueados.Remove(p);
                    p.TTB = 0;
                    Listos.Add(p);
                    dgvProcessAdd(p);
                    i--;
                }

            }

            for (int i = 0; i < Listos.Count(); i++) 
            { 
                Listos[i].Espera++;
                Listos[i].Retorno++;
            }


        }

        void CountWaitBloqueado(proceso p) 
        {
            
        }




        private void ProcessEnd()
        {
            next_process();
            
            
            if (Nuevos.Count > 0)
            {
                AddProcess();
                dgvProcessAdd(Listos.Last());
            }

            if (Listos.Count < 0 &
               Bloqueados.Count < 0 &
               Ejecucion == null)
                terminar();
        }

        private void next_process() 
        {
            if (Listos.Count > 0) 
            {
                Ejecucion = Listos.First();
                Listos.RemoveAt(0);
                dataGridView2.Rows.RemoveAt(0);
                updateProcess();
                return;
            }

            Ejecucion = null;
            updateProcess(Vacio: true);

            if (Listos.Count == 0 &
               Bloqueados.Count == 0 &
               Ejecucion == null)
                terminar();
        }

        private void addResultado(proceso p, bool Error = false)
        {
            int i;
            i = dataGridView3.Rows.Add( p.id, 
                                        p.operacion, 
                                        Error ? "Error" : p.resultado);

            i = dataGridView4.Rows.Add( p.id, 
                                        p.operacion, 
                                        p.TME,
                                        Error ? "Error" : p.resultado,
                                        "terminado",
                                        p.Llegada,
                                        p.Finalizacion,
                                        p.TT,
                                        p.Espera,
                                        p.TRespuesta,
                                        p.Retorno);
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
            
        }

        private void updateTime(bool Vacio = false)
        {
            lblTT.Text = time.total.ToString();
            lblTranscurrido.Text = Vacio ? "" : (Ejecucion.TT).ToString();
            lblRestante.Text = Vacio ? "" : (Ejecucion.TME - Ejecucion.TT).ToString();
            progressBarProcess.Value = Vacio ? 0 : ((Ejecucion.TT) * 100 / Ejecucion.TME);
            progressBarTotal.Value = ((time.total) * 100 / tm);
        }

        private void updateProcess(bool Vacio = false)
        {
            lblID.Text = Vacio ? "" : Ejecucion.id.ToString();
            lblOperacion.Text = Vacio ? "" : Ejecucion.operacion;
            lblTME.Text = Vacio ? "" : Ejecucion.TME.ToString();

        }

        private (float, bool) getOP(string operacion)
        {
            string[] nums = new string[2];
            nums[0] = "error";
            if (operacion.Contains('*')) 
            { 
                nums = (string[])operacion.Split('*');
                return (float.Parse(nums[0]) * float.Parse(nums[1]), true);
            }

            if (operacion.Contains('%'))
            {
                nums = (string[])operacion.Split('%');
                return (float.Parse(nums[0]) % float.Parse(nums[1]), true);
            }

            if (operacion.Contains('+'))
            { 
                nums = (string[])operacion.Split('+');
                return (float.Parse(nums[0]) + float.Parse(nums[1]), true);

            }

            if (operacion.Contains('-'))
            { 
                nums = (string[])operacion.Split('-');
                return (float.Parse(nums[0]) - float.Parse(nums[1]) , true);

            }

            if (operacion.Contains('/'))
            {
                nums = (string[])operacion.Split('/');
                if (float.Parse(nums[1]) == 0)
                {
                    return (0, false);
                }
                return (float.Parse(nums[0]) / float.Parse(nums[1]), true);

            }

            return (0, false);
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
                case Keys.P: timer1.Enabled = false;                    break;
                case Keys.C: timer1.Enabled = true;                     break;
                case Keys.E: if (timer1.Enabled) processError();        break;
                case Keys.I: if (timer1.Enabled) processInterruption(); break;
            }
        }

        private void processInterruption()
        {
            bool vacio;

            if (Ejecucion == null)
                return;

            Bloqueados.Add(Ejecucion);
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

            int i;
            tm -= (Ejecucion.TME - Ejecucion.TT);

            Ejecucion.Finalizacion = time.total;
            addResultado(Ejecucion, Error: true);
            
            ProcessEnd();

            if (!KeyPreview)
                return;

            updateTime( Ejecucion == null );
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        #endregion keyboard
    }
}