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
    public partial class ModificarVehiculo : Form
    {
        VehiculoLog log = new VehiculoLog();
        Vehiculo vehiculo = new Vehiculo();
        string id;
        public ModificarVehiculo(string idVehiculo)
        {
            InitializeComponent();
            id = idVehiculo;
        }

        private void btnModificarVehiculo_Click(object sender, EventArgs e)
        {
            vehiculo.IDVehiculo = id;
            vehiculo.Nombre = txtNombre.Text;

            log.Modificar(vehiculo);

            this.Hide();
            Inicio.Vehiculos.Show();
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

        private void ModificarVehiculo_Load(object sender, EventArgs e)
        {
            List<Vehiculo> vh = log.ListadoAll();
            foreach (Vehiculo x in vh)
            {
                if (x.IDVehiculo == id)
                {
                    txtNombre.Text = x.Nombre;
                }
            }
        }
    }
}
