using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Pantallas_SIVAA
{
    public partial class PeriodoMejorEmpleado : Form
    {
        Empleado _pqt;
        public PeriodoMejorEmpleado(Empleado pqt)
        {
            InitializeComponent();
            _pqt = pqt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteMejoresEmpleados mejorem = new ReporteMejoresEmpleados(_pqt);
            this.Close();
            mejorem.Show();
        }
    }
}
