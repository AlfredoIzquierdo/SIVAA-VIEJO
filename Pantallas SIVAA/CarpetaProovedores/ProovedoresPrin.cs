using Entidades;
using Logicas;
using Pantallas_SIVAA.Pedidos;
using Pantallas_SIVAA.Proovedores;
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
    public partial class ProovedoresPrin : Form
    {
        readonly ProveedorLog proveedor = new ProveedorLog();
        Empleado _pqt;
        public ProovedoresPrin()
        {
            InitializeComponent();
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            AgregarProovedor agregarprov = new AgregarProovedor();
            this.Hide();
            agregarprov.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            this.Hide();
            inicio.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string id = null;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                EditarProovedores modificarEmpleado = new EditarProovedores(id);
                this.Hide();
                modificarEmpleado.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un empleado");
            }
        }


        private void btnPedidos_Click(object sender, EventArgs e)
        {
            GestionarPedidos pedidos = new GestionarPedidos(_pqt);
            this.Hide();
            pedidos.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Inventario stock = new Inventario(_pqt);
            this.Hide();
            stock.Show();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            ConsultaCitas citas = new ConsultaCitas();
            this.Hide();
            citas.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            this.Hide();
            ventas.Show();
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            CorteDeCaja corte = new CorteDeCaja();
            this.Hide();
            corte.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reportes reportes = new Reportes(_pqt);
            reportes.Show();
        }

        private void btnCitas_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
        }

        private void ProovedoresPrin_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            List<Proveedor> pro = proveedor.ListadoAll();
            foreach (Proveedor x in pro)
            {
                dataGridView1.Rows.Add(x.IDProveedor, x.Nombre, x.RFC, x.NoExterior, x.Colonia, x.Ciudad, x.Estado);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void ProovedoresPrin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
