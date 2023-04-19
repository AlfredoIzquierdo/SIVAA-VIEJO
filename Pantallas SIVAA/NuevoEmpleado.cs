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
    public partial class NuevoEmpleado : Form
    {
        Empleado empleado = new Empleado();
        EmpleadoLog empleadolog = new EmpleadoLog();
        public NuevoEmpleado()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarVacios())
            {
                return;
            }
            List<Empleado> x = empleadolog.ListadoAll();
            string i = "E" + (x.Count + 1).ToString();
            empleado.IDEmpleado = i;
            empleado.Nombre = txtNombre.Text;
            empleado.ApellidoPat = txtApellidoP.Text;
            empleado.ApellidoMat = txtApellidoM.Text;
            empleado.Correo = txtCorreo.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.RFC = txtRFC.Text;
            empleado.Contraseña = txtContraseña.Text;
            empleado.Tipo = cbPuesto.Text;

            empleadolog.Registrar(empleado);
            this.Hide();
            Inicio.GestionarEmpleados.Show();
        }
        public bool ValidarVacios()
        {
            if (txtNombre.Text == "" || txtApellidoP.Text == "" || txtApellidoM.Text == "" || txtCorreo.Text == "" || txtContraseña.Text == "" || txtRFC.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return true;
            }
            if (cbPuesto.SelectedIndex < 0)
            {
                MessageBox.Show("Favor de seleccionar un puesto para el empleado");
                return true;
            }
            return false;
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (txtNombre.Text.Length > 9)
            {
                e.Handled = true;
                //MessageBox.Show("Limite de caracteres exedido");
                string te = txtNombre.Text.Substring(0, 9).ToString();
                txtNombre.Text = te;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtContraseña.Text.Length > 9)
            {
                e.Handled = true;
                //MessageBox.Show("Limite de caracteres exedido");
                string te = txtContraseña.Text.Substring(0, 9).ToString();
                txtContraseña.Text = te;
            }
            if (txtRFC.Text.Length > 9)
            {
                e.Handled = true;
                //MessageBox.Show("Limite de caracteres exedido");
                string te = txtRFC.Text.Substring(0, 9).ToString();
                txtRFC.Text = te;
            }
        }

        private void txtApellidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (txtApellidoM.Text.Length > 9)
            {
                e.Handled = true;
                //MessageBox.Show("Limite de caracteres exedido");
                string te = txtApellidoM.Text.Substring(0, 9).ToString();
                txtApellidoM.Text = te;
            }
        }

        private void txtApellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
            if (txtApellidoP.Text.Length > 9)
            {
                e.Handled = true;
                //MessageBox.Show("Limite de caracteres exedido");
                string te = txtApellidoP.Text.Substring(0, 9).ToString();
                txtApellidoP.Text = te;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCorreo.Text.Length > 9)
            {
                e.Handled = true;
                //MessageBox.Show("Limite de caracteres exedido");
                string te = txtCorreo.Text.Substring(0, 9).ToString();
                txtCorreo.Text = te;
            }
        }
    }
}
