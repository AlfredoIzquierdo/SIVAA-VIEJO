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

namespace Pantallas_SIVAA
{
    public partial class TablaAmortizacion : Form
    {
        // Label[] etiquetas;
        readonly AmortizacionesLOG amorlog = new AmortizacionesLOG();

        Entidades.Cotizacion datoscotizacion;
        CotizacionCredito datoscotcredito;
        Cliente datoscliente;
        Versions datosversion;
        Vehiculo datosvehiculo;
        Modelo datosmodelo;
        ModeloVersion modeloVersion;
        //  VentaCredito datosventacredito;    
        public TablaAmortizacion(string idcotizacion)
        {
            InitializeComponent();
            datoscotizacion = amorlog.ObtenerCotizacion(idcotizacion);
            datoscotcredito = amorlog.ObtenerCotizacionCredito(datoscotizacion.IDCotizacion);
            datoscliente = amorlog.ObtenerDatosCliente(datoscotizacion.IDCliente);
            datosversion = amorlog.ObtenerDatosVersions(datoscotizacion.IDVersion);
            modeloVersion = amorlog.ObtenerModeloVersion(datoscotizacion.IDVersion);
            datosvehiculo = amorlog.ObtenerDatosVehiculo(datosversion.IDVehiculo);
            datosmodelo = amorlog.ObtenerDatosModelo(modeloVersion.IDModelo);
            //datosventacredito = amorlog.ObtenerVentaCredito(idventa);
            //partesuperior
            lblidcot.Text = datoscotizacion.IDCotizacion;
            lbldia.Text = datoscotizacion.Dia.ToString();
            lblmes.Text = datoscotizacion.Mes.ToString();
            lblano.Text = datoscotizacion.Año.ToString();
            //vehiculo
            lblvehiculo.Text = datosvehiculo.Nombre;
            lblversion.Text = datosversion.Version;
            lblmodelo.Text = datosmodelo.Año;
            //financiamiento
            lblprecioini.Text = "$" + datoscotcredito.Precio.ToString();
            lblplazo.Text = datoscotcredito.Plazo.ToString();
            lblinteres.Text = "10%";
            lblenganche.Text = "$" + datoscotcredito.Enganche.ToString();
            lblporengan.Text = datoscotcredito.PorcentajeEnganche.ToString().Trim() + "%";
            lblmensualidad.Text = "$" + datoscotcredito.Mensualidad.ToString();
            lblanualidad.Text = "$" + datoscotcredito.Anualidad.ToString();
            lblfinanciamiento.Text = "$" + datoscotcredito.Financiamiento.ToString();
            //Tabla
            lblmensualidadtotal.Text = "$" + datoscotcredito.Mensualidad.ToString();
            lbldiaF.Text = datoscotizacion.Dia.ToString();
            lblMesF.Text = datoscotizacion.Mes.ToString();
            lblanoF.Text = datoscotizacion.Año.ToString();
            lblcapitalrestante.Text = "$" + datoscotcredito.Precio.ToString();
            //Coordenadas
            int xnopago = lblpruebass.Left;
            int ynopago = lblpruebass.Top;
            int xmensu = lblmensualidadtotal.Left;
            int ymensu = lblmensualidadtotal.Top;
            int xcap = lblcapitalrestante.Left;
            int ycap = lblcapitalrestante.Top;
            int xdia = lbldiaF.Left;
            int ydia = lbldiaF.Top;
            int xmes = lblMesF.Left;
            int ymes = lblMesF.Top;
            int xano = lblanoF.Left;
            int yano = lblanoF.Top;
            crearlabels(xnopago, ynopago, datoscotcredito.Plazo, xmensu, ymensu, xcap, ycap, datoscotcredito.Financiamiento, xdia, ydia, xmes, ymes, datoscotizacion.Mes, datoscotizacion.Año, xano, yano);

        }

        private void crearlabels(int x, int y, int iteraciones, int xMensualidad, int yMensualidad, int xCap, int yCap, double captotal, int xdia, int ydia, int xmes, int ymes, int mescot, int anocot, int xano, int yano)
        {
            //etiquetas = new Label[24];

            int desplazamiento = 20;
            double capital = captotal;
            int anoactual = anocot;
            int mesactual = mescot;
            double saldoactual = captotal;

            for (int i = 0; i < iteraciones; i++)
            {
                if (mesactual == 12)
                {
                    mesactual = 0;
                    anoactual += 1;
                    capital -= datoscotcredito.Anualidad;
                }
                if (i != 0)
                {
                    saldoactual = (capital - datoscotcredito.Mensualidad) + datoscotcredito.Mensualidad;
                }
                //NoPagos
                Label NoPagos = new Label();
                NoPagos.Size = new Size(56, 20);
                NoPagos.Text = (i + 1).ToString();
                NoPagos.ForeColor = Color.Black;
                NoPagos.Location = new Point(x, y + desplazamiento);


                //FechaDePagos
                Label dia = new Label();
                dia.Size = new Size(21, 20);
                dia.Text = datoscotizacion.Dia.ToString().Trim();
                dia.ForeColor = Color.Black;
                dia.Location = new Point(xdia, ydia + desplazamiento);
                //Separacion
                Label separacion = new Label();
                separacion.Size = new Size(15, 20);
                separacion.Text = "/";
                separacion.ForeColor = Color.Black;
                separacion.Location = new Point(136, 33 + desplazamiento);
                //
                Label mes = new Label();
                mes.Size = new Size(25, 20);
                mes.Text = (mesactual + 1).ToString();
                mes.ForeColor = Color.Black;
                mes.Location = new Point(xmes, ymes + desplazamiento);
                //Separacion2
                Label separacion2 = new Label();
                separacion2.Size = new Size(15, 20);
                separacion2.Text = "/";
                separacion2.ForeColor = Color.Black;
                separacion2.Location = new Point(181, 33 + desplazamiento);
                //
                Label ano = new Label();
                ano.Size = new Size(43, 20);
                ano.Text = anoactual.ToString();
                ano.ForeColor = Color.Black;
                ano.Location = new Point(xano, yano + desplazamiento);

                //CapitalRestante
                Label capitalRestante = new Label();
                capitalRestante.Text = "$" + (capital - datoscotcredito.Mensualidad).ToString();
                capitalRestante.ForeColor = Color.Black;
                capitalRestante.Location = new Point(xCap, yCap + desplazamiento);


                //SaldoAnterior

                Label saldoAnterior = new Label();
                saldoAnterior.Text = "$" + (saldoactual).ToString();
                saldoAnterior.ForeColor = Color.Black;
                saldoAnterior.Location = new Point(452, yCap + desplazamiento);

                //MensualidadTotal
                Label mensualidadTotal = new Label();

                mensualidadTotal.Text = "$" + datoscotcredito.Mensualidad.ToString();
                mensualidadTotal.ForeColor = Color.Black;
                mensualidadTotal.Location = new Point(xMensualidad, yMensualidad + desplazamiento);

                //pintar

                mesactual += 1;
                desplazamiento += 20;
                capital -= datoscotcredito.Mensualidad;

                panel6.Controls.Add(NoPagos);

                panel6.Controls.Add(dia);
                panel6.Controls.Add(separacion);
                panel6.Controls.Add(mes);
                panel6.Controls.Add(separacion2);
                panel6.Controls.Add(ano);
                panel6.Controls.Add(capitalRestante);
                panel6.Controls.Add(saldoAnterior);
                panel6.Controls.Add(mensualidadTotal);

            }
        }
        private void TablaAmortizacion_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
