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
    public class AbonoD
    {
        //CnxSQL es la variable en app.config que contiene el nombre del servidor y de los datos en la base de datos
        //string CdCnx = @"server=DESKTOP-P7GH3IM\MSSQLSERVER01 ; integrated security = true database=SIIVA";
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Abono Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Abono (IDAbono,IDEmpleado,IDVenta,SaldoActual,SaldoAnterior,Monto,FormaPago,Dia,Mes,Año,Tipo) VALUES (@Cl,@emp,@Nm,@sac,@san,@mon,@fp,@d,@m,@a,@t)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDAbono);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@emp", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDVenta);
                    Cmd.Parameters.AddWithValue("@sac", Pqte.SaldoActual);
                    Cmd.Parameters.AddWithValue("@san", Pqte.SaldoAnterior);
                    Cmd.Parameters.AddWithValue("@mon", Pqte.Monto);
                    Cmd.Parameters.AddWithValue("@fp", Pqte.FormaPago);
                    Cmd.Parameters.AddWithValue("@d", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@m", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@a", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@t", Pqte.Tipo);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<Abono> ListadoTotal()
        {
            List<Abono> productos = new List<Abono>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "Select * from Abono";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Abono Pqte = new Abono
                        {
                            IDAbono = Convert.ToString(Dr["IDAbono"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            SaldoActual = Convert.ToDouble(Dr["SaldoActual"]),
                            SaldoAnterior = Convert.ToDouble(Dr["SaldoAnterior"]),
                            Monto = Convert.ToDouble(Dr["Monto"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Tipo = Convert.ToString(Dr["Tipo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<Abono> ListadoTotalEspecifico(string cod)
        {
            List<Abono> productos = new List<Abono>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "Select * from Abono where IDVenta=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", cod);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Abono Pqte = new Abono
                        {
                            IDAbono = Convert.ToString(Dr["IDAbono"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            SaldoActual = Convert.ToDouble(Dr["SaldoActual"]),
                            SaldoAnterior = Convert.ToDouble(Dr["SaldoAnterior"]),
                            Monto = Convert.ToDouble(Dr["Monto"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Tipo = Convert.ToString(Dr["Tipo"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public Abono ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Abono WHERE IDAbono=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Abono Pqte = new Abono
                        {
                            IDAbono = Convert.ToString(Dr["IDAbono"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            SaldoActual = Convert.ToDouble(Dr["SaldoActual"]),
                            SaldoAnterior = Convert.ToDouble(Dr["SaldoAnterior"]),
                            Monto = Convert.ToDouble(Dr["Monto"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Tipo = Convert.ToString(Dr["Tipo"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public Abono Obtenersaldos(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "select IDVenta, SUM(Abono.Monto) SaldoAnt\r\nfrom Abono where IDVenta=@Cl \r\ngroup by IDVenta";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Abono Pqte = new Abono
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            SaldoAnterior = Convert.ToDouble(Dr["SaldoAnt"]) 
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }

        public Abono Obtenerabonosefectivo(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "select CorteAbono.IDCortecaja,SUM(Abono.Monto) FinalEfec \r\nfrom Abono, CorteAbono where Abono.FormaPago='EFECTIVO' and CorteAbono.IDAbono=Abono.IDAbono\r\nand CorteAbono.IDCortecaja=@Cl\r\ngroup by IDCortecaja";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Abono Pqte = new Abono
                        {
                            IDVenta = Convert.ToString(Dr["IDCorteCaja"]),
                            SaldoAnterior = Convert.ToDouble(Dr["FinalEfec"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public Abono Obtenerabonostarjeta(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "select CorteAbono.IDCortecaja,SUM(Abono.Monto) FinalEfec \r\nfrom Abono, CorteAbono where Abono.FormaPago='TARJETA' and CorteAbono.IDAbono=Abono.IDAbono\r\nand CorteAbono.IDCortecaja=@Cl\r\ngroup by IDCortecaja";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Abono Pqte = new Abono
                        {
                            IDVenta = Convert.ToString(Dr["IDCorteCaja"]),
                            SaldoAnterior = Convert.ToDouble(Dr["FinalEfec"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        //public void Eliminar(string CodPqt)
        //{
        //    using (SqlConnection Cnx = new SqlConnection(CdCnx))
        //    {
        //        Cnx.Open();
        //        string CdSql = "DELETE FROM Cliente WHERE IDEmpleado=@Cl";
        //        using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
        //        {
        //            Cmd.Parameters.AddWithValue("@Cl", CodPqt);
        //            Cmd.ExecuteNonQuery();
        //            Cmd.Dispose();
        //        }
        //        Cnx.Close();
        //    }
        //}

        //public void Actualizar(Empleado Pqte)
        //{
        //    using (SqlConnection Cnx = new SqlConnection(CdCnx))
        //    {
        //        Cnx.Open();
        //        string CdSql = "UPDATE Empleado SET Nombre=@Nm,ApellidoPaterno=@App, ApellidoMaterno=@Apm,RFC=@Rfc,Correo=@Cr,Telefono=@Tl,Contraseña=@Co, Tipo=@Ti WHERE IDEmpleado=@Cl";
        //        using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
        //        {
        //            //Añadir los parámetros
        //            Cmd.Parameters.AddWithValue("@Cl", Pqte.IDEmpleado);//Get y set de la capa entidad
        //            Cmd.Parameters.AddWithValue("@Nm", Pqte.Nombre);
        //            Cmd.Parameters.AddWithValue("@App", Pqte.ApellidoPat);
        //            Cmd.Parameters.AddWithValue("@Apm", Pqte.ApellidoMat);
        //            Cmd.Parameters.AddWithValue("@Cr", Pqte.Correo);
        //            Cmd.Parameters.AddWithValue("@Tl", Pqte.Telefono);
        //            Cmd.Parameters.AddWithValue("@Rfc", Pqte.RFC);
        //            Cmd.Parameters.AddWithValue("@Co", Pqte.Contraseña);
        //            Cmd.Parameters.AddWithValue("@Ti", Pqte.Tipo);
        //            Cmd.ExecuteNonQuery();
        //            //Borrar variable cmd de la memoria
        //            Cmd.Dispose();
        //        }
        //        Cnx.Close();
        //    }
        //}
    }
}
