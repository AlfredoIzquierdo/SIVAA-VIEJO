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
    public class CotizacionCreditoD
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(CotizacionCredito Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO CotizacionCredito (IDCotizacion,Plazo,Enganche,Anualidad,Precio,Interes,Mensualidad,PorcentajeEnganche,Financiamiento) VALUES (@Co,@P,@E,@A,@Pr,@I,@M,@PE,@F)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Co", Pqte.IDCotizacion);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@P", Pqte.Plazo);
                    Cmd.Parameters.AddWithValue("@E", Pqte.Enganche);
                    Cmd.Parameters.AddWithValue("@A", Pqte.Anualidad);
                    Cmd.Parameters.AddWithValue("@Pr", Pqte.Precio);
                    Cmd.Parameters.AddWithValue("@I", Pqte.Interes);
                    Cmd.Parameters.AddWithValue("@M", Pqte.Mensualidad);
                    Cmd.Parameters.AddWithValue("@PE", Pqte.PorcentajeEnganche);
                    Cmd.Parameters.AddWithValue("@F", Pqte.Financiamiento);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<CotizacionCredito> ListadoTotal()
        {
            List<CotizacionCredito> productos = new List<CotizacionCredito>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "Select * from CotizacionCredito";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        CotizacionCredito Pqte = new CotizacionCredito
                        {
                            IDCotizacion = Convert.ToString(Dr["IDCotizacion"]),
                            Plazo = Convert.ToInt16(Dr["Plazo"]),
                            Enganche = Convert.ToDouble(Dr["Enganche"]),
                            Anualidad = Convert.ToDouble(Dr["Anualidad"]),
                            Precio = Convert.ToDouble(Dr["Precio"]),
                            Interes = Convert.ToString(Dr["Interes"]),
                            Mensualidad = Convert.ToDouble(Dr["Mensualidad"]),
                            PorcentajeEnganche = Convert.ToString(Dr["PorcentajeEnganche"]),
                            Financiamiento = Convert.ToDouble(Dr["Fianciamiento"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public CotizacionCredito ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM CotizacionCredito WHERE IDCotizacion=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        CotizacionCredito Pqte = new CotizacionCredito
                        {
                            IDCotizacion = Convert.ToString(Dr["IDCotizacion"]),
                            Plazo = Convert.ToInt16(Dr["Plazo"]),
                            Enganche = Convert.ToDouble(Dr["Enganche"]),
                            Anualidad = Convert.ToDouble(Dr["Anualidad"]),
                            Precio = Convert.ToDouble(Dr["Precio"]),
                            Interes = Convert.ToString(Dr["Interes"]),
                            Mensualidad = Convert.ToDouble(Dr["Mensualidad"]),
                            PorcentajeEnganche = Convert.ToString(Dr["PorcentajeEnganche"]),
                            Financiamiento = Convert.ToDouble(Dr["Financiamiento"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }

        public void Eliminar(string CodPqt)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "DELETE FROM CotizacionCredito WHERE IDCotizacion=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }



        }

        public void Actualizar(CotizacionCredito Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE CotizacionCredito SET Plazo=@Nm,Enganche=@App, Anualidad=@Apm,Precio=@Rfc,Interes=@Cr,Mensualidad=@Tl,PorcentajeEnganche=@No, Financiamiento=@Col WHERE IDCotizacion=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDCotizacion);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.Plazo);
                    Cmd.Parameters.AddWithValue("@App", Pqte.Enganche);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Anualidad);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Precio);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Interes);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Mensualidad);
                    Cmd.Parameters.AddWithValue("@No", Pqte.PorcentajeEnganche);
                    Cmd.Parameters.AddWithValue("@Col", Pqte.Financiamiento);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
