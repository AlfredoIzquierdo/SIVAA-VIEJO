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
    public partial class Corte : Form
    {
        public Corte()
        {
            InitializeComponent();
        }

        private void Corte_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ReporteBuenoCaja reporteBuenoCaja = new ReporteBuenoCaja();
            this.Close();
            reporteBuenoCaja.Show();
        }
    }
}
