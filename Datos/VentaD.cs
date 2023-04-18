using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class VentaD
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Venta Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Venta (IDVenta,IDEmpleado,NoSerie,Dia,Mes,Año,Hora,SubTotal,TipoVenta) VALUES (@Cl,@Nm,null,@Apm,@Rfc,@Cr,@Tl,@No,@Col)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDVenta);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@App", Pqte.NoSerie);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Hora);
                    Cmd.Parameters.AddWithValue("@No", Pqte.Subtotal);
                    Cmd.Parameters.AddWithValue("@Col", Pqte.TipoVenta);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public void Insertarnormal(Venta Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Venta (IDVenta,IDEmpleado,NoSerie,Dia,Mes,Año,Hora,SubTotal,TipoVenta) VALUES (@Cl,@Nm,null,@Apm,@Rfc,@Cr,@Tl,@No,@Col)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDVenta);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDEmpleado);
                    //Cmd.Parameters.AddWithValue("@App", Pqte.NoSerie);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Hora);
                    Cmd.Parameters.AddWithValue("@No", Pqte.Subtotal);
                    Cmd.Parameters.AddWithValue("@Col", Pqte.TipoVenta);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }
        public List<Venta> ListadoTotal()
        {
            List<Venta> productos = new List<Venta>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "Select * from Venta";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Venta Pqte = new Venta
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            Subtotal = Convert.ToDouble(Dr["SubTotal"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public List<VentasEntrega> ListadoTotalVentasEntrega()
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año,venta.Hora, Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaContado, cliente, Cotizacion, CotizacionContado, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaContado.IDVenta and VentaContado.IDCotizacion=CotizacionContado.IDCotizacion\r\nand CotizacionContado.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaContado.Estatus='PAGADO'\r\nunion\r\nselect Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año, Venta.Hora,Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaCredito, cliente, Cotizacion, CotizacionCredito, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaCredito.IDVenta and VentaCredito.IDCotizacion=CotizacionCredito.IDCotizacion\r\nand CotizacionCredito.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaCredito.Estatus='PAGADO'";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Vehiculo"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Modelo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public List<VentasEntrega> ListadoTotalVentasEntregaContado()
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año, Venta.Hora,Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaContado, cliente, Cotizacion, CotizacionContado, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaContado.IDVenta and VentaContado.IDCotizacion=CotizacionContado.IDCotizacion\r\nand CotizacionContado.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaContado.Estatus='PAGADO'";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Vehiculo"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Modelo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<VentasEntrega> ListadoTotalVentasEntregaCredito()
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año,Venta.Hora, Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaCredito, cliente, Cotizacion, CotizacionCredito, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaCredito.IDVenta and VentaCredito.IDCotizacion=CotizacionCredito.IDCotizacion\r\nand CotizacionCredito.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaCredito.Estatus='PAGADO'";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Vehiculo"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Modelo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<VentasEntrega> ListadoTotalVentasEntregaCredito2()
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año,Venta.Hora, Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaCredito, cliente, Cotizacion, CotizacionCredito, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaCredito.IDVenta and VentaCredito.IDCotizacion=CotizacionCredito.IDCotizacion\r\nand CotizacionCredito.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaCredito.Estatus='Pendiente'";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Vehiculo"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Modelo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<VentasEntrega> ListadoTotalVentasABONOCredito()
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año,Venta.Hora, Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaCredito, cliente, Cotizacion, CotizacionCredito, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaCredito.IDVenta and VentaCredito.IDCotizacion=CotizacionCredito.IDCotizacion\r\nand CotizacionCredito.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaCredito.Estatus='PAGADO'";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Vehiculo"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Modelo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public List<VentasEntrega> ListadoTotalVentasEntregaPorClientes(string nom, string app)
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año,venta.Hora, Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaContado, cliente, Cotizacion, CotizacionContado, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaContado.IDVenta and VentaContado.IDCotizacion=CotizacionContado.IDCotizacion\r\nand CotizacionContado.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaContado.Estatus='PAGADO' and Cliente.Nombre=@nom and Cliente.ApellidoPaterno=@app\r\nunion\r\nselect Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año, Venta.Hora,Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaCredito, cliente, Cotizacion, CotizacionCredito, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaCredito.IDVenta and VentaCredito.IDCotizacion=CotizacionCredito.IDCotizacion\r\nand CotizacionCredito.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaCredito.Estatus='PAGADO' and Cliente.Nombre=@nom and Cliente.ApellidoPaterno=@app";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@nom", nom);
                    Cmd.Parameters.AddWithValue("@app", app);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Nombre"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Año"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<VentasEntrega> ListadoTotalVentasABONOPorClientes(string nom, string app)
        {
            List<VentasEntrega> productos = new List<VentasEntrega>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "select Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año,venta.Hora, Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaContado, cliente, Cotizacion, CotizacionContado, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaContado.IDVenta and VentaContado.IDCotizacion=CotizacionContado.IDCotizacion\r\nand CotizacionContado.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaContado.Estatus='Activo' and Cliente.Nombre=@nom and Cliente.ApellidoPaterno=@app\r\nunion\r\nselect Venta.IDVenta, Cliente.Nombre, Cliente.ApellidoPaterno, Cliente.ApellidoMaterno, Venta.Dia, venta.Mes,\r\nVenta.Año, Venta.Hora,Venta.TipoVenta, Vehiculo.Nombre Vehiculo, Version.Version, Version.Cilindraje, \r\nVersion.Transmision, Modelo.Año Modelo\r\nfrom Venta,VentaCredito, cliente, Cotizacion, CotizacionCredito, Version, ModeloVersion, Modelo, Vehiculo\r\nwhere venta.IDVenta=VentaCredito.IDVenta and VentaCredito.IDCotizacion=CotizacionCredito.IDCotizacion\r\nand CotizacionCredito.IDCotizacion=Cotizacion.IDCotizacion and Cotizacion.IDCliente=Cliente.IDCliente \r\nand Cotizacion.IDVersion=ModeloVersion.IDVersion and ModeloVersion.IDModelo=Modelo.IDModelo and \r\nVersion.IDVehiculo= Vehiculo.IDVehiculo and Cotizacion.IDVersion=Version.IDVersion\r\nand VentaCredito.Estatus='Activo' and Cliente.Nombre=@nom and Cliente.ApellidoPaterno=@app";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@nom", nom);
                    Cmd.Parameters.AddWithValue("@app", app);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentasEntrega Pqte = new VentasEntrega
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPaterno = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMaterno = Convert.ToString(Dr["ApellidoMaterno"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"]),
                            Vehiculo = Convert.ToString(Dr["Nombre"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Cilindraje = Convert.ToString(Dr["Cilindraje"]),
                            Transmision = Convert.ToString(Dr["Transmision"]),
                            Modelo = Convert.ToString(Dr["Año"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public Venta ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Venta WHERE IDVenta=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Venta Pqte = new Venta
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            Subtotal = Convert.ToDouble(Dr["SubTotal"]),
                            TipoVenta = Convert.ToString(Dr["TipoVenta"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        //public Venta ObtenerPdtovoucher(string CodPqt)
        //{
        //    //Using que crea la conexión
        //    using (SqlConnection Cnx = new SqlConnection(CdCnx))
        //    {
        //        //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
        //        Cnx.Open();
        //        string CdSql = "SELECT * FROM Venta WHERE IDVenta=@Cl";
        //        //Using que crea el comando que voy a ejecutar con relación al query que planeteo
        //        using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
        //        {
        //            //Asignar el valor a @Cl
        //            Cmd.Parameters.AddWithValue("@Cl", CodPqt);
        //            SqlDataReader Dr = Cmd.ExecuteReader();
        //            if (Dr.Read())
        //            {

        //                Venta Pqte = new Venta
        //                {
        //                    IDVenta = Convert.ToString(Dr["IDVenta"]),
        //                    IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
        //                    NoSerie = Convert.ToString(Dr["NoSerie"]),
        //                    Dia = Convert.ToInt32(Dr["Dia"]),
        //                    Mes = Convert.ToInt32(Dr["Mes"]),
        //                    Año = Convert.ToInt32(Dr["Año"]),
        //                    Hora = Convert.ToString(Dr["Hora"]),
        //                    Subtotal = Convert.ToDouble(Dr["SubTotal"]),
        //                    TipoVenta = Convert.ToString(Dr["TipoVenta"])
        //                };
        //                return Pqte;
        //            }
        //        }
        //        Cnx.Close();
        //    }
        //    return null;
        //}
        public void Eliminar(string CodPqt)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "DELETE FROM Venta WHERE IDVenta=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }



        }

        public void Actualizar(Venta Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Venta SET IDEmpleado=@Nm,NoSerie=@App, Dia=@Apm,Mes=@Rfc,Año=@Cr,Hora=@Tl,SubTotal=@No, TipoVenta=@Col WHERE IDVenta=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDVenta);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@App", Pqte.NoSerie);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Hora);
                    Cmd.Parameters.AddWithValue("@No", Pqte.Subtotal);
                    Cmd.Parameters.AddWithValue("@Col", Pqte.TipoVenta);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
        public void Actualizarserie(string Pqte, string serie)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Venta SET NoSerie=@App WHERE IDVenta=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@App", serie);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
