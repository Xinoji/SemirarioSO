using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_1
{
    public partial class form : Form
    {
        public form(Panel panelframes, Action<object, KeyEventArgs> trigger)
        {
            InitializeComponent();
            this.Controls.Add(panelframes);
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(trigger);
        }
    }
}
