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

namespace Pantallas_SIVAA
{
    public partial class EditarCita : Form
    {
        string id;
        Cita cita = new Cita();
        EmpleadoLog empleado = new EmpleadoLog();
        CitaLog log = new CitaLog();

        public EditarCita(string idCita)
        {
            InitializeComponent();
            id = idCita;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
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
            Inicio.CalendarioCitas.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Ventas.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Caja.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            cita.IDCita = id;
            cita.IDCliente = txtIDCliente.Text;
            cita.Dia = date.Value.Day;
            cita.Mes = date.Value.Month;
            cita.Año = date.Value.Year;
            cita.Hora = cbTime.Text;
            cita.IDEmpleado = idEmpleado(cbVendedor.Text);
            log.Modificar(cita);

            MessageBox.Show("La accion que realizaras es irreversible ¿estas seguro de esto?", "Cancelacion de cita", MessageBoxButtons.OKCancel);
            this.Hide();
            Inicio.CalendarioCitas.Show();
        }

        private void EditarCita_Load(object sender, EventArgs e)
        {
            List<Empleado> em = empleado.ListadoAll();
            foreach (Empleado x in em)
                cbVendedor.Items.Add(x.Nombre);
            List<Cita> c = log.ListadoAll();
            foreach (Cita x in c)
            {
                if (x.IDCita == id)
                {
                    txtIDCliente.Text = x.IDCliente;
                    cbTime.Text = x.Hora;
                    cbVendedor.Text = nombre(x.IDEmpleado);
                    date.Value = new DateTime(x.Año, x.Mes, x.Dia);
                }
            }
        }


        private string nombre(string idEm)
        {
            List<Empleado> em = empleado.ListadoAll();
            string nombre = null;
            foreach (Empleado x in em)
            {
                if (x.IDEmpleado == idEm)
                {
                    nombre = x.Nombre;
                    break;
                }
            }
            return nombre;
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
