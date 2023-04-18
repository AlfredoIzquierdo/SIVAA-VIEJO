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
    public class ProveedorD
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Proveedor Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Proovedor (IDProovedor,Nombre,RFC,NoExterior,Colonia,Ciudad,Estado) VALUES (@Cl,@Nm,@App,@Apm,@Rfc,@Cr,@Tl)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDProveedor);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.Nombre);
                    Cmd.Parameters.AddWithValue("@App", Pqte.RFC);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.NoExterior);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Colonia);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Ciudad);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Estado);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<Proveedor> ListadoTotal()
        {
            List<Proveedor> productos = new List<Proveedor>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Proveedor
                string CdSql = "Select * from Proovedor";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Proveedor Pqte = new Proveedor
                        {
                            IDProveedor = Convert.ToString(Dr["IDProovedor"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public Proveedor ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Proovedor WHERE IDProovedor=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Proveedor Pqte = new Proveedor
                        {
                            IDProveedor = Convert.ToString(Dr["IDProovedor"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"])
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
                string CdSql = "DELETE FROM Proovedor WHERE IDProovedor=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }



        }

        public void Actualizar(Proveedor Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Proovedor SET Nombre=@Nm,RFC=@App, NoExterior=@Apm,Colonia=@Rfc,Ciudad=@Cr,Estado=@Tl WHERE IDProovedor=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDProveedor);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.Nombre);
                    Cmd.Parameters.AddWithValue("@App", Pqte.RFC);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.NoExterior);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Colonia);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Ciudad);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Estado);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
