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

namespace Pantallas_SIVAA.Proovedores
{
    public partial class EditarProovedores : Form
    {
        ProovedoresPrin proveedor = new ProovedoresPrin();
        ProveedorLog log = new ProveedorLog();
        string id;
        public EditarProovedores(string idProveedor)
        {
            InitializeComponent();
            id = idProveedor;
        }



        private void EditarProovedores_Load(object sender, EventArgs e)
        {
            List<Proveedor> em = log.ListadoAll();
            foreach (Proveedor x in em)
            {
                if (x.IDProveedor == id)
                {
                    txtNombre.Text = x.Nombre;
                    txtRFC.Text = x.RFC;
                    txtNoExterior.Text = x.NoExterior;
                    txtEstado.Text = x.Estado;
                    txtColonia.Text = x.Colonia;
                    txtCiudad.Text = x.Ciudad;
                }
            }
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
            Login.inicio.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.IDProveedor = id;
            proveedor.Nombre = txtNombre.Text;
            proveedor.RFC = txtRFC.Text;
            proveedor.Ciudad = txtCiudad.Text;
            proveedor.Estado = txtEstado.Text;
            proveedor.NoExterior = txtNoExterior.Text;
            proveedor.Colonia = txtColonia.Text;

            log.Modificar(proveedor);

            MessageBox.Show("Vas a modificar los datos de un empleado ¿estas seguro de esto?", "Modificacion de empleado", MessageBoxButtons.OKCancel);

            this.Hide();
            this.proveedor.Show();
        }

    }
}
