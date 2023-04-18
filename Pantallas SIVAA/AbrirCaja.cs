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
    public partial class AbrirCaja : Form
    {

        Empleado _pqt;
        public static CorteDeCaja corteDeCaja = new CorteDeCaja();
        EmpleadoLog emplog = new EmpleadoLog();
        CorteCajaLog PqteLog2 = new CorteCajaLog();
        public AbrirCaja(Empleado pqt)
        {
            InitializeComponent();
            _pqt = pqt;
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.inicio.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            corteDeCaja.Show();

        }

        private void AbrirCaja_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            string time = DateTime.Now.ToString("HH:mm");
            TXTHORA.Text = time;
            string dia = DateTime.Now.ToString("dd");
            numericUpDown13.Value = int.Parse(dia);
            string mes = DateTime.Now.ToString("MM");
            numericUpDown12.Value = int.Parse(mes);
            string an = DateTime.Now.ToString("yyyy");
            numericUpDown10.Value = int.Parse(an);
            CorteCaja cor = PqteLog2.BuscarCajaAbierta();
            if (cor != null)
            {
                MessageBox.Show("Ya hay una caja abierta");
                button1.Enabled = false;
            }
            else
            if (cor == null)
            {
                //MessageBox.Show("Ya hay una caja abierta");
                button1.Enabled = true;
            }
            switch (_pqt.Tipo.Trim())
            {
                case "Atencion":
                    // Funciones activas: Citas e inventario
                    lblTipoEmpleado.Text = _pqt.Tipo + " a clientes";
                    lblNombre.Text = "Bienvenido: " + _pqt.Nombre + " " + _pqt.ApellidoPat;


                    // Menu lateral
                    btnCitas.Enabled = true;
                    btnStock.Enabled = true;
                    btnReportes.Enabled = false;
                    btnPedidos.Enabled = false;
                    btnVentas.Enabled = false;
                    btnCobros.Enabled = false;
                    break;
                case "Vendedor":
                    // Funciones activas: ventas, inventario y citas
                    lblTipoEmpleado.Text = _pqt.Tipo;
                    lblNombre.Text = "Bienvenido: " + _pqt.Nombre + " " + _pqt.ApellidoPat;


                    //Menu lateral
                    btnCitas.Enabled = true;
                    btnStock.Enabled = true;
                    btnReportes.Enabled = false;
                    btnPedidos.Enabled = false;
                    btnVentas.Enabled = true;
                    btnCobros.Enabled = false;
                    break;
                // más casos...
                case "Cajero":


                    // El cajero no pasa por aqui, se va directo al apartado de caja

                    break;
                case "Supervisor":
                    // Todo esta activado, es la vista de supervisor
                    lblTipoEmpleado.Text = _pqt.Tipo;
                    lblNombre.Text = "Bienvenido: " + _pqt.Nombre + " " + _pqt.ApellidoPat;
                    break;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Random rn = new Random();
            int k = rn.Next(100, 300);
            CorteCaja pqt; ;
            //VentaContado Deb;
            //VentaCredito Deb2;
            if (label55.Text == "")
            {
                label55.Text = "0";
            }
            if (double.Parse(label55.Text) > 0)
            {
                try
                {
                    pqt = new CorteCaja
                    {
                        IDCorteCaja = Convert.ToString("CC" + k),
                        IDEmpleado = Convert.ToString(txtid.Text),
                        Dia = Convert.ToInt32(numericUpDown13.Value),
                        Mes = Convert.ToInt32(numericUpDown12.Value),
                        Año = Convert.ToInt32(numericUpDown10.Value),
                        Hora = Convert.ToString(TXTHORA.Text),
                        FondoInicial = Convert.ToDouble(label55.Text),
                        EfectivoFinal = Convert.ToDouble("0"),
                        TarjetaFinal = Convert.ToDouble("0"),
                        TotalFinal = Convert.ToDouble("0"),
                        BalanceEfectivo = Convert.ToDouble("0"),
                        BalanceTarjeta = Convert.ToDouble("0"),
                        Estado = Convert.ToString("ACTIVA")

                    };
                    PqteLog2.Registrar(pqt);

                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        MessageBox.Show("Caja abierta con exito");
                        //Limpiar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
            else
            {
                MessageBox.Show("Una caja no se puede abrir con tan poco dinero");
                return;
            }
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            double total = 0;
            double billetes = 0;
            //Billetes
            billetes += (((double)numericUpDown6.Value) * 20);
            billetes += (((double)numericUpDown5.Value) * 50);
            billetes += (((double)numericUpDown4.Value) * 100);
            billetes += (((double)numericUpDown3.Value) * 200);
            billetes += (((double)numericUpDown2.Value) * 500);
            billetes += (((double)numericUpDown1.Value) * 1000);
            label53.Text = billetes.ToString();
            double monedas = 0;
            //Monedas
            monedas += (((double)numericUpDown14.Value) * 10);
            monedas += (((double)numericUpDown17.Value) * 5);
            monedas += (((double)numericUpDown16.Value) * 2);
            monedas += (((double)numericUpDown15.Value) * 1);
            label54.Text = monedas.ToString();
            total = monedas + billetes;
            label55.Text = total.ToString();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            List<Empleado> listado = emplog.ListadoAllCajeros();

            //string n = TXTIDCLI.Text;
            //string a = TXTAPP.Text;
            //if (TXTAPP.Text == "" || TXTIDCLI.Text == "")
            //{
            //    MessageBox.Show("Favor de llenar los campos");
            //    return;
            //}
            //List<Cliente> listado = PqteLog.ListadoPorNA(n, a);
            if (listado.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = listado;
                dataGridView1.Columns["Column1"].DataPropertyName = "Nombre";
                dataGridView1.Columns["Column2"].DataPropertyName = "ApellidoPat";
                dataGridView1.Columns["Column3"].DataPropertyName = "ApellidoMat";
                dataGridView1.Columns["Column4"].DataPropertyName = "Correo";
                dataGridView1.Columns["Column5"].DataPropertyName = "IDEmpleado";
            }
            else
            {
                MessageBox.Show("No hay registro de empleados que sean cajeros");
                return;
            }
            //mostrarcotizaciones();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {
                int i = dataGridView1.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                txtid.Text = dataGridView1[0, i].Value.ToString();
                txtnom.Text = dataGridView1[1, i].Value.ToString();
                txtap.Text = dataGridView1[2, i].Value.ToString();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm");
            TXTHORA.Text = time;
        }

        private void btnIrCaja_Click(object sender, EventArgs e)
        {
            corteDeCaja.Show();
        }
        public static PagoLog Pqtelog7 = new PagoLog();
        public static AbonoLog Pqtelog8 = new AbonoLog();
        public static CortePagoLog Pqtelog9 = new CortePagoLog();
        public static CorteAbonoLogcs Pqtelog10 = new CorteAbonoLogcs();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            double efeini, efefin;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Favor de llenar los campos requeridos");
                return;
            }
            efeini = double.Parse(textBox1.Text);
            efefin = double.Parse(textBox2.Text);

            CorteCaja pqte;
            CorteCaja pqt;
            pqte = PqteLog2.BuscarCajaAbierta();
            if (pqte != null)
            {
                //Busqueda en efectivo y tarjeta de abono
                Abono abefec = Pqtelog8.BuscarAbonosEfec(pqte.IDCorteCaja);
                Abono abtar = Pqtelog8.BuscarAbonosTar(pqte.IDCorteCaja);
                //Busqueda en efectivo y tarjeta de pagos
                Pago paefec = Pqtelog7.BuscarPAGOSEfec(pqte.IDCorteCaja);
                Pago patar = Pqtelog7.BuscarPAGOSTar(pqte.IDCorteCaja);
                //MessageBox.Show("id = "+ab.IDVenta+"\r\nsaldoAnt = "+ab.SaldoAnterior);
                double abonosefec = 0, abonostar = 0;
                double pagosefec = 0, pagostar = 0;
                double balancefec = 0;
                double balancetar = 0;
                //if (abefec == null || abtar==null || paefec == null || patar == null)
                //{
                //    balancefec = abonosefec + pagosefec;
                //    balancetar = abonostar + pagostar;
                //    //san = cre.TotalFinal;
                //}
                //else
                //{
                //    abonosefec = abefec.SaldoAnterior;
                //    abonostar=abtar.SaldoAnterior;
                //    pagosefec = paefec.Monto;
                //    pagostar = patar.Monto;

                //}
                if (abefec == null)
                {
                    abonosefec = 0;

                    //san = cre.TotalFinal;
                }
                else
                {
                    abonosefec = abefec.SaldoAnterior;
                }
                if (paefec == null)
                {
                    pagosefec = 0;

                    //san = cre.TotalFinal;
                }
                else
                {
                    pagosefec = paefec.Monto;
                }
                if (abtar == null)
                {
                    abonostar = 0;

                    //san = cre.TotalFinal;
                }
                else
                {
                    abonostar = abtar.SaldoAnterior;
                }
                if (patar == null)
                {
                    pagostar = 0;

                    //san = cre.TotalFinal;
                }
                else
                {
                    pagostar = patar.Monto;
                }
                MessageBox.Show("abonosefec = " + abonosefec + "\r\nabonostar = " + abonostar + "\r\npagosefec" + pagosefec + "\r\npagostar = " + pagostar);
                balancefec = abonosefec + pagosefec;
                balancetar = abonostar + pagostar;
                MessageBox.Show("balandeefec = " + balancefec + "\r\nbalancetar = " + balancetar);
                //if (paefec == null || patar == null)
                //{
                //    balancefec = abonosefec + pagosefec;
                //    //san = cre.TotalFinal;
                //}
                //else
                //{
                //    balancefec = abonosefec + pagosefec;
                //}
                //Busqueda en efectivo de abono y pagos

                //Actualizacion del corte
                pqt = new CorteCaja
                {
                    IDCorteCaja = Convert.ToString(pqte.IDCorteCaja.ToString()),
                    IDEmpleado = Convert.ToString(pqte.IDEmpleado.ToString()),
                    Dia = Convert.ToInt32(pqte.Dia),
                    Mes = Convert.ToInt32(pqte.Mes),
                    Año = Convert.ToInt32(pqte.Año),
                    Hora = Convert.ToString(pqte.Hora),
                    FondoInicial = Convert.ToDouble(pqte.FondoInicial),
                    EfectivoFinal = Convert.ToDouble(efeini),
                    TarjetaFinal = Convert.ToDouble(efefin),
                    TotalFinal = Convert.ToDouble(efefin + efeini),
                    BalanceEfectivo = Convert.ToDouble(balancefec),
                    BalanceTarjeta = Convert.ToDouble(balancetar),
                    Estado = Convert.ToString("FINALIZADO")

                };
                //PqteLog2.Registrar(pqt);
                PqteLog2.ModificarEstado(pqt);
                MessageBox.Show("Cierre de caja exitoso");
            }
        }
    }
}
