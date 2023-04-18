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
    public partial class PeriodoCorteCaja : Form
    {
        public PeriodoCorteCaja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteBuenoCaja reporteBuenoCaja = new ReporteBuenoCaja();
            this.Close();
            reporteBuenoCaja.Show();
        }
    }
}
