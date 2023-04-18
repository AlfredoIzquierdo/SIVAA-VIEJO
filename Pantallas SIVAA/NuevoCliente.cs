using Datos;
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
using static System.Net.Mime.MediaTypeNames;

namespace Pantallas_SIVAA
{
    public partial class NuevoCliente : Form
    {
        ClienteLog clienteLog = new ClienteLog();
        Cliente cliente = new Cliente();

        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtApellidoPat.Text) | String.IsNullOrEmpty(txtNombreCliente.Text) | String.IsNullOrEmpty(txtApellidoMat.Text) | String.IsNullOrEmpty(txtCiudad.Text) | String.IsNullOrEmpty(txtRfc.Text) || String.IsNullOrEmpty(mtxtTelefono.Text)
                | String.IsNullOrEmpty(txtEstado.Text) | String.IsNullOrEmpty(txtColonia.Text) | String.IsNullOrEmpty(txtAgregarCorreo.Text) | String.IsNullOrEmpty(txtNoExterior.Text))
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {

                List<Cliente> x = clienteLog.ListadoAll();
                string i = "C" + (x.Count + 3).ToString();
                cliente.IDCliente = i;
                cliente.Nombre = txtNombreCliente.Text;
                cliente.ApellidoPat = txtApellidoPat.Text;
                cliente.ApellidoMat = txtApellidoMat.Text;
                cliente.Correo = txtAgregarCorreo.Text;
                cliente.Telefono = mtxtTelefono.Text;
                cliente.RFC = txtRfc.Text;
                cliente.NoExterior = txtNoExterior.Text;
                cliente.Colonia = txtColonia.Text;
                cliente.Estado = txtEstado.Text;
                cliente.Ciudad = txtCiudad.Text;
                cliente.EstadoCliente = "Activo";

                clienteLog.Registrar(cliente);

                this.Hide();
                Clientes clientes = new Clientes();
                clientes.Show();


            }

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
    }
}
