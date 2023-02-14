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
        lote actual;
        Queue<lote> lotes;
        #endregion

        public Form1()
        {
            InitializeComponent();
            
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
                //agregar generacion aleatoria
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
            if (createLotes() | (lotes.Count < 0))
            {
                return;
            }
            panelProcesos.Visible = !panelProcesos.Visible;
            actual = lotes.Dequeue();
            dgvProcessAdd();
            dataGridView2.Rows.RemoveAt(0);
            time = (0, 0);
            updateProcess();
            loteActual++;
            lblTT.Text = "0";
            lblTranscurrido.Text = "0";
            lblRestante.Text = (actual.procesos[proceso].TME - 0).ToString();
            
            button1.Enabled = false;
            timer1.Start();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

        }

        private bool createLotes()
        {
            List<int> id = new List<int>();
            proceso[] temp = new proceso[] {new proceso(),new proceso(),new proceso(),new proceso()};
            lote l = new lote();
            lotes = new Queue<lote>();
            int i = 0;
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                bool valid = true;
                var row = rows.Cells;

                try
                {
                    temp[i].TME = (int)row[2].Value;
                }
                catch (Exception)
                {
                    MessageBox.Show($"Formato  TME: {dataGridView1.Rows.IndexOf(rows)}",
                        "Error TME", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

                if (temp[i].TME < 1)
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
                                            
                temp[i].operacion = (string)row[1].Value;
                try
                {
                    (temp[i].resultado, valid) = getOP(temp[i].operacion);
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

                temp[i].id = (int)row[0].Value;
                tm += temp[i].TME;
                temp[i].TR = temp[i].TME;
                temp[i].terminado = false;
                id.Add((int)row[0].Value);

                if (i >= 3)
                {
                    l.procesos = temp;
                    lotes.Enqueue(l);
                    l = new lote();
                    temp = new proceso[] { new proceso(), new proceso(), new proceso(), new proceso() };
                    i = -1;
                }
                i++;

            }
            if (i > 0)
            {
                l.procesos = temp;
                lotes.Enqueue(l);
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelProcesar.Visible = !panelProcesar.Visible;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.total++;
            actual.procesos[proceso].TR--;
            if (actual.procesos[proceso].TR == 0)
            {
                actual.procesos[proceso].terminado = true;
                addResultado();
                next_process();
                
                if (proceso == 4)
                    loteChange();
                if (actual.procesos[proceso].terminado) 
                {
                    terminar();
                    return;
                }
                    
                updateProcess();
             
                dataGridView2.Rows.RemoveAt(0);
            }
            updateTime();
        }

        private void loteChange()
        {
            proceso = 0;
            if (lotes.Count > 0)
            {
                loteActual++;
                actual = lotes.Dequeue();
                dgvProcessAdd();
            }
            else
                terminar();
        }

        private void next_process() 
        {
            proceso++;
            int i = proceso;
            do
            {
                if (proceso == 4) proceso = 0;
                if (!actual.procesos[proceso].terminado) return;
                proceso++;
            } while (proceso != i);
            proceso = 4;
        }

        private void addResultado()
        {
            int i;
            i = dataGridView3.Rows.Add();
            dataGridView3.Rows[i].Cells[0].Value = actual.procesos[proceso].id;
            dataGridView3.Rows[i].Cells[1].Value = actual.procesos[proceso].operacion;
            dataGridView3.Rows[i].Cells[2].Value = actual.procesos[proceso].resultado;

            i = dataGridView4.Rows.Add();
            dataGridView4.Rows[i].Cells[0].Value = loteActual;
            dataGridView4.Rows[i].Cells[1].Value = actual.procesos[proceso].id;
            dataGridView4.Rows[i].Cells[2].Value = actual.procesos[proceso].operacion;
            dataGridView4.Rows[i].Cells[3].Value = actual.procesos[proceso].TME;
            dataGridView4.Rows[i].Cells[4].Value = actual.procesos[proceso].resultado;


        }

        private void dgvProcessAdd()
        {
            lblLotes.Text = lotes.Count().ToString();
            foreach (proceso p in actual.procesos)
            {
                if (p.terminado == true)
                    return;

                int i = dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = p.id;
                dataGridView2.Rows[i].Cells[1].Value = p.id.ToString();
            }
            
        }

        private void terminar()
        {
            KeyPreview = false;
            lblTT.Text = time.total.ToString();
            lblTranscurrido.Text = time.actual.ToString();
            progressBarTotal.Value = 100;
            progressBarProcess.Value = 100;

            button2.Enabled = true;
            timer1.Stop();
            MessageBox.Show($"Tiempo total de ejecucion: {time.total}", "Tiempo total", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void updateTime()
        {
            lblTT.Text = time.total.ToString();
            lblTranscurrido.Text = (actual.procesos[proceso].TME - actual.procesos[proceso].TR).ToString();
            lblRestante.Text = (actual.procesos[proceso].TR).ToString();
            progressBarProcess.Value = ((actual.procesos[proceso].TME - actual.procesos[proceso].TR) * 100 / actual.procesos[proceso].TME);
            progressBarTotal.Value = ((time.total) * 100 / tm);
        }

        private void updateProcess()
        {
            proceso temp = actual.procesos[proceso];
            float op;

            lblID.Text = temp.id.ToString();
            lblOperacion.Text = temp.operacion;
            lblTME.Text = temp.TME.ToString();

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
                case Keys.P: timer1.Enabled = false;break;
                case Keys.C: timer1.Enabled = true; break;
                case Keys.E: processError();        break;
                case Keys.I: processInterruption(); break;
            }
        }

        private void processInterruption()
        {
            int i = proceso;
            next_process();
            updateProcess();
            updateTime();
            if (i != proceso)
            {
                dataGridView2.Rows.RemoveAt(0);
                int row = dataGridView2.Rows.Add();
                dataGridView2.Rows[row].Cells[0].Value = actual.procesos[proceso].id;
                dataGridView2.Rows[row].Cells[1].Value = actual.procesos[proceso].id.ToString();
            }
        }

        private void processError()
        {
            int i;
            actual.procesos[proceso].terminado = true;
            tm -= actual.procesos[proceso].TR;
            i = dataGridView3.Rows.Add();
            dataGridView3.Rows[i].Cells[0].Value = actual.procesos[proceso].id;
            dataGridView3.Rows[i].Cells[1].Value = actual.procesos[proceso].operacion;
            dataGridView3.Rows[i].Cells[2].Value = "Error";

            i = dataGridView4.Rows.Add();
            dataGridView4.Rows[i].Cells[0].Value = loteActual;
            dataGridView4.Rows[i].Cells[1].Value = actual.procesos[proceso].id;
            dataGridView4.Rows[i].Cells[2].Value = actual.procesos[proceso].operacion;
            dataGridView4.Rows[i].Cells[3].Value = actual.procesos[proceso].TME;
            dataGridView4.Rows[i].Cells[4].Value = "Error";
            

            next_process();
            if (proceso == 4)
                loteChange();

            if (!KeyPreview)
                return;

            dataGridView2.Rows.RemoveAt(0);
            updateProcess();
            updateTime();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        #endregion keyboard
    }
}