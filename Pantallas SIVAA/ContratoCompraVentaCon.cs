using Entidades;
using Logicas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pantallas_SIVAA
{
    public partial class ContratoCompraVentaCon : Form
    {
        public ContratoCompraVentaCon()
        {
            InitializeComponent();
        }
        readonly ClienteLog PqteLog = new ClienteLog();
        readonly EmpleadoLog empleadoLog = new EmpleadoLog();
        readonly VentaCreditoLog PqteLog33 = new VentaCreditoLog();
        readonly CompraventaLOG comvenLOG = new CompraventaLOG();
        ModeloVersion datosModVer;
        public ContratoCompraVentaCon(VentaContado pqtventC, Venta pqtvent, string nombreclien, string apellidoclien)
        {
            Entidades.Cotizacion cotizacion1 = comvenLOG.datoscotizacion(pqtventC.IDCotizacion);
            Empleado empleado = empleadoLog.LeerPorClave(cotizacion1.IDEmpleado.ToString());
            Versions versiondoc = comvenLOG.datosversion(cotizacion1.IDVersion);
            datosModVer = comvenLOG.ObtenerModeloVersion(cotizacion1.IDVersion);
            Modelo modelo = comvenLOG.datosmodelo(datosModVer.IDModelo);
            Vehiculo vehiculo = comvenLOG.datosvehiculo(versiondoc.IDVehiculo);
            InitializeComponent();
            string Nombrecompleto = nombreclien.Trim() + " " + apellidoclien.Trim();
            lbltotalven.Text = pqtvent.Subtotal.ToString();
            lblnomclien.Text = Nombrecompleto;
            lblnomven.Text = empleado.Nombre.Trim() + " " + empleado.ApellidoPat.Trim() + " " + empleado.ApellidoMat.Trim();

            //DATOSVEHICULO
            lblanchura.Text = versiondoc.Anchura;
            lblaltura.Text = versiondoc.Altura;
            lblllanta.Text = versiondoc.Llantas;
            lblversion.Text = versiondoc.Version;
            lbltrans.Text = versiondoc.Transmision;
            lbltraccion.Text = versiondoc.TipoTraccion;
            lblrines.Text = versiondoc.Rines;
            lbldisejes.Text = versiondoc.DistanciaEjes;
            lblengra.Text = versiondoc.NumEngranajes;
            lblpuertas.Text = versiondoc.NumPuertas;
            lblcombus.Text = versiondoc.TipoCombustible;
            lblmodelo.Text = modelo.Año;
            lblnombre.Text = vehiculo.Nombre;
            //final
            lblenganche.Text = pqtvent.Subtotal.ToString();
            lblclien2.Text = Nombrecompleto.ToString();
            lblnomven3.Text = empleado.Nombre.Trim() + " " + empleado.ApellidoPat.Trim() + " " + empleado.ApellidoMat.Trim();
            lbldia.Text = pqtvent.Dia.ToString();
            lblmes.Text = MesALetra(pqtvent.Mes.ToString());
            lblano.Text = pqtvent.Año.ToString();



        }
        private string MesALetra(string num)
        {
            if (num == "1")
            {
                return "Enero";
            }
            if (num == "2")
            {
                return "Febrero";
            }
            if (num == "3")
            {
                return "Marzo";
            }
            if (num == "4")
            {
                return "Abril";
            }
            if (num == "5")
            {
                return "Mayo";
            }
            if (num == "6")
            {
                return "Junio";

            }
            if (num == "7")
            {
                return "Julio";
            }
            if (num == "8")
            {
                return "Agosto";
            }
            if (num == "9")
            {
                return "Septiembre";
            }
            if (num == "10")
            {
                return "Octubre";
            }
            if (num == "11")
            {
                return "Noviembre";
            }
            if (num == "12")
            {
                return "Diciembre";
            }
            else
            {
                return num;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Crear un objeto PrintDocument
            PrintDocument pd = new PrintDocument();

            // Asociar el controlador de eventos PrintPage con el evento PrintDocument.PrintPage
            pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);

            // Llamar al cuadro de diálogo de impresión y imprimir el documento si el usuario hace clic en "Imprimir"
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Crear un objeto Bitmap del tamaño del formulario
            Bitmap bm = new Bitmap(this.Width, this.Height);

            // Dibujar el contenido del formulario en el Bitmap
            this.DrawToBitmap(bm, new Rectangle(0, 0, this.Width, this.Height));

            // Dibujar el Bitmap en la página de impresión
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
