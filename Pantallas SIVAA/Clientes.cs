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
    public partial class Clientes : Form
    {
        public static NuevoCliente nuevoCliente = new NuevoCliente();
        readonly ClienteLog cliente = new ClienteLog();
        public Clientes()
        {
            InitializeComponent();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            nuevoCliente.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string id = null;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                ModificarCliente modificarCliente = new ModificarCliente(id);
                this.Hide();
                modificarCliente.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un cliente");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReporteClientes r = new ReporteClientes();
            //this.Hide();
            r.Show();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            List<Cliente> clie = cliente.ListadoAll();
            foreach (Cliente x in clie)
            {
                if (x.EstadoCliente == "Activo")
                {

                    dataGridView1.Rows.Add(x.IDCliente, x.Nombre, x.ApellidoPat, x.ApellidoMat, x.RFC, x.Correo, x.Telefono, x.NoExterior, x.Colonia, x.Ciudad, x.Estado);

                }

                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            string id = null;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                cliente.EliminarPorStatus(id);
                MessageBox.Show("Cliente Eliminado");
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un cliente");
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            txtbusqueda.Enabled = true;
            if (comboBusqueda.Text=="Todos")
            {
                txtbusqueda.Enabled = false;
                dataGridView1.ClearSelection();
                List<Cliente> clie = cliente.ListadoAll();
                foreach (Cliente x in clie)
                {
                    dataGridView1.Rows.Add(x.IDCliente, x.Nombre, x.ApellidoPat, x.ApellidoMat, x.RFC, x.Correo, x.Telefono, x.NoExterior, x.Colonia, x.Ciudad, x.Estado);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbusqueda.Text))
            {
                MessageBox.Show("Llene el campo busqueda");
            }
            else
            {
                List<Cliente> datos = new List<Cliente>();
                datos = cliente.ListadoEspecifico(txtbusqueda.Text, comboBusqueda.Text);
                dataGridView1.Rows.Clear();
                foreach (Cliente x in datos)
                {
                    dataGridView1.Rows.Add(x.IDCliente, x.Nombre, x.ApellidoPat, x.ApellidoMat, x.RFC, x.Correo, x.Telefono, x.NoExterior, x.Colonia, x.Ciudad, x.Estado);
                }

            }
        }
    }
}
