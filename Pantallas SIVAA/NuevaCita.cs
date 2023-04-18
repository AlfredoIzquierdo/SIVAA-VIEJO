using Entidades;
using Logicas;
using Microsoft.VisualBasic.Logging;
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

namespace Pantallas_SIVAA
{
    public partial class NuevaCita : Form
    {
        Cita cita = new Cita();
        EmpleadoLog empleado = new EmpleadoLog();
        CitaLog log = new CitaLog();

        public NuevaCita()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            List<Cita> x = log.ListadoAll();
            string i = "C" + x.Count.ToString();
            cita.IDCita = i;
            cita.IDCliente = txtIDCliente.Text;
            cita.Dia = date.Value.Day;
            cita.Mes = date.Value.Month;
            cita.Año = date.Value.Year;
            cita.Hora = cbTime.Text;
            cita.IDEmpleado = idEmpleado(cbVendedor.Text);


            Inicio.CalendarioCitas.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
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

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Clientes.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clientes.nuevoCliente.Show();
        }

        private void NuevaCita_Load(object sender, EventArgs e)
        {
            List<Empleado> em = empleado.ListadoAll();
            foreach (Empleado x in em)
                cbVendedor.Items.Add(x.Nombre);
        }

        private string idEmpleado(string nombre)
        {
            List<Empleado> em = empleado.ListadoAll();
            string id = null;
            foreach (Empleado x in em)
            {
                if (x.Nombre == nombre)
                {
                    id = x.IDEmpleado;
                    break;
                }
            }
            return id;
        }
    }
}
