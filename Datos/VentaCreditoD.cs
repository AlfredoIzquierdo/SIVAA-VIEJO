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
    public class VentaCreditoD
    {
        //CnxSQL es la variable en app.config que contiene el nombre del servidor y de los datos en la base de datos
        //string CdCnx = @"server=DESKTOP-P7GH3IM\MSSQLSERVER01 ; integrated security = true database=SIIVA";
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(VentaCredito Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO VentaCredito (IDVenta,IDCotizacion,TotalFinal, Estatus) VALUES (@Cl,@Nm,@tf,@es)";
                //string CdSql = "INSERT INTO VentaCredito (IDVenta,IDCotizacion,TotalFinal,Estatus) VALUES (@Cl,@Nm,@tf,@es)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDVenta);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDCotizacion);
                    Cmd.Parameters.AddWithValue("@tf", Pqte.TotalFinal);
                    Cmd.Parameters.AddWithValue("@es", Pqte.Estatus);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<VentaCredito> ListadoTotal()
        {
            List<VentaCredito> productos = new List<VentaCredito>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla VentaCredito
                string CdSql = "Select * from VentaCredito";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        VentaCredito Pqte = new VentaCredito
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            IDCotizacion = Convert.ToString(Dr["IDCotizacion"]),
                            TotalFinal = Convert.ToDouble(Dr["TotalFinal"]),
                            Estatus = Convert.ToString(Dr["Estatus"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public VentaCredito ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM VentaCredito WHERE IDVenta=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        VentaCredito Pqte = new VentaCredito
                        {
                            IDVenta = Convert.ToString(Dr["IDVenta"]),
                            IDCotizacion = Convert.ToString(Dr["IDCotizacion"]),
                            TotalFinal = Convert.ToDouble(Dr["TotalFinal"]),
                            Estatus = Convert.ToString(Dr["Estatus"])
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
        //        string CdSql = "DELETE FROM VentaContado WHERE IDVenta=@Cl";
        //        using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
        //        {
        //            Cmd.Parameters.AddWithValue("@Cl", CodPqt);
        //            Cmd.ExecuteNonQuery();
        //            Cmd.Dispose();
        //        }
        //        Cnx.Close();
        //    }
        //}

        public void Actualizar(VentaCredito Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE VentaCredito SET IDCotizacion=@Nm,TotalFinal=@tf, Estatus=@es WHERE IDVenta=@Cl";
                //string CdSql = "UPDATE VentaCredito SET IDCotizacion=@Nm,TotalFinal=@tf, Estatus=@es WHERE IDVenta=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDVenta);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDCotizacion);
                    Cmd.Parameters.AddWithValue("@tf", Pqte.TotalFinal);
                    Cmd.Parameters.AddWithValue("@es", Pqte.Estatus);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
        public void ActualizarEstatus(string id, string est)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE VentaCredito SET Estatus=@es WHERE IDVenta=@Cl";
                //string CdSql = "UPDATE VentaCredito SET IDCotizacion=@Nm,TotalFinal=@tf, Estatus=@es WHERE IDVenta=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", id);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@es", est);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
