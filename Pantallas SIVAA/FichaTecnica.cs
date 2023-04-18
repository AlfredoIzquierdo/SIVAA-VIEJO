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
    public partial class FichaTecnica : Form
    {
        readonly VersionLog versionLog = new VersionLog();
        public FichaTecnica(string NoSeriest, string Vehiculost, string Versionst, string Modelost, string Colorst, string Disponibilidadst )
        {
            InitializeComponent();
            Versions info = versionLog.ObtenerFicha(Versionst, Vehiculost);
            lblNoSerie.Text = NoSeriest;
            lblVehiculo.Text = Vehiculost;
            lblVersion.Text = Versionst;
            lblModelo.Text = Modelost;
            lblDisp.Text = Disponibilidadst;
            lblColor.Text = Colorst;
            lblTipoAsientos.Text = info.TipoAsientos;
            lblCamara.Text = info.CamaraTrasera;
            lblPantalla.Text = info.Pantalla;
            lblCombustible.Text = info.TipoCombustible;
            lblSusDel.Text = info.SuspensionDelantera;
            lblSusTrase.Text = info.SuspensionTrasera;
            lblRines.Text = info.Rines;
            lblCilindraje.Text = info.Cilindraje;
            lblCosto.Text = "$" + info.Costo.ToString();
            lblCapacidad.Text = info.CapacidadCajuela;
            lblDistancia.Text = info.DistanciaEjes;
            lblAnchura.Text = info.Anchura;
            lblAltura.Text = info.Altura;
            lblAudio.Text = info.AudioVelC;
            lblCorriente.Text = info.TomaCorriente;
            lblEspejosDIRC.Text = info.EspejosLatDirC;
            lblEspejosLAE.Text = info.EspejosLatAE;
            lblNumPuertas.Text = info.NumPuertas;
            lblTraccion.Text = info.TipoAsientos;
            lblTransimision.Text = info.Transmision;
            lblHal.Text = info.FarosHal;
            lblEngranajes.Text = info.NumEngranajes;
            lblAC.Text = info.ACAutom;
            lblLED.Text = info.FarosLED;
            lblRendimiento.Text = info.RendimientoCombustible;
            lblFrenosD.Text = info.FrenosDelanteros;
            lblFrenosT.Text = info.FrenosTraseros;
            lblLlantas.Text = info.Llantas;

        }

        private void FichaTecnica_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.DefaultPageSettings.Landscape = true; // Set the orientation to landscape
            document.DefaultPageSettings.Margins = new Margins(100, 100, 100, 100); // 2.5cm margins on each side
            document.DefaultPageSettings.PaperSize = new PaperSize("Letter", 850,1920); // Swap the paper width and height
            document.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog dialog = new PrintDialog();
            dialog.Document = document;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
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
    }
}
