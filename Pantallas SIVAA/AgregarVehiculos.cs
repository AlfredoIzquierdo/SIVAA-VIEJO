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
    public partial class AgregarVehiculos : Form
    {
        public static ProovedoresPrin proovedoresagr = new ProovedoresPrin();
        Vehiculo vehiculo = new Vehiculo();
        VehiculoLog vehiculoLog = new VehiculoLog();

        public AgregarVehiculos()
        {
            InitializeComponent();
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            this.Hide();
            Login.inicio.Show();
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            List<Vehiculo> x = vehiculoLog.ListadoAll();
            string i = "Vh" + (x.Count+1).ToString();
            vehiculo.IDVehiculo = i;
            vehiculo.Nombre = txtNombre.Text;

            vehiculoLog.Registrar(vehiculo);

            this.Hide();
            proovedoresagr.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
