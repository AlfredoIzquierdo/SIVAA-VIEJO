using Entidades;
using Logicas;
using Pantallas_SIVAA.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pantallas_SIVAA
{
    public partial class Factura : Form
    {
        readonly VentaLog PqteLog2 = new VentaLog();
        readonly ClienteLog PqteLog = new ClienteLog();
        readonly EmpleadoLog empleadoLog = new EmpleadoLog();
        readonly FacturaLOG facturaLOG = new FacturaLOG();
        ModeloVersion datosModVer;
        public Factura(VentaContado pqtVC, Venta pdqV, string nombreclien, string apellidoclien, string idempleado)
        {
            InitializeComponent();

            CotizacionContado datoscotcredito = facturaLOG.ObtenerCotizacionContado(pqtVC.IDCotizacion);
            Entidades.Cotizacion datoscot = facturaLOG.ObtenerCotizacion(pqtVC.IDCotizacion);
            Cliente datoscliente = facturaLOG.ObtenerDatosCliente(datoscot.IDCliente);
            Empleado datosempleado = empleadoLog.LeerPorClave(pdqV.IDEmpleado);
            Versions datosversion = facturaLOG.ObtenerDatosVersions(datoscot.IDVersion);
            Vehiculo datosvehiculo = facturaLOG.ObtenerDatosVehiculo(datosversion.IDVehiculo);
            datosModVer = facturaLOG.ObtenerModeloVersion(datosversion.IDVersion);
            Modelo datosmodelo = facturaLOG.ObtenerDatosModelo(datosModVer.IDModelo);
            double subtotal = (pdqV.Subtotal * 0.84);
            double iva = (pdqV.Subtotal * .16);
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
            lblsubtotalcant.Text = subtotal.ToString();
            lblivatotal.Text = iva.ToString();
            lbltotalcontgen.Text = (subtotal + iva).ToString();

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Size formSize = this.Size;
            float scaleX = e.MarginBounds.Width / (float)formSize.Width;
            float scaleY = e.MarginBounds.Height / (float)formSize.Height;
            float scale = Math.Min(scaleX, scaleY);
            int targetWidth = (int)(formSize.Width * scale);
            int targetHeight = (int)(formSize.Height * scale);
            Bitmap bitmap = new Bitmap(targetWidth, targetHeight, graphics);
            Graphics bitmapGraphics = Graphics.FromImage(bitmap);
            bitmapGraphics.CopyFromScreen(this.PointToScreen(Point.Empty), Point.Empty, formSize);
            e.Graphics.DrawImage(bitmap, e.MarginBounds);
            bitmap.Dispose();
            bitmapGraphics.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Factura_Load(object sender, EventArgs e)
        {

        }

        private void Factura_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.DefaultPageSettings.Landscape = true; // Set the orientation to landscape
            document.DefaultPageSettings.Margins = new Margins(100, 100, 100, 100); // 2.5cm margins on each side
            document.DefaultPageSettings.PaperSize = new PaperSize("Letter", 1920, 850); // Swap the paper width and height
            document.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog dialog = new PrintDialog();
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }
    }

}
