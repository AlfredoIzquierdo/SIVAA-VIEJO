using Entidades;
using Logicas;
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

    public partial class AgregarProovedor : Form
    {
        public static ProovedoresPrin proovedoresagr = new ProovedoresPrin();
        Proveedor proveedor = new Proveedor();
        ProveedorLog ProveedorLog = new ProveedorLog();

        public AgregarProovedor()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void AgregarProovedor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Proveedor> x = ProveedorLog.ListadoAll();
            string i = "P" + x.Count.ToString();
            proveedor.Nombre = txtNombre.Text;
            proveedor.Colonia = txtColonia.Text;
            proveedor.RFC = txtRFC.Text;
            proveedor.NoExterior = txtNoExterior.Text;
            proveedor.Ciudad = txtCiudad.Text;
            proveedor.Estado = txtEstado.Text;

            ProveedorLog.Registrar(proveedor);

            this.Hide();
            proovedoresagr.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Reportes.Show();
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Caja.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Ventas.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.CalendarioCitas.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Stock.Show();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Pedidos.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
        }
    }
}
