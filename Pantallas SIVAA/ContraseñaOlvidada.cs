using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_SIVAA
{
    public partial class ContraseñaOlvidada : Form
    {
        EmpleadoD pqtD = new EmpleadoD();
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public ContraseñaOlvidada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtContra1.Text == txtContra2.Text)
            {
                ActualizarContra(txtIdEmpleado.Text, txtContra2.Text, txtCorreo.Text);
            }
            else
                MessageBox.Show("Las contraseñas no coinciden");
        }

        public void ActualizarContra(string CodEmpleado, string Contrasenia, string Correo)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Empleado SET Contraseña=@Co WHERE IDEmpleado=@Cl and Correo=@Cr";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodEmpleado);
                    Cmd.Parameters.AddWithValue("@Co", Contrasenia);
                    Cmd.Parameters.AddWithValue("@Cr", Correo);

                    int filasAfectadas = Cmd.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                    {
                        // La consulta no afectó a ninguna fila, lanzar una excepción o mostrar un mensaje de error.
                        MessageBox.Show("No hay coincidencias, verifique Numero de Empleado y Correo");
                    }
                    else if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Contraseña actualizada con exito");
                        Login login = new Login();
                        this.Hide();
                        login.Show();
                        Cmd.Dispose();
                    }
                }
                Cnx.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
