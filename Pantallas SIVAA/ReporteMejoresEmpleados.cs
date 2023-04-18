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
    public partial class ReporteMejoresEmpleados : Form
    {
        Empleado _pqt;
        public ReporteMejoresEmpleados(Empleado pqt)
        {
            InitializeComponent();
            _pqt = pqt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reportes regresar = new Reportes(_pqt);
            this.Close();
            regresar.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
