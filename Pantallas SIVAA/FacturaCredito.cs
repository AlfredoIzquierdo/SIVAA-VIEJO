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
    public partial class FacturaCredito : Form
    {
        readonly ClienteLog PqteLog = new ClienteLog();
        readonly EmpleadoLog empleadoLog = new EmpleadoLog();
        readonly FacturaLOG facturaLOG = new FacturaLOG();
        ModeloVersion datosModVer;
        public FacturaCredito(VentaCredito pqtVC, Venta pdqV, string nombreclien, string apellidoclien, string idempleado)
        {
            InitializeComponent();

            CotizacionCredito datoscotcredito = facturaLOG.ObtenerCotizacionCredito(pqtVC.IDCotizacion);
            Entidades.Cotizacion datoscot = facturaLOG.ObtenerCotizacion(pqtVC.IDCotizacion);
            Cliente datoscliente = facturaLOG.ObtenerDatosCliente(datoscot.IDCliente);
            Empleado datosempleado = empleadoLog.LeerPorClave(pdqV.IDEmpleado);
            Versions datosversion = facturaLOG.ObtenerDatosVersions(datoscot.IDVersion);
            Vehiculo datosvehiculo = facturaLOG.ObtenerDatosVehiculo(datosversion.IDVehiculo);
            datosModVer = facturaLOG.ObtenerModeloVersion(datoscot.IDVersion);
            Modelo datosmodelo = facturaLOG.ObtenerDatosModelo(datosModVer.IDModelo);

            double subtotal = (pqtVC.TotalFinal * 0.84);
            double iva = (pqtVC.TotalFinal * .16);
            lbldia.Text = pdqV.Dia.ToString();
            lblmes.Text = pdqV.Mes.ToString();
            lblano.Text = pdqV.Año.ToString();
            lblnombrec.Text = datoscliente.Nombre.Trim() + " " + datoscliente.ApellidoPat.Trim() + " " + datoscliente.ApellidoMat.Trim();
            lblrfc.Text = datoscliente.RFC.ToString();
            lbltelefono.Text = datoscliente.Telefono.ToString();
            lblcolonia.Text = datoscliente.Colonia.ToString();
            lblnoext.Text = datoscliente.NoExterior.ToString();
            lblciudad.Text = datoscliente.Ciudad.ToString();
            lblestado.Text = datoscliente.Estado.ToString();
            lblidclien.Text = datoscliente.IDCliente.ToString();
            lblempleado.Text = datosempleado.Nombre.Trim() + " " + datosempleado.ApellidoPat.Trim() + " " + datosempleado.ApellidoMat.Trim();
            lblsubtotal.Text = subtotal.ToString();
            lbliva.Text = iva.ToString();
            lbltotalgen.Text = (subtotal + iva).ToString();
            lblidversion.Text = datoscot.IDVersion.ToString();
            lblcostover.Text = datosversion.Costo.ToString();
            lblarticulo.Text += " " + datosvehiculo.Nombre + " " + datosversion.Version;
            lblmodelo.Text = datosmodelo.Año;
            lblnombre.Text = datosvehiculo.Nombre;
            lblversion.Text = datosversion.Version;
            lblrines.Text = datosversion.Rines;
            lblpuertas.Text = datosversion.NumPuertas;
            lblllanta.Text = datosversion.Llantas;
            lbltraccion.Text = datosversion.TipoTraccion;
            lblanchura.Text = datosversion.Anchura;
            lblaltura.Text = datosversion.Altura;
            lbldisejes.Text = datosversion.DistanciaEjes;
            lblcombus.Text = datosversion.TipoCombustible;
            lbltrans.Text = datosversion.Transmision;
            lblengra.Text = datosversion.NumEngranajes;
            lblplazocant.Text = datoscotcredito.Plazo.ToString();
            lblenganchecant.Text = datoscotcredito.Enganche.ToString();
            lblfinanciamiento.Text = datoscotcredito.Financiamiento.ToString();
            lblporcengan.Text = datoscotcredito.PorcentajeEnganche.ToString();
            lblmensualidadcant.Text = datoscotcredito.Mensualidad.ToString();
            lblanualidadcant.Text = datoscotcredito.Anualidad.ToString();
            lbltotalgeneral.Text = pqtVC.TotalFinal.ToString();
        }

        private void FacturaCredito_Load(object sender, EventArgs e)
        {

        }
    }
}
