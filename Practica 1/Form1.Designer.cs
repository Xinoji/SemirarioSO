namespace Practica_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.panelProcesos = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblProcesos = new System.Windows.Forms.Label();
            this.panelProcesar = new System.Windows.Forms.Panel();
            this.lblLotes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTT = new System.Windows.Forms.Label();
            this.TT = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ColResId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.colQueryNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQueryTME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRestante = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTranscurrido = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTME = new System.Windows.Forms.Label();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.ttlID = new System.Windows.Forms.Label();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.progressBarProcess = new System.Windows.Forms.ProgressBar();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TiempoLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TSer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEsp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonsPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.panelProcesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panelProcesar.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonsPanel.Controls.Add(this.button1);
            this.buttonsPanel.Controls.Add(this.button3);
            this.buttonsPanel.Controls.Add(this.button2);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(790, 44);
            this.buttonsPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(263, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Procesar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(263, 44);
            this.button3.TabIndex = 1;
            this.button3.Text = "Insertar Procesos";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(529, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 44);
            this.button2.TabIndex = 0;
            this.button2.Text = "Resultados";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ContentPanel.Controls.Add(this.panelProcesos);
            this.ContentPanel.Controls.Add(this.panelProcesar);
            this.ContentPanel.Controls.Add(this.panelResultados);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 44);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(790, 406);
            this.ContentPanel.TabIndex = 1;
            // 
            // panelProcesos
            // 
            this.panelProcesos.Controls.Add(this.dataGridView1);
            this.panelProcesos.Controls.Add(this.panel1);
            this.panelProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProcesos.Location = new System.Drawing.Point(0, 0);
            this.panelProcesos.Name = "panelProcesos";
            this.panelProcesos.Size = new System.Drawing.Size(790, 406);
            this.panelProcesos.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Operacion,
            this.TME});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(787, 354);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.FillWeight = 20F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Operacion
            // 
            this.Operacion.FillWeight = 50F;
            this.Operacion.HeaderText = "Operacion";
            this.Operacion.Name = "Operacion";
            // 
            // TME
            // 
            this.TME.FillWeight = 20F;
            this.TME.HeaderText = "TME";
            this.TME.Name = "TME";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.lblProcesos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 52);
            this.panel1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(434, 18);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 23);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblProcesos
            // 
            this.lblProcesos.AutoSize = true;
            this.lblProcesos.Location = new System.Drawing.Point(346, 20);
            this.lblProcesos.Name = "lblProcesos";
            this.lblProcesos.Size = new System.Drawing.Size(54, 15);
            this.lblProcesos.TabIndex = 0;
            this.lblProcesos.Text = "Procesos";
            // 
            // panelProcesar
            // 
            this.panelProcesar.Controls.Add(this.lblLotes);
            this.panelProcesar.Controls.Add(this.label1);
            this.panelProcesar.Controls.Add(this.lblTT);
            this.panelProcesar.Controls.Add(this.TT);
            this.panelProcesar.Controls.Add(this.panel4);
            this.panelProcesar.Controls.Add(this.panel3);
            this.panelProcesar.Controls.Add(this.panel2);
            this.panelProcesar.Controls.Add(this.progressBarTotal);
            this.panelProcesar.Controls.Add(this.progressBarProcess);
            this.panelProcesar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProcesar.Location = new System.Drawing.Point(0, 0);
            this.panelProcesar.Name = "panelProcesar";
            this.panelProcesar.Size = new System.Drawing.Size(790, 406);
            this.panelProcesar.TabIndex = 1;
            // 
            // lblLotes
            // 
            this.lblLotes.AutoSize = true;
            this.lblLotes.Location = new System.Drawing.Point(109, 338);
            this.lblLotes.Name = "lblLotes";
            this.lblLotes.Size = new System.Drawing.Size(35, 15);
            this.lblLotes.TabIndex = 7;
            this.lblLotes.Text = "####";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Procesos Nuevos ";
            // 
            // lblTT
            // 
            this.lblTT.AutoSize = true;
            this.lblTT.Location = new System.Drawing.Point(448, 338);
            this.lblTT.Name = "lblTT";
            this.lblTT.Size = new System.Drawing.Size(35, 15);
            this.lblTT.TabIndex = 5;
            this.lblTT.Text = "####";
            // 
            // TT
            // 
            this.TT.AutoSize = true;
            this.TT.Location = new System.Drawing.Point(286, 338);
            this.TT.Name = "TT";
            this.TT.Size = new System.Drawing.Size(149, 15);
            this.TT.TabIndex = 4;
            this.TT.Text = "Tiempo Total Transcurrido: ";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView3);
            this.panel4.Location = new System.Drawing.Point(529, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(258, 326);
            this.panel4.TabIndex = 2;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColResId,
            this.ColResOp,
            this.ColResRes});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(258, 326);
            this.dataGridView3.TabIndex = 1;
            // 
            // ColResId
            // 
            this.ColResId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColResId.HeaderText = "ID";
            this.ColResId.Name = "ColResId";
            this.ColResId.ReadOnly = true;
            // 
            // ColResOp
            // 
            this.ColResOp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColResOp.HeaderText = "Operacion";
            this.ColResOp.Name = "ColResOp";
            this.ColResOp.ReadOnly = true;
            // 
            // ColResRes
            // 
            this.ColResRes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColResRes.HeaderText = "Resultado";
            this.ColResRes.Name = "ColResRes";
            this.ColResRes.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView5);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Location = new System.Drawing.Point(0, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(263, 316);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AllowUserToResizeColumns = false;
            this.dataGridView5.AllowUserToResizeRows = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.BTT});
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView5.Location = new System.Drawing.Point(0, 176);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.RowTemplate.Height = 25;
            this.dataGridView5.Size = new System.Drawing.Size(263, 140);
            this.dataGridView5.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // BTT
            // 
            this.BTT.HeaderText = "BTT";
            this.BTT.Name = "BTT";
            this.BTT.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQueryNombre,
            this.ColQueryTME,
            this.TR});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(263, 316);
            this.dataGridView2.TabIndex = 0;
            // 
            // colQueryNombre
            // 
            this.colQueryNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQueryNombre.HeaderText = "ID";
            this.colQueryNombre.Name = "colQueryNombre";
            this.colQueryNombre.ReadOnly = true;
            // 
            // ColQueryTME
            // 
            this.ColQueryTME.HeaderText = "TME";
            this.ColQueryTME.Name = "ColQueryTME";
            this.ColQueryTME.ReadOnly = true;
            // 
            // TR
            // 
            this.TR.HeaderText = "TR";
            this.TR.Name = "TR";
            this.TR.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRestante);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblTranscurrido);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTME);
            this.panel2.Controls.Add(this.lblOperacion);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblID);
            this.panel2.Controls.Add(this.ttlID);
            this.panel2.Location = new System.Drawing.Point(263, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 218);
            this.panel2.TabIndex = 1;
            // 
            // lblRestante
            // 
            this.lblRestante.AutoSize = true;
            this.lblRestante.Location = new System.Drawing.Point(116, 136);
            this.lblRestante.Name = "lblRestante";
            this.lblRestante.Size = new System.Drawing.Size(49, 15);
            this.lblRestante.TabIndex = 15;
            this.lblRestante.Text = "######";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Restante:";
            // 
            // lblTranscurrido
            // 
            this.lblTranscurrido.AutoSize = true;
            this.lblTranscurrido.Location = new System.Drawing.Point(116, 102);
            this.lblTranscurrido.Name = "lblTranscurrido";
            this.lblTranscurrido.Size = new System.Drawing.Size(49, 15);
            this.lblTranscurrido.TabIndex = 13;
            this.lblTranscurrido.Text = "######";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Transcurrido:";
            // 
            // lblTME
            // 
            this.lblTME.AutoSize = true;
            this.lblTME.Location = new System.Drawing.Point(116, 71);
            this.lblTME.Name = "lblTME";
            this.lblTME.Size = new System.Drawing.Size(49, 15);
            this.lblTME.TabIndex = 11;
            this.lblTME.Text = "######";
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Location = new System.Drawing.Point(116, 41);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(49, 15);
            this.lblOperacion.TabIndex = 10;
            this.lblOperacion.Text = "######";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "TME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Operacion:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(116, 17);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(49, 15);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "######";
            // 
            // ttlID
            // 
            this.ttlID.AutoSize = true;
            this.ttlID.Location = new System.Drawing.Point(40, 18);
            this.ttlID.Name = "ttlID";
            this.ttlID.Size = new System.Drawing.Size(21, 15);
            this.ttlID.TabIndex = 6;
            this.ttlID.Text = "ID:";
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Location = new System.Drawing.Point(12, 356);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(766, 38);
            this.progressBarTotal.TabIndex = 0;
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.Location = new System.Drawing.Point(272, 244);
            this.progressBarProcess.MarqueeAnimationSpeed = 100000;
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(254, 23);
            this.progressBarProcess.Step = 1;
            this.progressBarProcess.TabIndex = 3;
            // 
            // panelResultados
            // 
            this.panelResultados.Controls.Add(this.dataGridView4);
            this.panelResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResultados.Location = new System.Drawing.Point(0, 0);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(790, 406);
            this.panelResultados.TabIndex = 0;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColOperacion,
            this.ColTME,
            this.ColResultado,
            this.Estado,
            this.TiempoLlegada,
            this.TFin,
            this.TSer,
            this.TEsp,
            this.TRet,
            this.Tres});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.RowTemplate.Height = 25;
            this.dataGridView4.Size = new System.Drawing.Size(790, 406);
            this.dataGridView4.TabIndex = 3;
            this.dataGridView4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellContentClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ColId
            // 
            this.ColId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColId.HeaderText = "ID";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            // 
            // ColOperacion
            // 
            this.ColOperacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColOperacion.HeaderText = "Operacion";
            this.ColOperacion.Name = "ColOperacion";
            this.ColOperacion.ReadOnly = true;
            // 
            // ColTME
            // 
            this.ColTME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTME.HeaderText = "TME";
            this.ColTME.Name = "ColTME";
            this.ColTME.ReadOnly = true;
            // 
            // ColResultado
            // 
            this.ColResultado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColResultado.HeaderText = "Resultado";
            this.ColResultado.Name = "ColResultado";
            this.ColResultado.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // TiempoLlegada
            // 
            this.TiempoLlegada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TiempoLlegada.HeaderText = "T LL";
            this.TiempoLlegada.Name = "TiempoLlegada";
            this.TiempoLlegada.ReadOnly = true;
            // 
            // TFin
            // 
            this.TFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TFin.HeaderText = "T F";
            this.TFin.Name = "TFin";
            this.TFin.ReadOnly = true;
            // 
            // TSer
            // 
            this.TSer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TSer.HeaderText = "T S";
            this.TSer.Name = "TSer";
            this.TSer.ReadOnly = true;
            // 
            // TEsp
            // 
            this.TEsp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TEsp.HeaderText = "T E";
            this.TEsp.Name = "TEsp";
            this.TEsp.ReadOnly = true;
            // 
            // TRet
            // 
            this.TRet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TRet.HeaderText = "T Res";
            this.TRet.Name = "TRet";
            this.TRet.ReadOnly = true;
            // 
            // Tres
            // 
            this.Tres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tres.HeaderText = "T ret";
            this.Tres.Name = "Tres";
            this.Tres.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.buttonsPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.panelProcesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panelProcesar.ResumeLayout(false);
            this.panelProcesar.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel buttonsPanel;
        private Panel ContentPanel;
        private Button button1;
        private Button button3;
        private Button button2;
        private DataGridView dataGridView1;
        private Panel panelProcesar;
        private Panel panelResultados;
        private Panel panelProcesos;
        private Panel panel1;
        private NumericUpDown numericUpDown1;
        private Label lblProcesos;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private ProgressBar progressBarProcess;
        private ProgressBar progressBarTotal;
        private DataGridView dataGridView4;
        private DataGridView dataGridView3;
        private DataGridView dataGridView2;
        private Label TT;
        private DataGridViewTextBoxColumn ColResId;
        private DataGridViewTextBoxColumn ColResOp;
        private DataGridViewTextBoxColumn ColResRes;
        private Label lblRestante;
        private Label label8;
        private Label lblTranscurrido;
        private Label label6;
        private Label lblTME;
        private Label lblOperacion;
        private Label label3;
        private Label label2;
        private Label lblID;
        private Label ttlID;
        private System.Windows.Forms.Timer timer1;
        private Label lblTT;
        private Label lblLotes;
        private Label label1;
        private Label Key;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Operacion;
        private DataGridViewTextBoxColumn TME;
        private DataGridViewTextBoxColumn colQueryNombre;
        private DataGridViewTextBoxColumn ColQueryTME;
        private DataGridViewTextBoxColumn TR;
        private DataGridView dataGridView5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn BTT;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColOperacion;
        private DataGridViewTextBoxColumn ColTME;
        private DataGridViewTextBoxColumn ColResultado;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn TiempoLlegada;
        private DataGridViewTextBoxColumn TFin;
        private DataGridViewTextBoxColumn TSer;
        private DataGridViewTextBoxColumn TEsp;
        private DataGridViewTextBoxColumn TRet;
        private DataGridViewTextBoxColumn Tres;
    }
}