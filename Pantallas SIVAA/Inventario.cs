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
    public partial class Inventario : Form
    {
        readonly UnidadLog PqteLog5 = new UnidadLog();
        string Noserie, vehiculostr, versionstr, colorstr, disponibilidadstr, model;
        Empleado _pqt;
        public Inventario(Empleado pqt)
        {
            InitializeComponent();
            _pqt = pqt;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ReporteInventario reporteInventario = new ReporteInventario();
            reporteInventario.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Versiones versiones = new Versiones();
            this.Close();
            versiones.Show();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            MostrarInventario();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void MostrarInventario()
        {
            List<UnidadNoUsar> listado = PqteLog5.Inventario();
            dataGridView1.DataSource = listado;
        }
        public void MostrarInventarioFiltro(string filtro)
        {
            List<UnidadNoUsar> listado = PqteLog5.InventarioFiltro(filtro);
            dataGridView1.DataSource = listado;
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltro.SelectedIndex == 0)
                MostrarInventario();
            if (cbFiltro.SelectedIndex == 1)
                MostrarInventarioFiltro(cbFiltro.Text.ToString());
            if (cbFiltro.SelectedIndex == 2)
                MostrarInventarioFiltro(cbFiltro.Text.ToString());

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                Noserie = dataGridView1[0, i].Value.ToString();
                vehiculostr = dataGridView1[1, i].Value.ToString();
                versionstr = dataGridView1[2, i].Value.ToString();
                colorstr = dataGridView1[4, i].Value.ToString();
                disponibilidadstr = dataGridView1[5, i].Value.ToString();
                model = dataGridView1[3, i].Value.ToString();
                //MessageBox.Show("Serie= " + Noserie + "\r\nvehiculo = " + vehiculostr + "\r\nVersion = " + versionstr + "\r\nmodel = " + model);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            FichaTecnica ficha = new FichaTecnica(Noserie, vehiculostr, versionstr, model, colorstr, disponibilidadstr);
            ficha.Show();
        }
    }
}
