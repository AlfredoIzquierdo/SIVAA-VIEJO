using Entidades;
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
using Datos;
using Logicas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pantallas_SIVAA
{
    public partial class Ventas : Form
    {
        readonly ClienteLog PqteLog = new ClienteLog();
        readonly VentaLog PqteLog2 = new VentaLog();
        readonly VentaContadoLog PqteLog3 = new VentaContadoLog();
        readonly VentaCreditoLog PqteLog33 = new VentaCreditoLog();
        readonly CotizacionCreditoLog PqteLog6 = new CotizacionCreditoLog();
        readonly CotizacionLog PqteLog4 = new CotizacionLog();
        readonly UnidadLog PqteLog5 = new UnidadLog();
        readonly CotizacionContadoLog PqteLog7 = new CotizacionContadoLog();
        string[] vehiculosD = { "", "", "" };
        int activarPagare = 0;

        public Ventas()
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
            Inicio.Stock.Show(); ;
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
        public void Limpiar()
        {
            //Cosas de credito
            txtmensualidad.Text = "0";
            txtanualidad.Text = "0";
            txtenganche.Text = "0";
            numericUpDown1.Value = 1;

            //Cosas de venta
            TXTCOT.Text = "";
            TXTIDCLI.Text = "";
            txtid.Text = "";
            txtap.Text = "";
            TXTAPP.Text = "";
            txtnom.Text = "";
            TXTPRECIO.Text = "0";

            //datas
            //dataGridView1.DataSource = "";
            //dataGridView2.DataSource = "";
            dgvElegirAuto.DataSource = "";
            dataGridView4.DataSource = "";
            dataGridView5.DataSource = "";
            dgvElegirVenta.DataSource = "";
        }
        Random rn = new Random();

        int k = 230;
        private void button1_Click(object sender, EventArgs e)
        {
            Venta pqt; ;
            VentaContado Deb;
            VentaCredito Deb2;
            k = rn.Next(250, 600);
            if (!radioButton2.Checked && !radioButton1.Checked)
            {
                MessageBox.Show("Favor de selecionar un tipo de venta");
                return;
            }
            if (radioButton2.Checked)
            {
                try
                {
                    pqt = new Venta
                    {
                        IDVenta = Convert.ToString("V" + k),
                        IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                        NoSerie = "",
                        Dia = Convert.ToInt32(numericUpDown2.Value),
                        Mes = Convert.ToInt32(numericUpDown3.Value),
                        Año = Convert.ToInt32(numericUpDown4.Value),
                        Hora = Convert.ToString(TXTHORA.Text),
                        Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                        TipoVenta = Convert.ToString("CONTADO")

                    };
                    PqteLog2.Registrar(pqt);

                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Venta guardada exitosamente en la B.D");
                        //Limpiar();

                        //Metodo de factura
                        //vehiculosD[0] = txtVehiculo.Text;
                        //vehiculosD[1] = txtVersion.Text;
                        //vehiculosD[2] = txtAño.Text;
                        //string id = txtid.Text;
                        //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                        //factura.Show();
                    }
                    //Parte donde se guarda la venta a contado
                    if (radioButton2.Checked && PqteLog2.Mensaje.Length == 0)
                    {
                        //double men = 0;
                        //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                        //int c = int.Parse(txtCod.Text + 2);

                        Deb = new VentaContado
                        {
                            IDVenta = Convert.ToString("V" + k),
                            IDCotizacion = Convert.ToString(TXTCOT.Text),
                            Estatus = Convert.ToString("PENDIENTE"),
                        };
                        PqteLog3.Registrar(Deb);
                        if (PqteLog3.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog3.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Venta guardada exitosamente en la B.D \r\n\r\n Folio de pago = " + Deb.IDVenta.ToString());
                            k++;
                            btncompraven.Enabled = true;
                            //Limpiar();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
            if (radioButton1.Checked)
            {
                try
                {
                    pqt = new Venta
                    {
                        IDVenta = Convert.ToString("V" + k),
                        IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                        NoSerie = "",
                        Dia = Convert.ToInt32(numericUpDown2.Value),
                        Mes = Convert.ToInt32(numericUpDown3.Value),
                        Año = Convert.ToInt32(numericUpDown4.Value),
                        Hora = Convert.ToString(TXTHORA.Text),
                        Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                        TipoVenta = Convert.ToString("CREDITO")

                    };
                    PqteLog2.Registrar(pqt);

                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Venta guardada exitosamente en la B.D");
                        //Limpiar();
                        //Metodo de factura
                        //vehiculosD[0] = txtVehiculo.Text;
                        //vehiculosD[1] = txtVersion.Text;
                        //vehiculosD[2] = txtAño.Text;
                        //string id = txtid.Text;
                        //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                        //factura.Show();
                    }
                    //Parte donde se guarda la venta a credito
                    if (radioButton1.Checked && PqteLog2.Mensaje.Length == 0)
                    {
                        //double men = 0;
                        //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                        //int c = int.Parse(txtCod.Text + 2);

                        Deb2 = new VentaCredito
                        {

                            IDVenta = Convert.ToString("V" + k),
                            IDCotizacion = Convert.ToString(TXTCOT.Text),
                            TotalFinal = Convert.ToDouble(double.Parse(TXTPRECIO.Text) * 1.10),
                            Estatus = Convert.ToString("PENDIENTE"),

                            //Estatus = Convert.ToString("PENDIENTE")

                        };
                        PqteLog33.Registrar(Deb2);
                        if (PqteLog33.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog33.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Venta guardada exitosamente en la B.D \r\n\r\n Folio de venta = " + Deb2.IDVenta.ToString());
                            k++;
                            btnpagare.Enabled = true;

                            //Limpiar();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            //MOSTRARVENTAS();
        }
        //public void MOSTRARCLIENTES()
        //{
        //    //Se usa el metodo LISTADOALL() para que nos devuelva un listado con todos los registros en esa tabla
        //    List<Cliente> listado = PqteLog.ListadoAll();
        //    if (listado.Count > 0)
        //    {
        //        dataGridView1.AutoGenerateColumns = false;
        //        dataGridView1.DataSource = listado;
        //        dataGridView1.Columns["Column1"].DataPropertyName = "IDCliente";
        //        dataGridView1.Columns["Column2"].DataPropertyName = "Nombre";
        //        dataGridView1.Columns["Column3"].DataPropertyName = "ApellidoPat";
        //        dataGridView1.Columns["Column4"].DataPropertyName = "ApellidoMat";
        //        dataGridView1.Columns["Column5"].DataPropertyName = "RFC";
        //        dataGridView1.Columns["Column6"].DataPropertyName = "Correo";
        //        dataGridView1.Columns["Column7"].DataPropertyName = "Telefono";
        //        dataGridView1.Columns["Column8"].DataPropertyName = "NoExterior";
        //        dataGridView1.Columns["Column9"].DataPropertyName = "Colonia";
        //        dataGridView1.Columns["Column10"].DataPropertyName = "Ciudad";
        //        dataGridView1.Columns["Column11"].DataPropertyName = "Estado";
        //    }
        //    else
        //        MessageBox.Show("No hay registro de Clientes");
        //    dataGridView1.ClearSelection();
        //}
        //public void MOSTRARVENTAS()
        //{
        //    dataGridView2.Rows.Clear();
        //    //Se usa el metodo LISTADOALL() para que nos devuelva un listado con todos los registros en esa tabla
        //    List<Venta> listado = PqteLog2.ListadoAll();
        //    if (listado.Count > 0)
        //    {
        //        dataGridView2.AutoGenerateColumns = false;
        //        dataGridView2.DataSource = listado;
        //        dataGridView2.Columns["Column12"].DataPropertyName = "IDVenta";
        //        dataGridView2.Columns["Column13"].DataPropertyName = "IDEmpleado";
        //        dataGridView2.Columns["Column14"].DataPropertyName = "NoSerie";
        //        dataGridView2.Columns["Column15"].DataPropertyName = "Dia";
        //        dataGridView2.Columns["Column16"].DataPropertyName = "Mes";
        //        dataGridView2.Columns["Column17"].DataPropertyName = "Año";
        //        dataGridView2.Columns["Column18"].DataPropertyName = "Hora";
        //        dataGridView2.Columns["Column19"].DataPropertyName = "SubTotal";
        //        dataGridView2.Columns["Column20"].DataPropertyName = "TipoVenta";
        //    }
        //    else
        //        MessageBox.Show("No hay registro de Ventas");
        //    dataGridView2.ClearSelection();
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            string n = TXTIDCLI.Text;
            string a = TXTAPP.Text;
            if (TXTAPP.Text == "" || TXTIDCLI.Text == "")
            {
                MessageBox.Show("Favor de llenar los campos");
                return;
            }
            List<Cliente> listado = PqteLog.ListadoPorNA(n, a);
            if (listado.Count > 0)
            {
                dataGridView4.AutoGenerateColumns = false;
                dataGridView4.DataSource = listado;
                dataGridView4.Columns["Column25"].DataPropertyName = "IDCliente";
                dataGridView4.Columns["Column26"].DataPropertyName = "Nombre";
                dataGridView4.Columns["Column27"].DataPropertyName = "ApellidoPat";
                dataGridView4.Columns["Column28"].DataPropertyName = "ApellidoMat";
                dataGridView4.Columns["Column29"].DataPropertyName = "RFC";
            }
            else
            {
                MessageBox.Show("No hay registro de Clientes con esos campos");
                return;
            }
            //mostrarcotizaciones();
            dataGridView4.ClearSelection();
        }
        public void mostrarcotizaciones()
        {
            string n = txtid.Text;
            //MessageBox.Show("cli = " + n);
            //if (txtid.Text == "" || txtid.Text == "IDCli")
            //{
            //    MessageBox.Show("Favor de llenar los campos");
            //    return;
            //}
            List<Entidades.Cotizacion> listado = PqteLog4.ListadoAllEsp(n);
            if (listado.Count > 0)
            {
                dataGridView5.AutoGenerateColumns = false;
                dataGridView5.DataSource = listado;
                dataGridView5.Columns["Column30"].DataPropertyName = "IDCotizacion";
                dataGridView5.Columns["Column31"].DataPropertyName = "IDCliente";
                dataGridView5.Columns["Column32"].DataPropertyName = "IDVersion";
                dataGridView5.Columns["Column33"].DataPropertyName = "Dia";
                dataGridView5.Columns["Column34"].DataPropertyName = "Mes";
                dataGridView5.Columns["Column35"].DataPropertyName = "PrecioInicial";
            }
            else
                MessageBox.Show("No hay registro de cotizacion a contado de ese cliente");
            dataGridView5.ClearSelection();
        }
        public void mostrarcotizacionescredito()
        {
            string n = txtid.Text;
            //MessageBox.Show("cli = " + n);
            //if (txtid.Text == "" || txtid.Text == "IDCli")
            //{
            //    MessageBox.Show("Favor de llenar los campos");
            //    return;
            //}
            List<Entidades.Cotizacion> listado = PqteLog4.ListadoAllEspCred(n);
            if (listado.Count > 0)
            {
                dataGridView5.AutoGenerateColumns = false;
                dataGridView5.DataSource = listado;
                dataGridView5.Columns["Column30"].DataPropertyName = "IDCotizacion";
                dataGridView5.Columns["Column31"].DataPropertyName = "IDCliente";
                dataGridView5.Columns["Column32"].DataPropertyName = "IDVersion";
                dataGridView5.Columns["Column33"].DataPropertyName = "Dia";
                dataGridView5.Columns["Column34"].DataPropertyName = "Mes";
                dataGridView5.Columns["Column35"].DataPropertyName = "PrecioInicial";
            }
            else
                MessageBox.Show("No hay registro de cotizaciones a credito de ese cliente");
            dataGridView5.ClearSelection();
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            string n = txtid.Text;

            if (txtid.Text == "" || txtid.Text == "IDCli")
            {
                MessageBox.Show("Favor de llenar los campos");
                return;
            }
            List<Entidades.Cotizacion> listado = PqteLog4.ListadoAllEsp(n);
            if (listado.Count > 0)
            {
                dataGridView5.AutoGenerateColumns = false;
                dataGridView5.DataSource = listado;
                dataGridView5.Columns["Column30"].DataPropertyName = "IDCotizacion";
                dataGridView5.Columns["Column31"].DataPropertyName = "IDCliente";
                dataGridView5.Columns["Column32"].DataPropertyName = "IDVersion";
                dataGridView5.Columns["Column33"].DataPropertyName = "Dia";
                dataGridView5.Columns["Column34"].DataPropertyName = "Mes";
                dataGridView5.Columns["Column35"].DataPropertyName = "PrecioInicial";
            }
            else
                MessageBox.Show("No hay registro de cotizacion de ese cliente");
            dataGridView5.ClearSelection();
        }

        private void dataGridView4_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentCell.RowIndex >= 0)
            {
                int i = dataGridView4.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                txtid.Text = dataGridView4[0, i].Value.ToString();
                txtnom.Text = dataGridView4[1, i].Value.ToString();
                txtap.Text = dataGridView4[2, i].Value.ToString();
            }
        }
        string codv = "";
        private void dataGridView5_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentCell.RowIndex >= 0)
            {
                if (radioButton2.Checked)
                {
                    int i = dataGridView5.CurrentCell.RowIndex;
                    //MessageBox.Show("Columna " + i);
                    TXTCOT.Text = dataGridView5[0, i].Value.ToString();
                    TXTPRECIO.Text = dataGridView5[5, i].Value.ToString();
                    codv = dataGridView5[2, i].Value.ToString();



                    Entidades.Cotizacion cot = PqteLog4.LeerPorClave(TXTCOT.Text);
                    string vers = cot.IDVersion.ToString();

                    //Coloca los datos de la version en los text
                    AutoNoUsar aut = PqteLog5.BuscarAuto(vers);
                    txtAño.Text = aut.Modelo.ToString();
                    txtVehiculo.Text = aut.Vehiculo.ToString();
                    txtVersion.Text = aut.Version.ToString();

                    //Verifica que existan unidades del auto de esa cotizacion

                    List<UnidadNoUsar> lis = PqteLog5.ListadoESPECIFICO(vers);
                    if (lis.Count > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Por el momento no contamos con unidades de esa version de auto");
                        return;
                    }

                }
                if (radioButton1.Checked)
                {
                    int i = dataGridView5.CurrentCell.RowIndex;
                    //MessageBox.Show("Columna " + i);
                    TXTCOT.Text = dataGridView5[0, i].Value.ToString();
                    TXTPRECIO.Text = dataGridView5[5, i].Value.ToString();
                    codv = dataGridView5[2, i].Value.ToString();
                    //Busca los datos de la cotizacion de credito
                    //string cod=TXTCOT.Text;
                    CotizacionCredito pqt = PqteLog6.LeerPorClave(TXTCOT.Text);
                    numericUpDown5.Value = pqt.Plazo;
                    textBox6.Text = pqt.Anualidad.ToString();
                    textBox7.Text = pqt.Enganche.ToString();
                    textBox5.Text = pqt.Mensualidad.ToString();

                    //Busca los datos de la cotizacion
                    Entidades.Cotizacion cot = PqteLog4.LeerPorClave(TXTCOT.Text);
                    string vers = cot.IDVersion.ToString();

                    //Coloca los datos de la version en los text
                    AutoNoUsar aut = PqteLog5.BuscarAuto(vers);
                    txtAño.Text = aut.Modelo.ToString();
                    txtVehiculo.Text = aut.Vehiculo.ToString();
                    txtVersion.Text = aut.Version.ToString();

                    //Verifica que existan unidades del auto de esa cotizacion

                    List<UnidadNoUsar> lis = PqteLog5.ListadoESPECIFICO(vers);
                    if (lis.Count > 0)
                    {
                    }
                    else
                    {
                        MessageBox.Show("Por el momento no contamos con unidades de esa version de auto");
                        return;
                    }
                }
            }
        }
        public void mostrarUnidades(string idventa, string tipoven)
        {
            string ver = "";
            //idventa = textBox7.Text;
            if (idventa == "")
            {
                MessageBox.Show("Favor de llenar los campos");
                return;
            }
            Venta ven = PqteLog2.LeerPorClave(idventa);
            //MessageBox.Show("Tipo de venta = " + ven.TipoVenta.ToString()+".");
            if (tipoven == "CONTADO   ")
            {
                //MessageBox.Show("Entro contado");
                VentaContado vencon = PqteLog3.LeerPorClave(idventa);
                Entidades.Cotizacion cot = PqteLog4.LeerPorClave(vencon.IDCotizacion.ToString());
                ver = cot.IDVersion.ToString();
            }
            if (tipoven == "CREDITO   ")
            {
                //MessageBox.Show("Entro Credito");
                VentaCredito vencre = PqteLog33.LeerPorClave(idventa);
                Entidades.Cotizacion cot = PqteLog4.LeerPorClave(vencre.IDCotizacion.ToString());
                ver = cot.IDVersion.ToString();
            }
            //MessageBox.Show("idversion = " + ver.ToString()); ;
            List<UnidadNoUsar> listado = PqteLog5.ListadoESPECIFICO(ver);
            if (listado.Count > 0)
            {
                dgvElegirAuto.AutoGenerateColumns = false;
                dgvElegirAuto.DataSource = listado;
                dgvElegirAuto.Columns["Column21"].DataPropertyName = "NoSerie";
                dgvElegirAuto.Columns["Column22"].DataPropertyName = "Vehiculo";
                dgvElegirAuto.Columns["Column23"].DataPropertyName = "Version";
                dgvElegirAuto.Columns["Column24"].DataPropertyName = "Modelo";
                dgvElegirAuto.Columns["Column36"].DataPropertyName = "Color";
            }
            else
                MessageBox.Show("No hay registro de ventas pendientes de ese cliente");
            dgvElegirAuto.ClearSelection();
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvElegirAuto.CurrentCell.RowIndex >= 0)
            {
                int i = dgvElegirAuto.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                txtColor.Text = dgvElegirAuto[4, i].Value.ToString();
                txtSerie.Text = dgvElegirAuto[0, i].Value.ToString();
                txtVehiculo.Text = dgvElegirAuto[1, i].Value.ToString();
                txtVersion.Text = dgvElegirAuto[2, i].Value.ToString();
                txtAño.Text = dgvElegirAuto[3, i].Value.ToString();
            }
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                mostrarcotizaciones();
            }
            if (radioButton1.Checked)
            {
                mostrarcotizacionescredito();
            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            //mostrarUnidades();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentCell.RowIndex >= 0)
            {
                int i = dataGridView4.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                txtid.Text = dataGridView4[0, i].Value.ToString();
                txtnom.Text = dataGridView4[1, i].Value.ToString();
                txtap.Text = dataGridView4[2, i].Value.ToString();
            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentCell.RowIndex >= 0)
            {
                int i = dataGridView4.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                txtid.Text = dataGridView4[0, i].Value.ToString();
                txtnom.Text = dataGridView4[1, i].Value.ToString();
                txtap.Text = dataGridView4[2, i].Value.ToString();
            }
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCliente_Click_1(object sender, EventArgs e)
        {

        }

        private void Ventas_Load_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            string time = DateTime.Now.ToString("HH:mm");
            TXTHORA.Text = time;
            string dia = DateTime.Now.ToString("dd");
            numericUpDown2.Value = int.Parse(dia);
            string mes = DateTime.Now.ToString("MM");
            numericUpDown3.Value = int.Parse(mes);
            string an = DateTime.Now.ToString("yyyy");
            numericUpDown4.Value = int.Parse(an);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm");
            TXTHORA.Text = time;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Venta pqt; ;
            VentaContado Deb;
            VentaCredito Deb2;
            k = rn.Next(250, 600);
            if (!radioButton2.Checked && !radioButton1.Checked)
            {
                MessageBox.Show("Favor de selecionar un tipo de venta");
                return;
            }
            if (radioButton2.Checked)
            {
                try
                {
                    pqt = new Venta
                    {
                        IDVenta = Convert.ToString("V" + k),
                        IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                        NoSerie = "",
                        Dia = Convert.ToInt32(numericUpDown2.Value),
                        Mes = Convert.ToInt32(numericUpDown3.Value),
                        Año = Convert.ToInt32(numericUpDown4.Value),
                        Hora = Convert.ToString(TXTHORA.Text),
                        Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                        TipoVenta = Convert.ToString("CONTADO")

                    };
                    PqteLog2.Registrar(pqt);

                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Venta guardada exitosamente en la B.D");
                        //Limpiar();

                        //Metodo de factura
                        //vehiculosD[0] = txtVehiculo.Text;
                        //vehiculosD[1] = txtVersion.Text;
                        //vehiculosD[2] = txtAño.Text;
                        //string id = txtid.Text;
                        //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                        //factura.Show();
                    }
                    //Parte donde se guarda la venta a contado
                    if (radioButton2.Checked && PqteLog2.Mensaje.Length == 0)
                    {
                        //double men = 0;
                        //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                        //int c = int.Parse(txtCod.Text + 2);

                        Deb = new VentaContado
                        {
                            IDVenta = Convert.ToString("V" + k),
                            IDCotizacion = Convert.ToString(TXTCOT.Text),
                            Estatus = Convert.ToString("PENDIENTE"),
                        };
                        PqteLog3.Registrar(Deb);
                        if (PqteLog3.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog3.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Venta guardada exitosamente en la B.D \r\n\r\n Folio de pago = " + Deb.IDVenta.ToString());
                            k++;
                            btncompraven.Enabled = true;
                            btnFactura.Enabled = true;
                            //Limpiar();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
            if (radioButton1.Checked)
            {
                try
                {
                    pqt = new Venta
                    {
                        IDVenta = Convert.ToString("V" + k),
                        IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                        NoSerie = "",
                        Dia = Convert.ToInt32(numericUpDown2.Value),
                        Mes = Convert.ToInt32(numericUpDown3.Value),
                        Año = Convert.ToInt32(numericUpDown4.Value),
                        Hora = Convert.ToString(TXTHORA.Text),
                        Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                        TipoVenta = Convert.ToString("CREDITO")

                    };
                    PqteLog2.Registrar(pqt);

                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Venta guardada exitosamente en la B.D");
                        //Limpiar();
                        //Metodo de factura
                        //vehiculosD[0] = txtVehiculo.Text;
                        //vehiculosD[1] = txtVersion.Text;
                        //vehiculosD[2] = txtAño.Text;
                        //string id = txtid.Text;
                        //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                        //factura.Show();
                    }
                    //Parte donde se guarda la venta a credito
                    if (radioButton1.Checked && PqteLog2.Mensaje.Length == 0)
                    {
                        //double men = 0;
                        //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                        //int c = int.Parse(txtCod.Text + 2);

                        Deb2 = new VentaCredito
                        {

                            IDVenta = Convert.ToString("V" + k),
                            IDCotizacion = Convert.ToString(TXTCOT.Text),
                            TotalFinal = Convert.ToDouble(double.Parse(TXTPRECIO.Text) * 1.10),
                            Estatus = Convert.ToString("PENDIENTE"),

                            //Estatus = Convert.ToString("PENDIENTE")

                        };
                        PqteLog33.Registrar(Deb2);
                        if (PqteLog33.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog33.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Venta guardada exitosamente en la B.D \r\n\r\n Folio de venta = " + Deb2.IDVenta.ToString());
                            k++;
                            btnpagare.Enabled = true;
                            btnFactura.Enabled = true;
                            btncompraven.Enabled = true;
                            //Limpiar();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
        }

        private void btncompraven_Click(object sender, EventArgs e)
        {
            Venta pqt = new Venta
            {
                IDVenta = Convert.ToString("V" + k),
                IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                NoSerie = "",
                Dia = Convert.ToInt32(numericUpDown2.Value),
                Mes = Convert.ToInt32(numericUpDown3.Value),
                Año = Convert.ToInt32(numericUpDown4.Value),
                Hora = Convert.ToString(TXTHORA.Text),
                Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                TipoVenta = Convert.ToString("CONTADO")

            };
            VentaContado Deb = new VentaContado
            {
                IDVenta = Convert.ToString("V" + k),
                IDCotizacion = Convert.ToString(TXTCOT.Text),
                Estatus = Convert.ToString("PENDIENTE"),
            };
            //contado
            if (radioButton2.Checked == true)
            {
                ContratoCompraVentaCon contratoCompraVentaCon = new ContratoCompraVentaCon(Deb, pqt, txtnom.Text, txtap.Text);
                contratoCompraVentaCon.Show();
            }
        }

        private void btnGuardarEntrega_Click(object sender, EventArgs e)
        {
            Venta pqt; ;

            k = rn.Next(250, 600);
            pqt = PqteLog2.LeerPorClave(textBox3.Text.ToString());

            if (pqt.TipoVenta == "CONTADO   ")
            {
                try
                {
                    string id = "", serie = "";
                    id = pqt.IDVenta;
                    serie = textBox4.Text;
                    PqteLog2.ModificarAuto(id, serie);

                    //Modificar estado de venta
                    string est = "FINALIZADO";
                    PqteLog3.ModificarEstatus(id, est);
                    //auto vendido modificar
                    string est2 = "Vendido";
                    string id2 = "";
                    id2 = serie;
                    //id2 = textBox3.Text;
                    PqteLog5.ModificarEstatus(serie, "Vendido");
                    //MessageBox.Show("serie= " + serie + "\r\nEstatus auto cambio= " + est2);
                    //MessageBox.Show("Estatus auto cambio= " + est2);
                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Venta guardada exitosamente en la B.D");
                        //Limpiar();

                        //Metodo de factura
                        //vehiculosD[0] = txtVehiculo.Text;
                        //vehiculosD[1] = txtVersion.Text;
                        //vehiculosD[2] = txtAño.Text;
                        //string id = txtid.Text;
                        //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                        //factura.Show();
                    }
                    //Parte donde se guarda la venta a contado
                    if (PqteLog2.Mensaje.Length == 0)
                    {

                        if (PqteLog5.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog3.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            //MessageBox.Show("Cambio de estatus exitoso en la B.D \r\n\r\n Estatus = " + est);
                            k++;
                            btncompraven.Enabled = true;
                            //Limpiar();
                        }
                        if (PqteLog3.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog3.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Cambio de estatus exitoso en la B.D \r\n\r\n Estatus = " + est);

                            k++;
                            btncompraven.Enabled = true;
                            //Limpiar();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
            //*************************************************************
            if (pqt.TipoVenta == "CREDITO   ")
            {
                try
                {
                    string id = "", serie = "";
                    id = pqt.IDVenta;
                    serie = textBox4.Text;
                    PqteLog2.ModificarAuto(id, serie);
                    //modificar auto vendido
                    string est2 = "Vendido";
                    string id2 = "";
                    id2 = serie;
                    //id2 = textBox3.Text;
                    PqteLog5.ModificarEstatus(id2, est2);
                    MessageBox.Show("serie= " + serie + "\r\nEstatus auto cambio= " + est2);
                    if (PqteLog5.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog3.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Cambio de estatus exitoso en la B.D \r\n\r\n Estatus = " + est2);
                        k++;
                        btncompraven.Enabled = true;
                        //Limpiar();
                    }
                    if (PqteLog2.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                    }
                    //Parte donde se guarda la venta a credito
                    if (PqteLog2.Mensaje.Length == 0)
                    {

                        string est = "ACTIVO";
                        PqteLog33.ModificarEstatus(id, est);
                        if (PqteLog33.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog33.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Cambio de estatus exitoso en la B.D \r\n\r\n Estatus = " + est);
                            k++;

                            btncompraven.Enabled = true;
                            //Limpiar();
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                }
            }
            LimpiarEntregas();
        }

        private void btnClienteEntrega_Click(object sender, EventArgs e)
        {
            mostrarventasentregaporcliente();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            //string n = ;

            //if (txtid.Text == "" || txtid.Text == "IDCli")
            //{
            //    MessageBox.Show("Favor de llenar los campos");
            //    return;
            //}
            List<VentasEntrega> listado = PqteLog2.ListadoAllVentasEntrega();
            if (listado.Count > 0)
            {
                dgvElegirVenta.AutoGenerateColumns = false;
                dgvElegirVenta.DataSource = listado;
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = "IDVenta";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "Nombre";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "ApellidoPaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = "ApellidoMaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = "Dia";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn6"].DataPropertyName = "Mes";
                dgvElegirVenta.Columns["Column37"].DataPropertyName = "Año";
                dgvElegirVenta.Columns["Column43"].DataPropertyName = "Hora";
                dgvElegirVenta.Columns["Column38"].DataPropertyName = "TipoVenta";
                dgvElegirVenta.Columns["Column39"].DataPropertyName = "Vehiculo";
                dgvElegirVenta.Columns["Column40"].DataPropertyName = "Version";
                dgvElegirVenta.Columns["Column41"].DataPropertyName = "Cilindraje";
                dgvElegirVenta.Columns["Column42"].DataPropertyName = "Transmision";
                dgvElegirVenta.Columns["Column1"].DataPropertyName = "Modelo";
                //dgvElegirVenta.AutoGenerateColumns = false;
                //dgvElegirVenta.DataSource = listado;
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = "IDVenta";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "Nombre";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "ApellidoPaterno";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = "ApellidoMaterno";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = "Dia";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn6"].DataPropertyName = "Mes";
                //dgvElegirVenta.Columns["Column37"].DataPropertyName = "Año";
                //dgvElegirVenta.Columns["Column44"].DataPropertyName = "Hora";
                //dgvElegirVenta.Columns["Column38"].DataPropertyName = "TipoVenta";
                //dgvElegirVenta.Columns["Column39"].DataPropertyName = "Vehiculo";
                //dgvElegirVenta.Columns["Column40"].DataPropertyName = "Version";
                //dgvElegirVenta.Columns["Column41"].DataPropertyName = "Cilindraje";
                //dgvElegirVenta.Columns["Column42"].DataPropertyName = "Transmision";
                //dgvElegirVenta.Columns["Column43"].DataPropertyName = "Modelo";
            }
            else
                MessageBox.Show("No hay ventas pendientes de entregar autos");
            dgvElegirVenta.ClearSelection();
        }

        private void cbFiltrarVentaEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltrarVentaEntrega.SelectedIndex == 0)
            {
                mostrarventasentregacontado();
            }
            if (cbFiltrarVentaEntrega.SelectedIndex == 1)
            {
                mostrarventasentregacredito();
            }
        }
        public void mostrarventasentregacontado()
        {
            List<VentasEntrega> listado = PqteLog2.ListadoAllVentasEntregaContado();
            if (listado.Count > 0)
            {
                dgvElegirVenta.AutoGenerateColumns = false;
                dgvElegirVenta.DataSource = listado;
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = "IDVenta";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "Nombre";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "ApellidoPaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = "ApellidoMaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = "Dia";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn6"].DataPropertyName = "Mes";
                dgvElegirVenta.Columns["Column37"].DataPropertyName = "Año";
                dgvElegirVenta.Columns["Column43"].DataPropertyName = "Hora";
                dgvElegirVenta.Columns["Column38"].DataPropertyName = "TipoVenta";
                dgvElegirVenta.Columns["Column39"].DataPropertyName = "Vehiculo";
                dgvElegirVenta.Columns["Column40"].DataPropertyName = "Version";
                dgvElegirVenta.Columns["Column41"].DataPropertyName = "Cilindraje";
                dgvElegirVenta.Columns["Column42"].DataPropertyName = "Transmision";
                dgvElegirVenta.Columns["Column1"].DataPropertyName = "Modelo";
            }
            else
            {
                MessageBox.Show("No hay ventas al contado pendientes de entregar autos");
                dgvElegirVenta.DataSource = "";
            }
            dgvElegirVenta.ClearSelection();
        }
        public void mostrarventasentregacredito()
        {
            List<VentasEntrega> listado = PqteLog2.ListadoAllVentasEntregaCredito();
            if (listado.Count > 0)
            {
                dgvElegirVenta.AutoGenerateColumns = false;
                dgvElegirVenta.DataSource = listado;
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = "IDVenta";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "Nombre";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "ApellidoPaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = "ApellidoMaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = "Dia";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn6"].DataPropertyName = "Mes";
                dgvElegirVenta.Columns["Column37"].DataPropertyName = "Año";
                dgvElegirVenta.Columns["Column43"].DataPropertyName = "Hora";
                dgvElegirVenta.Columns["Column38"].DataPropertyName = "TipoVenta";
                dgvElegirVenta.Columns["Column39"].DataPropertyName = "Vehiculo";
                dgvElegirVenta.Columns["Column40"].DataPropertyName = "Version";
                dgvElegirVenta.Columns["Column41"].DataPropertyName = "Cilindraje";
                dgvElegirVenta.Columns["Column42"].DataPropertyName = "Transmision";
                dgvElegirVenta.Columns["Column1"].DataPropertyName = "Modelo";
                //dgvElegirVenta.AutoGenerateColumns = false;
                //dgvElegirVenta.DataSource = listado;
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = "IDVenta";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "Nombre";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "ApellidoPaterno";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = "ApellidoMaterno";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = "Dia";
                //dgvElegirVenta.Columns["dataGridViewTextBoxColumn6"].DataPropertyName = "Mes";
                //dgvElegirVenta.Columns["Column37"].DataPropertyName = "Año";
                //dgvElegirVenta.Columns["Column44"].DataPropertyName = "Hora";
                //dgvElegirVenta.Columns["Column38"].DataPropertyName = "TipoVenta";
                //dgvElegirVenta.Columns["Column39"].DataPropertyName = "Vehiculo";
                //dgvElegirVenta.Columns["Column40"].DataPropertyName = "Version";
                //dgvElegirVenta.Columns["Column41"].DataPropertyName = "Cilindraje";
                //dgvElegirVenta.Columns["Column42"].DataPropertyName = "Transmision";
                //dgvElegirVenta.Columns["Column43"].DataPropertyName = "Modelo";
            }
            else
            {
                MessageBox.Show("No hay ventas a credito pendientes de entregar autos");
                dgvElegirVenta.DataSource = "";
            }
            dgvElegirVenta.ClearSelection();
        }
        public void mostrarventasentregaporcliente()
        {
            string nombre = textBox10.Text, apellido = textBox9.Text;
            if (nombre == "" || apellido == "")
            {
                MessageBox.Show("Favor de escribir el nombre y apellido del cliente para la busqueda");
                return;
            }
            List<VentasEntrega> listado = PqteLog2.Listaporcliente(nombre, apellido);
            if (listado.Count > 0)
            {
                dgvElegirVenta.AutoGenerateColumns = false;
                dgvElegirVenta.DataSource = listado;
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn1"].DataPropertyName = "IDVenta";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn2"].DataPropertyName = "Nombre";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn3"].DataPropertyName = "ApellidoPaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn4"].DataPropertyName = "ApellidoMaterno";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn5"].DataPropertyName = "Dia";
                dgvElegirVenta.Columns["dataGridViewTextBoxColumn6"].DataPropertyName = "Mes";
                dgvElegirVenta.Columns["Column37"].DataPropertyName = "Año";
                dgvElegirVenta.Columns["Column43"].DataPropertyName = "Hora";
                dgvElegirVenta.Columns["Column38"].DataPropertyName = "TipoVenta";
                dgvElegirVenta.Columns["Column39"].DataPropertyName = "Vehiculo";
                dgvElegirVenta.Columns["Column40"].DataPropertyName = "Version";
                dgvElegirVenta.Columns["Column41"].DataPropertyName = "Cilindraje";
                dgvElegirVenta.Columns["Column42"].DataPropertyName = "Transmision";
                dgvElegirVenta.Columns["Column1"].DataPropertyName = "Modelo";
            }
            else
            {
                MessageBox.Show("No hay ventas por entregar autos para ese cliente");
                dgvElegirVenta.DataSource = "";
            }
            dgvElegirVenta.ClearSelection();
        }

        private void dgvElegirVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvElegirVenta.CurrentCell.RowIndex >= 0)
            {
                int i = dgvElegirVenta.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                //Cliente
                textBox3.Text = dgvElegirVenta[0, i].Value.ToString();
                textBox2.Text = dgvElegirVenta[1, i].Value.ToString();
                textBox1.Text = dgvElegirVenta[2, i].Value.ToString();

                textBox11.Text = dgvElegirVenta[8, i].Value.ToString();

                //Auto
                //textBox2.Text = dgvElegirVenta[9, i].Value.ToString();
                //textBox3.Text = dgvElegirVenta[13, i].Value.ToString();
                //textBox4.Text = dgvElegirVenta[10, i].Value.ToString();
                textBox8.Text = dgvElegirVenta[9, i].Value.ToString();
                textBox13.Text = dgvElegirVenta[11, i].Value.ToString();
                textBox12.Text = dgvElegirVenta[10, i].Value.ToString();

                string idventa = textBox3.Text;
                string tipoven = textBox11.Text;
                mostrarUnidades(idventa, tipoven);
            }
        }
        public void LimpiarEntregas()
        {
            //Datos de entrega
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            textBox4.Text = "";
            textBox14.Text = "";
            //Datas de entrega
            dgvElegirVenta.DataSource = "";
            dgvElegirAuto.DataSource = "";

        }

        private void dgvElegirAuto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvElegirAuto.CurrentCell.RowIndex >= 0)
            {
                int i = dgvElegirAuto.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                //Auto
                textBox4.Text = dgvElegirAuto[0, i].Value.ToString();
                textBox14.Text = dgvElegirAuto[4, i].Value.ToString();

                //mostrarUnidades();
            }
        }

        private void tabControl3_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("favor de elegir una venta primero");
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            Venta pqt = new Venta
            {
                IDVenta = Convert.ToString("V" + k),
                IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                NoSerie = "",
                Dia = Convert.ToInt32(numericUpDown2.Value),
                Mes = Convert.ToInt32(numericUpDown3.Value),
                Año = Convert.ToInt32(numericUpDown4.Value),
                Hora = Convert.ToString(TXTHORA.Text),
                Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                TipoVenta = Convert.ToString("CREDITO")

            };
            VentaContado Deb = new VentaContado
            {
                IDVenta = Convert.ToString("V" + k),
                IDCotizacion = Convert.ToString(TXTCOT.Text),
                Estatus = Convert.ToString("PENDIENTE"),
            };
            VentaCredito Deb2 = new VentaCredito
            {

                IDVenta = Convert.ToString("V" + k),
                IDCotizacion = Convert.ToString(TXTCOT.Text),
                TotalFinal = Convert.ToDouble(double.Parse(TXTPRECIO.Text) * 1.10),
                Estatus = Convert.ToString("PENDIENTE"),

                //Estatus = Convert.ToString("PENDIENTE")

            };

            if (radioButton2.Checked == true)
            {
                Factura factura = new Factura(Deb, pqt, txtnom.Text, txtap.Text, TXTIDEMP.Text);
                factura.Show();
            }
            if (radioButton1.Checked == true)
            {
                FacturaCredito facturaCredito = new FacturaCredito(Deb2, pqt, txtnom.Text, txtap.Text, TXTIDEMP.Text);
                facturaCredito.Show();
            }
        }

        private void btnpagare_Click(object sender, EventArgs e)
        {
            Venta pqt = new Venta
            {
                IDVenta = Convert.ToString("V" + k),
                IDEmpleado = Convert.ToString(TXTIDEMP.Text),
                NoSerie = "",
                Dia = Convert.ToInt32(numericUpDown2.Value),
                Mes = Convert.ToInt32(numericUpDown3.Value),
                Año = Convert.ToInt32(numericUpDown4.Value),
                Hora = Convert.ToString(TXTHORA.Text),
                Subtotal = Convert.ToDouble(TXTPRECIO.Text),
                TipoVenta = Convert.ToString("CREDITO")

            };
            VentaCredito Deb2 = new VentaCredito
            {

                IDVenta = Convert.ToString("V" + k),
                IDCotizacion = Convert.ToString(TXTCOT.Text),
                TotalFinal = Convert.ToDouble(double.Parse(TXTPRECIO.Text) * 1.10),
                Estatus = Convert.ToString("PENDIENTE"),

                //Estatus = Convert.ToString("PENDIENTE")

            };
            Pagare pagare = new Pagare(pqt, Deb2, txtnom.Text, txtap.Text);
            pagare.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TablaAmortizacion tablaAmortizacion = new TablaAmortizacion("CO26");
            tablaAmortizacion.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string n = TXTIDCLI.Text;
            string a = TXTAPP.Text;
            if (TXTAPP.Text == "" || TXTIDCLI.Text == "")
            {
                MessageBox.Show("Favor de llenar los campos");
                return;
            }
            List<Cliente> listado = PqteLog.ListadoPorNA(n, a);
            if (listado.Count > 0)
            {
                dataGridView4.AutoGenerateColumns = false;
                dataGridView4.DataSource = listado;
                dataGridView4.Columns["Column25"].DataPropertyName = "IDCliente";
                dataGridView4.Columns["Column26"].DataPropertyName = "Nombre";
                dataGridView4.Columns["Column27"].DataPropertyName = "ApellidoPat";
                dataGridView4.Columns["Column28"].DataPropertyName = "ApellidoMat";
                dataGridView4.Columns["Column29"].DataPropertyName = "RFC";
            }
            else
            {
                MessageBox.Show("No hay registro de Clientes con esos campos");
                return;
            }
            //mostrarcotizaciones();
            dataGridView4.ClearSelection();
        }

        private void dataGridView4_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentCell.RowIndex >= 0)
            {
                int i = dataGridView4.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                txtid.Text = dataGridView4[0, i].Value.ToString();
                txtnom.Text = dataGridView4[1, i].Value.ToString();
                txtap.Text = dataGridView4[2, i].Value.ToString();
            }
        }

        private void dataGridView5_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentCell.RowIndex >= 0)
            {
                if (radioButton2.Checked)
                {
                    int i = dataGridView5.CurrentCell.RowIndex;
                    //MessageBox.Show("Columna " + i);
                    TXTCOT.Text = dataGridView5[0, i].Value.ToString();
                    TXTPRECIO.Text = dataGridView5[5, i].Value.ToString();
                    codv = dataGridView5[2, i].Value.ToString();
                }
                if (radioButton1.Checked)
                {
                    int i = dataGridView5.CurrentCell.RowIndex;
                    //MessageBox.Show("Columna " + i);
                    TXTCOT.Text = dataGridView5[0, i].Value.ToString();
                    TXTPRECIO.Text = dataGridView5[5, i].Value.ToString();
                    codv = dataGridView5[2, i].Value.ToString();
                    //Busca los datos de la cotizacion de credito
                    //string cod=TXTCOT.Text;
                    CotizacionCredito pqt = PqteLog6.LeerPorClave(TXTCOT.Text);
                    numericUpDown1.Value = pqt.Plazo;
                    txtanualidad.Text = pqt.Anualidad.ToString();
                    txtenganche.Text = pqt.Enganche.ToString();
                    txtmensualidad.Text = pqt.Mensualidad.ToString();
                }
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            string n = txtid.Text;

            if (txtid.Text == "" || txtid.Text == "IDCli")
            {
                MessageBox.Show("Favor de llenar los campos");
                return;
            }
            List<Entidades.Cotizacion> listado = PqteLog4.ListadoAllEsp(n);
            if (listado.Count > 0)
            {
                dataGridView5.AutoGenerateColumns = false;
                dataGridView5.DataSource = listado;
                dataGridView5.Columns["Column30"].DataPropertyName = "IDCotizacion";
                dataGridView5.Columns["Column31"].DataPropertyName = "IDCliente";
                dataGridView5.Columns["Column32"].DataPropertyName = "IDVersion";
                dataGridView5.Columns["Column33"].DataPropertyName = "Dia";
                dataGridView5.Columns["Column34"].DataPropertyName = "Mes";
                dataGridView5.Columns["Column35"].DataPropertyName = "PrecioInicial";
            }
            else
                MessageBox.Show("No hay registro de cotizacion de ese cliente");
            dataGridView5.ClearSelection();
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                mostrarcotizaciones();
            }
            if (radioButton1.Checked)
            {
                mostrarcotizacionescredito();
            }
        }

        private void txthoracot_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarClienteCot_Click(object sender, EventArgs e)
        {
            string n = txtNomClien.Text;
            string a = txtApClien.Text;
            if (txtApClien.Text == "" || txtNomClien.Text == "")
            {
                MessageBox.Show("Favor de llenar los campos");
                return;
            }
            List<Cliente> listado = PqteLog.ListadoPorNA(n, a);
            if (listado.Count > 0)
            {
                dgvClientCot.AutoGenerateColumns = false;
                dgvClientCot.DataSource = listado;
                dgvClientCot.Columns["dataGridViewTextBoxColumn7"].DataPropertyName = "IDCliente";
                dgvClientCot.Columns["dataGridViewTextBoxColumn8"].DataPropertyName = "Nombre";
                dgvClientCot.Columns["dataGridViewTextBoxColumn9"].DataPropertyName = "ApellidoPat";
                dgvClientCot.Columns["dataGridViewTextBoxColumn10"].DataPropertyName = "ApellidoMat";
                dgvClientCot.Columns["dataGridViewTextBoxColumn11"].DataPropertyName = "RFC";
            }
            else
            {
                MessageBox.Show("No hay registro de Clientes con esos campos");
                return;
            }
            //mostrarcotizaciones();
            dgvClientCot.ClearSelection();
        }

        private void dgvClientCot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientCot.CurrentCell.RowIndex >= 0)
            {
                int i = dgvClientCot.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                TXTIDCLIENTE.Text = dgvClientCot[0, i].Value.ToString();
                TXTNOMBRE.Text = dgvClientCot[1, i].Value.ToString();
                TXTAPELLIDO.Text = dgvClientCot[2, i].Value.ToString();
            }
        }

        private void tabCotizacion_Click(object sender, EventArgs e)
        {

        }

        private void tabCotizacion_Enter(object sender, EventArgs e)
        {
            comboVehiculo.SelectedItem = "March";
            ComboVersion1.SelectedItem = "SR";
            List<Unidad> Colores = new List<Unidad>();
            List<Modelo> Modelos = new List<Modelo>();
            Colores = PqteLog4.BuscarColores("SR", "March");
            Modelos = PqteLog4.ObtenerModeloPorNombre("SR", "March");
            foreach (Unidad color in Colores)
            {
                if (color.Estatus.Trim() == "Disponible")
                {
                    comboColor.Items.Add(color.Color);
                }

            }
            foreach (Modelo modelo in Modelos)
            {
                comboAno.Items.Add(modelo.Año);

            }


        }

        private void comboAno_SelectedValueChanged(object sender, EventArgs e)
        {
            ComprobarCamposLlenosCot();
        }
        private void ComprobarCamposLlenosCot()
        {
            bool vacio = false;
            //txPrecioCot.Text = "$1000000";
            if (string.IsNullOrEmpty(comboAno.Text) | string.IsNullOrEmpty(comboColor.Text) | string.IsNullOrEmpty(comboVehiculo.Text) | string.IsNullOrEmpty(ComboVersion1.Text))
            {

            }
            else
            {
                Versions versiondeseada = PqteLog4.ObtenerVersionPrecio(ComboVersion1.Text, comboVehiculo.Text);
                txPrecioCot.Text = versiondeseada.Costo.ToString();
            }

        }

        private void rbtnCredCot_CheckedChanged(object sender, EventArgs e)
        {
            groupCotCred.Enabled = true;
        }

        private void btnGuardarCot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboAno.Text) | string.IsNullOrEmpty(comboColor.Text) | string.IsNullOrEmpty(comboVehiculo.Text) | string.IsNullOrEmpty(ComboVersion1.Text))
            {
                MessageBox.Show("Por favor llene todo los campos");
            }
            else
            {
                Entidades.Cotizacion pqt;
                CotizacionContado Deb;
                CotizacionCredito Deb2;
                k = rn.Next(250, 600);
                if (!radioButton2.Checked && !radioButton1.Checked)
                {
                    MessageBox.Show("Favor de selecionar un tipo de Cotizacion");
                    return;
                }
                if (radioButton2.Checked)
                {
                    Versions versionSeleccionada = PqteLog4.ObtenerVersionPrecio(ComboVersion1.Text, comboVehiculo.Text);
                    int pruebadia = (int)numericdiacot.Value;
                    //try
                    //{
                    pqt = new Entidades.Cotizacion
                    {
                        IDCotizacion = Convert.ToString("CO" + k),
                        IDVersion = versionSeleccionada.IDVersion.Trim(),
                        IDCliente = Convert.ToString(TXTIDCLIENTE.Text),
                        IDEmpleado = TXTIDEMP.Text,
                        Dia = ((int)numericdiacot.Value),
                        Mes = (int)(numericmescot.Value),
                        Año = ((int)numericanocot.Value),
                        PrecioInicial = Convert.ToDouble(txPrecioCot.Text),
                        TipoPago = Convert.ToString("CONTADO"),
                        Hora = "10:00:00"

                    };
                    PqteLog4.Registrar(pqt);

                    if (PqteLog4.Mensaje.Length != 0)
                    {
                        //Hubo un error
                        MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                    }
                    else
                    {
                        //MessageBox.Show("Venta guardada exitosamente en la B.D");
                        //Limpiar();

                        //Metodo de factura
                        //vehiculosD[0] = txtVehiculo.Text;
                        //vehiculosD[1] = txtVersion.Text;
                        //vehiculosD[2] = txtAño.Text;
                        //string id = txtid.Text;
                        //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                        //factura.Show();
                    }
                    //Parte donde se guarda la venta a contado
                    if (radioButton2.Checked && PqteLog4.Mensaje.Length == 0)
                    {
                        //double men = 0;
                        //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                        //int c = int.Parse(txtCod.Text + 2);

                        Deb = new CotizacionContado
                        {
                            IDCotizacion = Convert.ToString("CO" + k),

                        };
                        PqteLog7.Registrar(Deb);
                        if (PqteLog3.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog3.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            MessageBox.Show("Cotizacion guardada exitosamente en la B.D \r\n\r\n Folio de pago = " + Deb.IDCotizacion.ToString());
                            k++;

                            //Limpiar();
                        }
                    }

                    //}
                    // catch (Exception ex)
                    //{
                    //MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                    //}
                }
                if (radioButton1.Checked)
                {
                    Versions versionseleccionada = PqteLog4.ObtenerVersionPrecio(ComboVersion1.Text, comboVehiculo.Text);
                    try
                    {
                        pqt = new Entidades.Cotizacion
                        {
                            IDCotizacion = Convert.ToString("CO" + k),
                            IDVersion = versionseleccionada.IDVersion,
                            IDCliente = Convert.ToString(TXTIDCLIENTE.Text),
                            IDEmpleado = TXTIDEMP.Text,
                            Dia = Convert.ToInt32(numericdiacot.Value),
                            Mes = Convert.ToInt32(numericmescot.Value),
                            Año = Convert.ToInt32(numericanocot.Value),
                            PrecioInicial = Convert.ToDouble(txPrecioCot.Text),
                            TipoPago = Convert.ToString("CREDITO"),
                            Hora = Convert.ToString(txthoracot.Text)

                        };
                        PqteLog4.Registrar(pqt);

                        if (PqteLog2.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            //MessageBox.Show("Venta guardada exitosamente en la B.D");
                            //Limpiar();
                            //Metodo de factura
                            //vehiculosD[0] = txtVehiculo.Text;
                            //vehiculosD[1] = txtVersion.Text;
                            //vehiculosD[2] = txtAño.Text;
                            //string id = txtid.Text;
                            //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                            //factura.Show();
                        }
                        //Parte donde se guarda la venta a credito
                        if (radioButton1.Checked && PqteLog2.Mensaje.Length == 0)
                        {
                            //double men = 0;
                            //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                            //int c = int.Parse(txtCod.Text + 2);

                            Deb2 = new CotizacionCredito
                            {


                                IDCotizacion = Convert.ToString("CO" + k),
                                Plazo = Convert.ToInt32(numericplazos.Value),
                                Enganche = Convert.ToDouble(txtengancheCot.Text),
                                Anualidad = Convert.ToDouble(txtanualidadCot.Text),
                                Precio = Convert.ToDouble(double.Parse(TXTPRECIO.Text) * 1.10),
                                Interes = "10%",
                                Mensualidad = Convert.ToDouble(txtmensualidadCot.Text),
                                PorcentajeEnganche = Convert.ToString(numericporengan.Value),
                                Financiamiento = (double.Parse(TXTPRECIO.Text) * 1.10) - Convert.ToDouble(txtengancheCot.Text)

                                //Estatus = Convert.ToString("PENDIENTE")

                            };
                            PqteLog6.Registrar(Deb2);
                            if (PqteLog6.Mensaje.Length != 0)
                            {
                                //Hubo un error
                                MessageBox.Show(PqteLog33.Mensaje.ToString(), "Mensaje de Error");
                            }
                            else
                            {
                                MessageBox.Show("Cotizacion guardada exitosamente en la B.D \r\n\r\n Folio de Cotizacion = " + Deb2.IDCotizacion.ToString());
                                k++;

                                //Limpiar();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                    }
                }
            }
        }

        private void groupCotCred_EnabledChanged(object sender, EventArgs e)
        {
            txtengancheCot.Text = ((Convert.ToDouble(numericporengan.Value) * 0.01) * double.Parse(TXTPRECIO.Text)).ToString();
        }

        private void btnGuardarCot_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboAno.Text) | string.IsNullOrEmpty(comboColor.Text) | string.IsNullOrEmpty(comboVehiculo.Text) | string.IsNullOrEmpty(ComboVersion1.Text) | string.IsNullOrEmpty(txtNomClien.Text) | string.IsNullOrEmpty(txtApClien.Text) | string.IsNullOrEmpty(TXTIDCLIENTE.Text))
            {
                MessageBox.Show("Por favor llene todo los campos");
            }
            else
            {

                Entidades.Cotizacion pqt;
                CotizacionContado Deb;
                CotizacionCredito Deb2;
                k = rn.Next(250, 600);
                if (!rbtnConCot.Checked && !rbtnCredCot.Checked)
                {
                    MessageBox.Show("Favor de selecionar un tipo de Cotizacion");

                    return;
                }
                if (rbtnConCot.Checked)
                {
                    Versions versionSeleccionada = PqteLog4.ObtenerVersionPrecio(ComboVersion1.Text, comboVehiculo.Text);
                    int pruebadia = (int)numericdiacot.Value;
                    try
                    {
                        pqt = new Entidades.Cotizacion
                        {
                            IDCotizacion = Convert.ToString("CO" + k),
                            IDVersion = versionSeleccionada.IDVersion.Trim(),
                            IDCliente = Convert.ToString(TXTIDCLIENTE.Text),
                            IDEmpleado = TXTIDEMP.Text,
                            Dia = ((int)numericdiacot.Value),
                            Mes = (int)(numericmescot.Value),
                            Año = ((int)numericanocot.Value),
                            PrecioInicial = Convert.ToDouble(txPrecioCot.Text),
                            TipoPago = Convert.ToString("CONTADO"),
                            Hora = txthoracot.Text

                        };
                        PqteLog4.Registrar(pqt);

                        if (PqteLog4.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog2.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            //MessageBox.Show("Venta guardada exitosamente en la B.D");
                            //Limpiar();

                            //Metodo de factura
                            //vehiculosD[0] = txtVehiculo.Text;
                            //vehiculosD[1] = txtVersion.Text;
                            //vehiculosD[2] = txtAño.Text;
                            //string id = txtid.Text;
                            //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                            //factura.Show();
                        }
                        //Parte donde se guarda la venta a contado
                        if (rbtnConCot.Checked && PqteLog4.Mensaje.Length == 0)
                        {
                            //double men = 0;
                            //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                            //int c = int.Parse(txtCod.Text + 2);

                            Deb = new CotizacionContado
                            {
                                IDCotizacion = Convert.ToString("CO" + k),

                            };
                            PqteLog7.Registrar(Deb);
                            if (PqteLog7.Mensaje.Length != 0)
                            {
                                //Hubo un error
                                MessageBox.Show(PqteLog7.Mensaje.ToString(), "Mensaje de Error");
                            }
                            else
                            {
                                MessageBox.Show("Cotizacion de contado guardada exitosamente en la B.D \r\n\r\n Folio de pago = " + Deb.IDCotizacion.ToString());
                                k++;

                                //Limpiar();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                    }
                }
                if (rbtnCredCot.Checked)
                {
                    Versions versionseleccionada = PqteLog4.ObtenerVersionPrecio(ComboVersion1.Text, comboVehiculo.Text);
                    try
                    {
                        pqt = new Entidades.Cotizacion
                        {
                            IDCotizacion = Convert.ToString("CO" + k),
                            IDVersion = versionseleccionada.IDVersion,
                            IDCliente = Convert.ToString(TXTIDCLIENTE.Text),
                            IDEmpleado = TXTIDEMP.Text,
                            Dia = Convert.ToInt32(numericdiacot.Value),
                            Mes = Convert.ToInt32(numericmescot.Value),
                            Año = Convert.ToInt32(numericanocot.Value),
                            PrecioInicial = Convert.ToDouble(txPrecioCot.Text),
                            TipoPago = Convert.ToString("CREDITO"),
                            Hora = Convert.ToString(txthoracot.Text)

                        };
                        PqteLog4.Registrar(pqt);

                        if (PqteLog4.Mensaje.Length != 0)
                        {
                            //Hubo un error
                            MessageBox.Show(PqteLog4.Mensaje.ToString(), "Mensaje de Error");
                        }
                        else
                        {
                            //MessageBox.Show("Venta guardada exitosamente en la B.D");
                            //Limpiar();
                            //Metodo de factura
                            //vehiculosD[0] = txtVehiculo.Text;
                            //vehiculosD[1] = txtVersion.Text;
                            //vehiculosD[2] = txtAño.Text;
                            //string id = txtid.Text;
                            //Factura factura = new Factura(pqt, id, txtid.Text, TXTAPP.Text, TXTIDEMP.Text, vehiculosD);
                            //factura.Show();
                        }
                        //Parte donde se guarda la venta a credito
                        if (rbtnCredCot.Checked && PqteLog2.Mensaje.Length == 0)
                        {
                            //double men = 0;
                            //men = (double.Parse(txtTotal.Text) / (int)numericUpDown1.Value);
                            //int c = int.Parse(txtCod.Text + 2);

                            Deb2 = new CotizacionCredito
                            {


                                IDCotizacion = Convert.ToString("CO" + k),
                                Plazo = Convert.ToInt32(numericplazos.Value),
                                Enganche = Convert.ToDouble(txtengancheCot.Text),
                                Anualidad = Convert.ToDouble(txtanualidadCot.Text),
                                Precio = Convert.ToDouble(txtFinanciamiento.Text) + Convert.ToDouble(txPrecioCot.Text),
                                Interes = "10%",
                                Mensualidad = Convert.ToDouble(txtmensualidadCot.Text),
                                PorcentajeEnganche = Convert.ToString(numericporengan.Value),
                                Financiamiento = Convert.ToDouble(txtFinanciamiento.Text)

                                //Estatus = Convert.ToString("PENDIENTE")

                            };
                            PqteLog6.Registrar(Deb2);
                            if (PqteLog6.Mensaje.Length != 0)
                            {
                                //Hubo un error
                                MessageBox.Show(PqteLog6.Mensaje.ToString(), "Mensaje de Error");
                            }
                            else
                            {
                                MessageBox.Show("Cotizacion a credito guardada exitosamente en la B.D \r\n\r\n Folio de Cotizacion = " + Deb2.IDCotizacion.ToString());
                                TablaAmortizacion tablaAmortizacion = new TablaAmortizacion("CO" + k);
                                tablaAmortizacion.Show();
                                k++;

                                //Limpiar();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Error {0}", ex.Message, "Error inesperado "));
                    }
                }
            }
        }
        private void ArrojarPrecioCot()
        {
            Versions versiondeseada = PqteLog4.ObtenerVersionPrecio(ComboVersion1.Text, comboVehiculo.Text);
            txPrecioCot.Text = versiondeseada.Costo.ToString("0.00");
        }
        private void CalcularEnganche()
        {
            double enganchecantidad = (Convert.ToDouble(numericporengan.Value) * 0.01) * Convert.ToDouble(txPrecioCot.Text);
            txtengancheCot.Text = enganchecantidad.ToString("0.00");
        }
        private void CalcularFinanciamiento()
        {
            double precioinicial = Convert.ToDouble(txPrecioCot.Text);
            double enganche = Convert.ToDouble(txtengancheCot.Text);
            double anos = Convert.ToDouble(numericplazos.Value) / 12;
            double financiamiento = (precioinicial - enganche) * (Math.Pow(1.1, anos));
            txtFinanciamiento.Text = financiamiento.ToString("0.00");
        }
        private void CalcularMensualidadAnualiad()
        {
            double precioinicial = Convert.ToDouble(txPrecioCot.Text);
            double enganche = Convert.ToDouble(txtengancheCot.Text);
            double anos = Convert.ToDouble(numericplazos.Value) / 12;
            double financiamiento = (precioinicial - enganche) * (Math.Pow(1.1, anos));
            double mensualidad = financiamiento / (Convert.ToDouble(numericplazos.Value) + anos);
            txtmensualidadCot.Text = mensualidad.ToString("0.00");
            txtanualidadCot.Text = mensualidad.ToString("0.00");
        }

        private void tabCotizacion_Enter_1(object sender, EventArgs e)
        {
            comboVehiculo.SelectedItem = "March";
            ComboVersion1.SelectedItem = "SR";
            List<Unidad> Colores = new List<Unidad>();
            List<Modelo> Modelos = new List<Modelo>();
            Colores = PqteLog4.BuscarColores("SR", "March");
            Modelos = PqteLog4.ObtenerModeloPorNombre("SR", "March");
            foreach (Unidad color in Colores)
            {
                if (color.Estatus.Trim() == "Disponible")
                {
                    {
                        comboColor.Items.Add(color.Color);
                    }

                }
                foreach (Modelo modelo in Modelos)
                {
                    comboAno.Items.Add(modelo.Año);

                }


            }
        }

        private void comboVehiculo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboVersion1.Text))
            {

            }
            else
            {
                comboColor.Items.Clear();
                comboAno.Items.Clear();
                List<Unidad> Colores = new List<Unidad>();
                List<Modelo> Modelos = new List<Modelo>();
                Colores = PqteLog4.BuscarColores(ComboVersion1.Text, comboVehiculo.Text);
                Modelos = PqteLog4.ObtenerModeloPorNombre(ComboVersion1.Text, comboVehiculo.Text);
                foreach (Unidad color in Colores)
                {
                    if (color.Estatus.Trim() == "Disponible")
                    {
                        comboColor.Items.Add(color.Color);
                    }

                }
                foreach (Modelo modelo in Modelos)
                {
                    comboAno.Items.Add(modelo.Año);

                }
                ArrojarPrecioCot();
            }
        }

        private void rbtnConCot_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCredCot.Checked == false)
            {
                groupCotCred.Enabled = false;
            }
        }

        private void ComboVersion1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboVehiculo.Text))
            {

            }
            else
            {
                comboColor.Items.Clear();
                comboAno.Items.Clear();
                List<Unidad> Colores = new List<Unidad>();
                List<Modelo> Modelos = new List<Modelo>();
                Colores = PqteLog4.BuscarColores(ComboVersion1.Text, comboVehiculo.Text);
                Modelos = PqteLog4.ObtenerModeloPorNombre(ComboVersion1.Text, comboVehiculo.Text);
                foreach (Unidad color in Colores)
                {
                    if (color.Estatus.Trim() == "Disponible")
                    {
                        comboColor.Items.Add(color.Color);
                    }

                }
                foreach (Modelo modelo in Modelos)
                {
                    comboAno.Items.Add(modelo.Año);

                }
                ArrojarPrecioCot();
            }
        }

        private void comboColor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboAno.Text) | string.IsNullOrEmpty(comboColor.Text) | string.IsNullOrEmpty(comboVehiculo.Text) | string.IsNullOrEmpty(ComboVersion1.Text))
            {

            }
            else
            {
                ArrojarPrecioCot();
            }
        }

        private void comboAno_SelectedValueChanged_1(object sender, EventArgs e)
        {
            ComprobarCamposLlenosCot();
        }

        private void dgvClientCot_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientCot.CurrentCell.RowIndex >= 0)
            {
                int i = dgvClientCot.CurrentCell.RowIndex;
                //MessageBox.Show("Columna " + i);
                TXTIDCLIENTE.Text = dgvClientCot[0, i].Value.ToString();
                TXTNOMBRE.Text = dgvClientCot[1, i].Value.ToString();
                TXTAPELLIDO.Text = dgvClientCot[2, i].Value.ToString();
            }
        }

        private void rbtnCredCot_CheckedChanged_1(object sender, EventArgs e)
        {
            groupCotCred.Enabled = true;
        }

        private void tabPage9_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboAno.Text) | string.IsNullOrEmpty(comboColor.Text) | string.IsNullOrEmpty(comboVehiculo.Text) | string.IsNullOrEmpty(ComboVersion1.Text))
            {


            }
            else
            {
                CalcularEnganche();
                CalcularFinanciamiento();
                CalcularMensualidadAnualiad();
            }

        }

        private void numericplazos_ValueChanged(object sender, EventArgs e)
        {
            CalcularFinanciamiento();
            CalcularMensualidadAnualiad();
        }

        private void numericporengan_ValueChanged(object sender, EventArgs e)
        {
            CalcularEnganche();
            CalcularFinanciamiento();
            CalcularMensualidadAnualiad();
        }
    }
}
