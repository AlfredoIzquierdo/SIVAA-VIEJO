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
    public class CorteCajaD
    {
        //CnxSQL es la variable en app.config que contiene el nombre del servidor y de los datos en la base de datos
        //string CdCnx = @"server=DESKTOP-P7GH3IM\MSSQLSERVER01 ; integrated security = true database=SIIVA";
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(CorteCaja Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO CorteCaja (IDCorteCaja,IDEmpleado,Dia,Mes,Año,Hora,FondoInicial,EfectivoFinal,TarjetaFinal,TotalFinal,BalanceEfectivo,BalanceTarjeta,Estado) VALUES (@Cl,@Nm,@d,@m,@a,@h,@fi,@ef,@tf,@f,@be,@bt,@es)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDCorteCaja);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@d", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@m", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@a", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@h", Pqte.Hora);
                    Cmd.Parameters.AddWithValue("@fi", Pqte.FondoInicial);
                    Cmd.Parameters.AddWithValue("@ef", Pqte.EfectivoFinal);
                    Cmd.Parameters.AddWithValue("@tf", Pqte.TarjetaFinal);
                    Cmd.Parameters.AddWithValue("@f", Pqte.TotalFinal);
                    Cmd.Parameters.AddWithValue("@be", Pqte.BalanceEfectivo);
                    Cmd.Parameters.AddWithValue("@bt", Pqte.BalanceTarjeta);
                    Cmd.Parameters.AddWithValue("@es", Pqte.Estado);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<CorteCaja> ListadoTotal()
        {
            List<CorteCaja> productos = new List<CorteCaja>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "Select * from CorteCaja";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        CorteCaja Pqte = new CorteCaja
                        {
                            IDCorteCaja = Convert.ToString(Dr["IDPago"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            FondoInicial = Convert.ToDouble(Dr["FondoInicial"]),
                            EfectivoFinal = Convert.ToDouble(Dr["EfectivoFinal"]),
                            TarjetaFinal = Convert.ToDouble(Dr["TarjetaFinal"]),
                            TotalFinal = Convert.ToDouble(Dr["TotalFinal"]),
                            BalanceEfectivo = Convert.ToDouble(Dr["BalanceEfectivo"]),
                            BalanceTarjeta = Convert.ToDouble(Dr["BalanceTarjeta"]),
                            Estado = Convert.ToString(Dr["Estado"])


                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public CorteCaja ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM CorteCaja WHERE IDCorteCaja=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        CorteCaja Pqte = new CorteCaja
                        {
                            IDCorteCaja = Convert.ToString(Dr["IDPago"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            FondoInicial = Convert.ToDouble(Dr["FondoInicial"]),
                            EfectivoFinal = Convert.ToDouble(Dr["EfectivoFinal"]),
                            TarjetaFinal = Convert.ToDouble(Dr["TarjetaFinal"]),
                            TotalFinal = Convert.ToDouble(Dr["TotalFinal"]),
                            BalanceEfectivo = Convert.ToDouble(Dr["BalanceEfectivo"]),
                            BalanceTarjeta = Convert.ToDouble(Dr["BalanceTarjeta"]),
                            Estado = Convert.ToString(Dr["Estado"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public CorteCaja BuscarCajaAbierta()
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM CorteCaja WHERE Estado='ACTIVA'";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    //Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        CorteCaja Pqte = new CorteCaja
                        {
                            IDCorteCaja = Convert.ToString(Dr["IDCorteCaja"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"]),
                            FondoInicial = Convert.ToDouble(Dr["FondoInicial"]),
                            EfectivoFinal = Convert.ToDouble(Dr["EfectivoFinal"]),
                            TarjetaFinal = Convert.ToDouble(Dr["TarjetaFinal"]),
                            TotalFinal = Convert.ToDouble(Dr["TotalFinal"]),
                            BalanceEfectivo = Convert.ToDouble(Dr["BalanceEfectivo"]),
                            BalanceTarjeta = Convert.ToDouble(Dr["BalanceTarjeta"]),
                            Estado = Convert.ToString(Dr["Estado"])
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

        public void ActualizarEstado(CorteCaja Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE CorteCaja SET EfectivoFinal=@ef ,TarjetaFinal=@tf,TotalFinal=@f,BalanceEfectivo=@be,BalanceTarjeta=@bt,Estado=@es WHERE IDCorteCaja=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDCorteCaja);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@d", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@m", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@a", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@h", Pqte.Hora);
                    Cmd.Parameters.AddWithValue("@fi", Pqte.FondoInicial);
                    Cmd.Parameters.AddWithValue("@ef", Pqte.EfectivoFinal);
                    Cmd.Parameters.AddWithValue("@tf", Pqte.TarjetaFinal);
                    Cmd.Parameters.AddWithValue("@f", Pqte.TotalFinal);
                    Cmd.Parameters.AddWithValue("@be", Pqte.BalanceEfectivo);
                    Cmd.Parameters.AddWithValue("@bt", Pqte.BalanceTarjeta);
                    Cmd.Parameters.AddWithValue("@es", Pqte.Estado);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
