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
    public partial class PeriodoContadoContraCredito : Form
    {
        public PeriodoContadoContraCredito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteContadoContraCredito reporteContadoContraCredito = new ReporteContadoContraCredito();
            reporteContadoContraCredito.Show();
            this.Close();
        }
    }
}
