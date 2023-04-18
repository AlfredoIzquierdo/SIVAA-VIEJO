using Entidades;
using Logicas;
using Pantallas_SIVAA.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Pantallas_SIVAA
{
    public partial class ConsultaCitas : Form
    {
        public static NuevaCita nuevaCita = new NuevaCita();
        CitaLog log = new CitaLog();

        public ConsultaCitas()
        {
            InitializeComponent();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            nuevaCita.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string id = null;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                EditarCita editar = new EditarCita(id);
                this.Hide();
                editar.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar una cita");
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Pedidos.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Stock.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.CalendarioCitas.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Ventas.Show();
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Caja.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Reportes.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            nuevaCita.Show();
        }

        private void ConsultaCitas_Load(object sender, EventArgs e)
        {
            List<Cita> cita = log.ListadoAll();
            foreach (Cita x in cita)
            {
                dataGridView1.Rows.Add(x.IDCita, x.IDEmpleado, x.IDCliente, x.Dia, x.Mes, x.Año, x.Hora);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
