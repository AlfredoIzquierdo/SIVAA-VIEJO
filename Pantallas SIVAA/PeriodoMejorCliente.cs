using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_SIVAA
{
    public partial class PeriodoMejorCliente : Form
    {
        public PeriodoMejorCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteMejoresClientes mejorclien = new ReporteMejoresClientes();
            this.Close();
            mejorclien.Show();

        }
    }
}
