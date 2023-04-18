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
    public partial class ReporteVentas : Form
    {
        public ReporteVentas()
        {
            InitializeComponent();
        }

        //private void ReporteVentas_Load(object sender, EventArgs e)
        //{
        //    //paneles superiores al data
        //    int w = 0, h = 0;
        //    w = Column1.Width + Column2.Width + Column3.Width;
        //    panel4.Location = new Point(w + 18, panel4.Location.Y);
        //    h = Column4.Width + Column5.Width;
        //    panel4.Size = new Size(h - 5, panel4.Size.Height);
        //    int t = panel4.Size.Width / 3;
        //    label17.Location = new Point(t, label17.Location.Y);

        //    w = 0; h = 0;
        //    w = Column1.Width + Column2.Width + Column3.Width + Column4.Width + Column5.Width;
        //    panel5.Location = new Point(w + 18, panel5.Location.Y);
        //    h = Column6.Width + Column7.Width;
        //    panel5.Size = new Size(h - 5, panel5.Size.Height);
        //    t = panel5.Size.Width / 3;
        //    label16.Location = new Point(t, label16.Location.Y);

        //    w = 0; h = 0;
        //    w = Column1.Width + Column2.Width + Column3.Width + Column4.Width + Column5.Width + Column6.Width + Column7.Width;
        //    panel6.Location = new Point(w + 18, panel6.Location.Y);
        //    h = Column8.Width + Column9.Width;
        //    panel6.Size = new Size(h - 5, panel6.Size.Height);
        //    t = panel6.Size.Width / 3;
        //    label18.Location = new Point(t, label17.Location.Y);

        //    Graphics g = this.CreateGraphics();
        //    g.Clear(Color.White);
        //    Pen p = new Pen(Color.Black, 5);
        //    g.DrawRectangle(p, panel4.Left - 1, panel4.Top - 1, panel4.Width + 1, panel4.Height + 1);
        //    g.DrawRectangle(p, panel5.Left - 1, panel5.Top - 1, panel5.Width + 1, panel5.Height + 1);
        //    g.DrawRectangle(p, panel6.Left - 1, panel6.Top - 1, panel6.Width + 1, panel6.Height + 1);
        //}
        //bool cam = false;
        //private void ReporteVentas_SizeChanged(object sender, EventArgs e)
        //{
        //    //paneles superiores al data
        //    int w = 0, h = 0;
        //    w = Column1.Width + Column2.Width + Column3.Width;
        //    panel4.Location = new Point(w + 18, panel4.Location.Y);
        //    h = Column4.Width + Column5.Width;
        //    panel4.Size = new Size(h - 5, panel4.Size.Height);
        //    int t = panel4.Size.Width / 3;
        //    label17.Location = new Point(t, label17.Location.Y);

        //    w = 0; h = 0;
        //    w = Column1.Width + Column2.Width + Column3.Width + Column4.Width + Column5.Width;
        //    panel5.Location = new Point(w + 18, panel5.Location.Y);
        //    h = Column6.Width + Column7.Width;
        //    panel5.Size = new Size(h - 5, panel5.Size.Height);
        //    t = panel5.Size.Width / 3;
        //    label16.Location = new Point(t, label16.Location.Y);

        //    w = 0; h = 0;
        //    w = Column1.Width + Column2.Width + Column3.Width + Column4.Width + Column5.Width + Column6.Width + Column7.Width;
        //    panel6.Location = new Point(w + 18, panel6.Location.Y);
        //    h = Column8.Width + Column9.Width;
        //    panel6.Size = new Size(h - 5, panel6.Size.Height);
        //    t = panel6.Size.Width / 3;
        //    label18.Location = new Point(t, label17.Location.Y);

        //    Graphics g = this.CreateGraphics();
        //    g.Clear(Color.White);
        //    Pen p = new Pen(Color.Black, 5);
        //    g.DrawRectangle(p, panel4.Left - 1, panel4.Top - 1, panel4.Width + 1, panel4.Height + 1);
        //    g.DrawRectangle(p, panel5.Left - 1, panel5.Top - 1, panel5.Width + 1, panel5.Height + 1);
        //    g.DrawRectangle(p, panel6.Left - 1, panel6.Top - 1, panel6.Width + 1, panel6.Height + 1);

        //    if (cam == false)
        //    {
        //        ReporteVentas_Load(sender, e);
        //        //cam = true;
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio.Reportes.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ReporteVentaContado reporteVentaContado = new ReporteVentaContado();
            reporteVentaContado.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ReporteVentaContado reporteVentaContado = new ReporteVentaContado();
            reporteVentaContado.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            ReporteVentaCredito reporteVentaCredito = new ReporteVentaCredito();
            reporteVentaCredito.Show();
        }

        private void ReporteVentas_Load_1(object sender, EventArgs e)
        {
            //paneles superiores al data
            int w = 0, h = 0;
            w = Column1.Width + Column2.Width + Column3.Width;
            panel4.Location = new Point(w + 18, dataGridView1.Location.Y-panel4.Height);
            h = Column4.Width + Column5.Width;
            panel4.Size = new Size(h - 5, panel4.Size.Height);
            int t = panel4.Size.Width / 3;
            label17.Location = new Point(t, label17.Location.Y);

            w = 0; h = 0;
            w = Column1.Width + Column2.Width + Column3.Width + Column4.Width + Column5.Width;
            panel5.Location = new Point(w + 18, dataGridView1.Location.Y - panel5.Height);
            h = Column6.Width + Column7.Width;
            panel5.Size = new Size(h - 5, panel5.Size.Height);
            t = panel5.Size.Width / 3;
            label16.Location = new Point(t, label16.Location.Y);

            w = 0; h = 0;
            w = Column1.Width + Column2.Width + Column3.Width + Column4.Width + Column5.Width + Column6.Width + Column7.Width;
            panel6.Location = new Point(w + 18, dataGridView1.Location.Y - panel6.Height);
            h = Column8.Width + Column9.Width;
            panel6.Size = new Size(h - 5, panel6.Size.Height);
            t = panel6.Size.Width / 3;
            label18.Location = new Point(t, label17.Location.Y);

            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen p = new Pen(Color.Black, 5);
            g.DrawRectangle(p, panel4.Left - 1, panel4.Top - 1, panel4.Width + 1, panel4.Height + 1);
            g.DrawRectangle(p, panel5.Left - 1, panel5.Top - 1, panel5.Width + 1, panel5.Height + 1);
            g.DrawRectangle(p, panel6.Left - 1, panel6.Top - 1, panel6.Width + 1, panel6.Height + 1);
        }

        private void ReporteVentas_SizeChanged_1(object sender, EventArgs e)
        {
            ReporteVentas_Load_1(sender, e);
        }
    }
}
