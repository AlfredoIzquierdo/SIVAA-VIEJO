using Pantallas_SIVAA.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logicas;
using Entidades;

namespace Pantallas_SIVAA
{
    public partial class GestionarEmpleados : Form
    {
        public static NuevoEmpleado nuevoEmpleado = new NuevoEmpleado();
        readonly EmpleadoLog empleado = new EmpleadoLog();

        public GestionarEmpleados()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //otra prueba
                MessageBox.Show("La accion que realizaras es irreversible ¿estas seguro de esto?", "Eliminacion de empleado", MessageBoxButtons.OKCancel);
                dataGridView1.ClearSelection();
                MessageBox.Show("Empleado eliminado con exito");
                //asdasdasdasdasdasd
                //asdasdasdasd
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un empleado para eliminar");
            }
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            NuevoEmpleado n = new NuevoEmpleado();
            n.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string id = null;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                ModificarEmpleado modificarEmpleado = new ModificarEmpleado(id);
                this.Hide();
                modificarEmpleado.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar un empleado");
            }
        }

        private void GestionarEmpleados_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Empleado> em = empleado.ListadoAll();
            foreach (Empleado x in em)
            {
                dataGridView1.Rows.Add(x.IDEmpleado, x.Nombre, x.ApellidoPat, x.ApellidoMat, x.Correo, x.Telefono, x.RFC, x.Contraseña, x.Tipo);
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            nuevoEmpleado.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ReporteEmpleados r = new ReporteEmpleados();
            //this.Hide();
            r.Show();
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
