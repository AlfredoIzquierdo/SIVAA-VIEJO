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
    public partial class Reportes : Form
    {
        PeriodoMejorCliente periodoMejorCliente = new PeriodoMejorCliente();

        public Reportes()
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

        private void btnCorteCaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reporte_Caja reporte_Caja = new Reporte_Caja();
            reporte_Caja.Show();
        }

        private void btnVersiones_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReporteVentas reporteVentas = new ReporteVentas();
            reporteVentas.Show();
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

        private void Reportes_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            PeriodoMejorServicio periodoMejorServicio = new PeriodoMejorServicio();
            periodoMejorServicio.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            PeriodoMejorEmpleado periodoMejorEmpleado = new PeriodoMejorEmpleado();
            periodoMejorEmpleado.Show();
        }

        private void btnCitasxvendedor_Click(object sender, EventArgs e)
        {
            PeriodoCitasPorVendedor periodoCitasPorVendedor = new PeriodoCitasPorVendedor();
            periodoCitasPorVendedor.Show();
        }

        private void btnClientefrecuente_Click(object sender, EventArgs e)
        {

            periodoMejorCliente.Show();
        }

        private void btnrepventas_Click(object sender, EventArgs e)
        {
            PeriodoVentas periodoventas = new PeriodoVentas();
            periodoventas.Show();
        }

        private void btnCorteCaja_Click_1(object sender, EventArgs e)
        {
            //PeriodoCorteCaja periodoCorteCaja = new PeriodoCorteCaja();
            //periodoCorteCaja.Show();
            Corte C = new Corte();
            C.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PeriodoUnidadesVendidas C = new PeriodoUnidadesVendidas();
            C.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PeriodoContadoContraCredito periodoContadoContraCredito = new PeriodoContadoContraCredito();
            periodoContadoContraCredito.Show();
        }
    }
}
