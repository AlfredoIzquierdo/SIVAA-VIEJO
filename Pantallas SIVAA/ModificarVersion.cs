using Datos;
using Entidades;
using Logicas;
using Microsoft.VisualBasic.Logging;
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
    public partial class ModificarVersion : Form
    {
        Versions version = new Versions();
        VersionLog log = new VersionLog();
        VehiculoLog veh = new VehiculoLog();
        string id;

        public ModificarVersion(string idVersion)
        {
            InitializeComponent();
            id = idVersion;
        }

        private void btnModifcarVersion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Versiones.Show();
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

        private void btnRegresarModificarVersion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Versiones.Show();
        }

        private void btnAgregarVersion_Click(object sender, EventArgs e)
        {
            version.IDVersion = id;
            version.Costo = Convert.ToDouble(txtCosto.Text);
            version.DistanciaEjes = txtDistancia.Text;
            version.Altura = txtAltura.Text;
            version.Anchura = txtAnchura.Text;
            version.Llantas = cbLlantas.Text;
            version.Version = txtVersion.Text;
            version.IDVehiculo = idVehiculo(cbVehiculo.Text);
            version.Transmision = cbTransmision.Text;
            version.Cilindraje = cbCilindros.Text;
            version.TipoAsientos = cbAsientos.Text;
            version.TipoCombustible = cbCombustible.Text;
            version.Rines = cbRines.Text;
            version.CapacidadCajuela = txtCapacidad.Text;
            version.TipoTraccion = cbTipo.Text;
            version.NumPuertas = cbPuertas.Text;
            version.NumEngranajes = cbEngranajes.Text;
            version.RendimientoCombustible = txtRendimiento.Text;
            version.FrenosDelanteros = cbFrenosD.Text;
            version.FrenosTraseros = cbFrenosT.Text;
            version.SuspensionDelantera = cbSuspensionD.Text;
            version.SuspensionTrasera = cbSuspensionT.Text;
            version.ACAutom = verificacion(rbAcAutSi, rbAcAutNo);
            version.Pantalla = verificacion(rbPantallaSi, rbPantallaNo);
            version.FarosHal = verificacion(rbFarosHalSi, rbFarosHalNo);
            version.FarosLED = verificacion(rbLEDSi, rbLEDNo);
            version.AudioVelC = verificacion(rbAudioSi, rbAudioNo);
            version.TomaCorriente = verificacion(rbTomaSi, rbTomaNo);
            version.EspejosLatDirC = verificacion(rbEspejosDirSi, rbEspejosDirNo);
            version.EspejosLatAE = verificacion(rbEspejosASi, rbEspejosANo);
            version.CamaraTrasera = verificacion(rbCamaraSi, rbCamaraNo);

            log.Registrar(version);

            Versiones versiones = new Versiones();
            this.Hide();
            versiones.Show();
        }

        private void ModificarVersion_Load(object sender, EventArgs e)
        {
            List<Vehiculo> vh = veh.ListadoAll();
            foreach (Vehiculo x in vh)
            {
                cbVehiculo.Items.Add(x.Nombre);
            }

            List<Versions> ver = log.ListadoTotal();
            foreach (Versions x in ver)
            {
                if (x.IDVersion == id)
                {
                    txtVersion.Text = x.Version.ToString();
                    txtAltura.Text = x.Altura.ToString();
                    txtAnchura.Text = x.Anchura.ToString();
                    txtCapacidad.Text = x.CapacidadCajuela.ToString();
                    txtCosto.Text = x.Costo.ToString();
                    txtDistancia.Text = x.DistanciaEjes.ToString();
                    txtRendimiento.Text = x.RendimientoCombustible.ToString();
                    cbAsientos.Text = x.TipoAsientos.ToString();
                    cbCilindros.Text = x.Cilindraje.ToString();
                    cbCombustible.Text = x.TipoCombustible.ToString();
                    cbEngranajes.Text = x.NumEngranajes.ToString();
                    cbFrenosD.Text = x.FrenosDelanteros.ToString();
                    cbFrenosT.Text = x.FrenosTraseros.ToString();
                    cbLlantas.Text = x.Llantas.ToString();
                    cbPuertas.Text = x.NumPuertas.ToString();
                    cbRines.Text = x.Rines.ToString();
                    cbSuspensionD.Text = x.SuspensionDelantera.ToString();
                    cbSuspensionT.Text = x.SuspensionTrasera.ToString();
                    cbTipo.Text = x.TipoTraccion.ToString();
                    cbTransmision.Text = x.Transmision.ToString();
                    cbVehiculo.Text = nombre(x.IDVehiculo);
                    asignar(rbAcAutSi, rbAcAutNo, x.ACAutom);
                    asignar(rbAudioSi, rbAudioNo, x.AudioVelC);
                    asignar(rbCamaraSi, rbCamaraNo, x.CamaraTrasera);
                    asignar(rbEspejosASi, rbEspejosANo, x.EspejosLatAE);
                    asignar(rbEspejosDirSi, rbEspejosDirNo, x.EspejosLatDirC);
                    asignar(rbFarosHalSi, rbFarosHalNo, x.FarosHal);
                    asignar(rbLEDSi, rbLEDNo, x.FarosLED);
                    asignar(rbPantallaSi, rbPantallaNo, x.Pantalla);
                    asignar(rbTomaSi, rbTomaNo, x.TomaCorriente);
                }
            }
        }


        private void asignar(RadioButton x, RadioButton y, string check)
        {
            if (check == "Si")
            {
                x.Checked = true;
                y.Checked = false;
            }
            else
            {
                x.Checked = false;
                y.Checked = true;
            }

        }

        private string verificacion(RadioButton x, RadioButton y)
        {
            if (x.Checked == true)
            {
                return "Si";
            }
            if (y.Checked == true)
            {
                return "No";
            }
            return "";
        }


        private string nombre(string idve)
        {
            List<Vehiculo> em = veh.ListadoAll();
            string nombre = null;
            foreach (Vehiculo x in em)
            {
                if (x.IDVehiculo == idve)
                {
                    nombre = x.Nombre;
                    break;
                }
            }
            return nombre;
        }

        private string idVehiculo(string nombre)
        {
            List<Vehiculo> em = veh.ListadoAll();
            string id = null;
            foreach (Vehiculo x in em)
            {
                if (x.Nombre == nombre)
                {
                    id = x.IDVehiculo;
                    break;
                }
            }
            return id;
        }
    }
}
