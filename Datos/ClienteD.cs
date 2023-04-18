using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class ClienteD
    {
        //CnxSQL es la variable en app.config que contiene el nombre del servidor y de los datos en la base de datos
        //string CdCnx = @"server=DESKTOP-P7GH3IM\MSSQLSERVER01 ; integrated security = true database=SIIVA";
        string CdCnx=ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Cliente Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Cliente (IDCliente,Nombre,ApellidoPaterno,ApellidoMaterno,RFC,Correo,Telefono,NoExterior,Colonia,Ciudad,Estado,EstadoCliente) VALUES (@Cl,@Nm,@App,@Apm,@Rfc,@Cr,@Tl,@No,@Col,@Ci,@Es,@EsC)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDCliente);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.Nombre);
                    Cmd.Parameters.AddWithValue("@App", Pqte.ApellidoPat);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.ApellidoMat);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.RFC);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Correo);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Telefono);
                    Cmd.Parameters.AddWithValue("@No", Pqte.NoExterior);
                    Cmd.Parameters.AddWithValue("@Col", Pqte.Colonia);
                    Cmd.Parameters.AddWithValue("@Ci", Pqte.Ciudad);
                    Cmd.Parameters.AddWithValue("@Es", Pqte.Estado);
                    Cmd.Parameters.AddWithValue("@EsC", Pqte.EstadoCliente);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<Cliente> ListadoTotal()
        {
            List<Cliente> productos = new List<Cliente>();
            
            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "Select * from Cliente";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                            EstadoCliente = Convert.ToString(Dr["EstadoCliente"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public List<Cliente> ListadoTotalEspecifico(string nom,string parametro)
        {
            List<Cliente> productos = new List<Cliente>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "SELECT * FROM Cliente WHERE "+parametro+"=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Cmd.Parameters.AddWithValue("@Lc", parametro);
                    Cmd.Parameters.AddWithValue("@Cl", nom);
                    
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                             EstadoCliente = Convert.ToString(Dr["EstadoCliente"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public List<Cliente> ListadoTotalIDCliente(string nom)
        {
            List<Cliente> productos = new List<Cliente>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "SELECT * FROM Cliente WHERE IDCliente=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", nom);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                            EstadoCliente = Convert.ToString(Dr["EstadoCliente"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<Cliente> ListadoTotalESP(string nom, string app)
        {
            List<Cliente> productos = new List<Cliente>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "SELECT * FROM Cliente WHERE Nombre=@Cl and ApellidoPaterno=@Ap";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", nom);
                    Cmd.Parameters.AddWithValue("@Ap", app);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                            EstadoCliente = Convert.ToString(Dr["EstadoCliente"])

                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public Cliente ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Cliente WHERE IDCliente=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                            EstadoCliente = Convert.ToString(Dr["EstadoCliente"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        //No usar
        public Cliente ObtenerPdto(string CodPqt,string Ap)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Cliente WHERE Nombre=@Cl and ApellidoPaterno=@Ap";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.Parameters.AddWithValue("@Ap", Ap);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                            EstadoCliente = Convert.ToString(Dr["EstadoCliente"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public Cliente ObtenerPdto2(string CodPqt, string Ap)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Cliente WHERE IDCliente=@Cl and ApellidoPaterno=@Ap";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.Parameters.AddWithValue("@Ap", Ap);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Cliente Pqte = new Cliente
                        {
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Nombre = Convert.ToString(Dr["Nombre"]),
                            ApellidoPat = Convert.ToString(Dr["ApellidoPaterno"]),
                            ApellidoMat = Convert.ToString(Dr["ApellidoMaterno"]),
                            RFC = Convert.ToString(Dr["RFC"]),
                            Correo = Convert.ToString(Dr["Correo"]),
                            Telefono = Convert.ToString(Dr["Telefono"]),
                            NoExterior = Convert.ToString(Dr["NoExterior"]),
                            Colonia = Convert.ToString(Dr["Colonia"]),
                            Ciudad = Convert.ToString(Dr["Ciudad"]),
                            Estado = Convert.ToString(Dr["Estado"]),
                            EstadoCliente = Convert.ToString(Dr["EstadoCliente"])
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public void EliminarDesaparecer(string CodPqt)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "Update Cliente Set EstadoCliente='Inactivo' WHERE IDCliente=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }

        }

        public void Actualizar(Cliente Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Cliente SET Nombre=@Nm,ApellidoPaterno=@App, ApellidoMaterno=@Apm,RFC=@Rfc,Correo=@Cr,Telefono=@Tl,NoExterior=@No, Colonia=@Col, Ciudad=@Ci, Estado=@Es WHERE IDCliente=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDCliente);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.Nombre);
                    Cmd.Parameters.AddWithValue("@App", Pqte.ApellidoPat);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.ApellidoMat);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.RFC);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Correo);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Telefono);
                    Cmd.Parameters.AddWithValue("@No", Pqte.NoExterior);
                    Cmd.Parameters.AddWithValue("@Col", Pqte.Colonia);
                    Cmd.Parameters.AddWithValue("@Ci", Pqte.Ciudad);
                    Cmd.Parameters.AddWithValue("@Es", Pqte.Estado);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
