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
    public partial class PeriodoCitasPorVendedor : Form
    {
        public PeriodoCitasPorVendedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CitasPorVendedor citasPorVendedor = new CitasPorVendedor();
            this.Close();
            citasPorVendedor.Show();
        }
    }
}
