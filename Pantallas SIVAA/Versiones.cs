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
using Logicas;
using Datos;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace Pantallas_SIVAA
{
    public partial class Versiones : Form
    {
        public static AgregarVersion agregarVersion = new AgregarVersion();
        readonly VersionLog version = new VersionLog();

        public Versiones()
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
            agregarVersion.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string id = null;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                ModificarVersion modificarVehiculo = new ModificarVersion(id);
                this.Hide();
                modificarVehiculo.Show();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar una Version");
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

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void Versiones_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Versions> ve = version.ListadoTotal();
            foreach (Versions x in ve)
            {
                dataGridView1.Rows.Add(x.IDVersion, x.IDVehiculo, x.Llantas, x.TipoAsientos, x.CamaraTrasera, x.Pantalla, x.TipoCombustible, x.Version, x.Rines, x.Cilindraje,
                x.Costo, x.CapacidadCajuela, x.DistanciaEjes, x.Anchura, x.Altura, x.AudioVelC, x.TomaCorriente, x.TipoTraccion, x.NumPuertas, x.Transmision, x.FarosHal, x.NumEngranajes,
                x.ACAutom, x.FarosLED, x.RendimientoCombustible, x.FrenosTraseros, x.FrenosDelanteros, x.SuspensionDelantera, x.SuspensionTrasera, x.EspejosLatDirC, x.EspejosLatAE);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void comboversion_SelectedValueChanged(object sender, EventArgs e)
        {
            txtbusqueda.Enabled = true;
            if (comboversion.Text == "Todos")
            {
                txtbusqueda.Enabled = false;
                dataGridView1.Rows.Clear();
                List<Versions> ve = version.ListadoTotal();
                foreach (Versions x in ve)
                {
                    dataGridView1.Rows.Add(x.IDVersion, x.IDVehiculo, x.Llantas, x.TipoAsientos, x.CamaraTrasera, x.Pantalla, x.TipoCombustible, x.Version, x.Rines, x.Cilindraje,
                    x.Costo, x.CapacidadCajuela, x.DistanciaEjes, x.Anchura, x.Altura, x.AudioVelC, x.TomaCorriente, x.TipoTraccion, x.NumPuertas, x.Transmision, x.FarosHal, x.NumEngranajes,
                    x.ACAutom, x.FarosLED, x.RendimientoCombustible, x.FrenosTraseros, x.FrenosDelanteros, x.SuspensionDelantera, x.SuspensionTrasera, x.EspejosLatDirC, x.EspejosLatAE);

                }
            }
        }
        public List<Versions> ListadoTotalEspecifico(string nom, string parametro)
        {
            string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
            List<Versions> productos = new List<Versions>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Versions
                string CdSql = "SELECT * FROM Version WHERE " + parametro + "=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Cmd.Parameters.AddWithValue("@Lc", parametro);
                    Cmd.Parameters.AddWithValue("@Cl", nom);

                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Versions Pqte = new Versions
                        {
                            IDVersion = Convert.ToString(Dr["IDVersion"]),
                            IDVehiculo = Convert.ToString(Dr["IDvehiculo"]),
                            Llantas = Convert.ToString(Dr["LLantas"]),
                            TipoAsientos = Convert.ToString(Dr["TipoAsientos"]),
                            CamaraTrasera = Convert.ToString(Dr["CamaraTrasera"]),
                            Pantalla = Convert.ToString(Dr["Pantalla"]),
                            TipoCombustible = Convert.ToString(Dr["tipoCombustible"]),

                            Version = Convert.ToString(Dr["Version"]),
                            Rines = Convert.ToString(Dr["Rines"]),

                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Costo = Convert.ToDouble(Dr["Costo"]),
                            CapacidadCajuela = Convert.ToString(Dr["Capacidadcajuela"]),
                            DistanciaEjes = Convert.ToString(Dr["DistanciaEjes"]),
                            Anchura = Convert.ToString(Dr["Anchura"]),
                            Altura = Convert.ToString(Dr["Altura"]),
                            AudioVelC = Convert.ToString(Dr["AudioVelC"]),
                            TomaCorriente = Convert.ToString(Dr["TomaCorriente"]),
                            TipoTraccion = Convert.ToString(Dr["TipoTraccion"]),
                            NumPuertas = Convert.ToString(Dr["NumPuertas"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            FarosHal = Convert.ToString(Dr["FarosHal"]),
                            NumEngranajes = Convert.ToString(Dr["NumEngranajes"]),
                            ACAutom = Convert.ToString(Dr["ACAutom"]),
                            FarosLED = Convert.ToString(Dr["FarosLED"]),
                            RendimientoCombustible = Convert.ToString(Dr["RendimientoCombustible"]),
                            FrenosTraseros = Convert.ToString(Dr["FrenosTraseros"]),
                            FrenosDelanteros = Convert.ToString(Dr["FrenosDelanteros"]),
                            SuspensionDelantera = Convert.ToString(Dr["SuspensionDelantera"]),
                            SuspensionTrasera = Convert.ToString(Dr["SuspensionTrasera"]),
                            EspejosLatDirC = Convert.ToString(Dr["EspejosLatDirC"]),
                            EspejosLatAE = Convert.ToString(Dr["EspejosLatAE"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        private void btnbusqueda_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbusqueda.Text))
            {
                MessageBox.Show("Llene el campo busqueda");
            }
            else
            {
                List<Versions> datos = new List<Versions>();
                datos = ListadoTotalEspecifico(txtbusqueda.Text, comboversion.Text);
                dataGridView1.Rows.Clear();
                foreach (Versions x in datos)
                {

                    dataGridView1.Rows.Add(x.IDVersion, x.IDVehiculo, x.Llantas, x.TipoAsientos, x.CamaraTrasera, x.Pantalla, x.TipoCombustible, x.Version, x.Rines, x.Cilindraje,
                    x.Costo, x.CapacidadCajuela, x.DistanciaEjes, x.Anchura, x.Altura, x.AudioVelC, x.TomaCorriente, x.TipoTraccion, x.NumPuertas, x.Transmision, x.FarosHal, x.NumEngranajes,
                    x.ACAutom, x.FarosLED, x.RendimientoCombustible, x.FrenosTraseros, x.FrenosDelanteros, x.SuspensionDelantera, x.SuspensionTrasera, x.EspejosLatDirC, x.EspejosLatAE);

                }

            }
        }
    }
}
