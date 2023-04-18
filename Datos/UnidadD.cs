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
    public class UnidadD
    {
        //CnxSQL es la variable en app.config que contiene el nombre del servidor y de los datos en la base de datos
        //string CdCnx = @"server=DESKTOP-P7GH3IM\MSSQLSERVER01 ; integrated security = true database=SIIVA";
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Unidad Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Unidad (NoSerie,IDVersion,IDPedido,Color,Estatus) VALUES (@Cl,@Nm,@App,@Apm,@Cr)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.NoSerie);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDVersion);
                    Cmd.Parameters.AddWithValue("@App", Pqte.IDPedido);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Color);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Estatus);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<Unidad> ListadoTotal()
        {
            List<Unidad> productos = new List<Unidad>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "Select * from Unidad";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Unidad Pqte = new Unidad
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            IDVersion = Convert.ToString(Dr["IDVersion"]),
                            IDPedido = Convert.ToString(Dr["IDPedido"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Estatus = Convert.ToString(Dr["Estatus"]),
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public AutoNoUsar ObtenerAuto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT Vehiculo.Nombre, [Version].[Version], Modelo.Año from Vehiculo, Version, ModeloVersion, Modelo where Version.IDVehiculo=Vehiculo.IDVehiculo and ModeloVersion.IDModelo=Modelo.IDModelo and ModeloVersion.IDVersion=Version.IDVersion and Version.IDVersion=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        AutoNoUsar Pqte = new AutoNoUsar
                        {
                            Vehiculo = Convert.ToString(Dr["Nombre"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Modelo = Convert.ToString(Dr["Año"]),
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public void Actualizarest(string Pqte, string est)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Unidad SET Estatus='Vendido' WHERE NoSerie=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Cr", est);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();

            }
        }
        public List<Unidad> ListadoTotalESP(string nom)
        {
            List<Unidad> productos = new List<Unidad>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "SELECT * FROM Unidad WHERE IDVersion=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", nom);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Unidad Pqte = new Unidad
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            IDVersion = Convert.ToString(Dr["IDVersion"]),
                            IDPedido = Convert.ToString(Dr["IDPedido"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Estatus = Convert.ToString(Dr["Estatus"]),
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<UnidadNoUsar> InventarioGral()
        {
            List<UnidadNoUsar> unidades = new List<UnidadNoUsar>();
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                // Crear el query
                string cdSql = "Select U.NoSerie, V.Nombre, Ve.[Version], M.Año, U.Color,U.Estatus from Unidad U\r\ninner join [Version] Ve on U.IDVersion = Ve.IDVersion\r\ninner join ModeloVersion MV on MV.IDVersion = Ve.IDVersion\r\ninner join Modelo M on M.IDModelo = MV.IDModelo\r\ninner join Vehiculo V on V.IDVehiculo = Ve.IDVehiculo order by V.Nombre, Ve.[Version]";
                using (SqlCommand Cmd = new SqlCommand(cdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        UnidadNoUsar Pqte = new UnidadNoUsar
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            Vehiculo = Convert.ToString(Dr["Nombre"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Modelo = Convert.ToString(Dr["Año"]),
                            Estatus = Convert.ToString(Dr["Estatus"])

                        };
                        unidades.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return unidades;
        }

        public List<UnidadNoUsar> InventarioFiltro(string nom)
        {
            List<UnidadNoUsar> productos = new List<UnidadNoUsar>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla unidad
                string CdSql = "SELECT Unidad.NoSerie, Vehiculo.Nombre, [Version].[Version], Unidad.Color, Modelo.Año,Unidad.Estatus\r\nfrom Unidad, Vehiculo, Version, ModeloVersion, Modelo\r\nwhere Version.IDVehiculo=Vehiculo.IDVehiculo and ModeloVersion.IDModelo=Modelo.IDModelo\r\nand ModeloVersion.IDVersion=Version.IDVersion and Unidad.IDVersion=Version.IDVersion AND Unidad.Estatus=@Cl order by Vehiculo.Nombre, [Version].[Version]";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", nom);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        UnidadNoUsar Pqte = new UnidadNoUsar
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            Vehiculo = Convert.ToString(Dr["Nombre"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Modelo = Convert.ToString(Dr["Año"]),
                            Estatus = Convert.ToString(Dr["Estatus"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }


        public List<UnidadNoUsar> ListadoUnidESP(string nom)
        {
            List<UnidadNoUsar> productos = new List<UnidadNoUsar>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla unidad
                string CdSql = "SELECT Unidad.NoSerie, Vehiculo.Nombre, [Version].[Version], Unidad.Color, Modelo.Año,Unidad.Estatus\r\nfrom Unidad, Vehiculo, Version, ModeloVersion, Modelo\r\nwhere Version.IDVehiculo=Vehiculo.IDVehiculo and ModeloVersion.IDModelo=Modelo.IDModelo\r\nand ModeloVersion.IDVersion=Version.IDVersion and Unidad.IDVersion=Version.IDVersion and Unidad.IDVersion=@Cl AND Unidad.Estatus='DISPONIBLE'";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", nom);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        UnidadNoUsar Pqte = new UnidadNoUsar
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            Vehiculo = Convert.ToString(Dr["Nombre"]),
                            Version = Convert.ToString(Dr["Version"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Modelo = Convert.ToString(Dr["Año"]),
                            Estatus = Convert.ToString(Dr["Estatus"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public Unidad ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Unidad WHERE NoSerie=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Unidad Pqte = new Unidad
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            IDVersion = Convert.ToString(Dr["IDVersion"]),
                            IDPedido = Convert.ToString(Dr["IDPedido"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Estatus = Convert.ToString(Dr["Estatus"]),
                        };
                        return Pqte;
                    }
                }
                Cnx.Close();
            }
            return null;
        }
        public List<Unidad> ObtenerPdtoPorVersion(string CodPqt)
        {
            List <Unidad> productos = new List<Unidad>();
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Unidad WHERE IDVersion=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Unidad Pqte = new Unidad
                        {
                            NoSerie = Convert.ToString(Dr["NoSerie"]),
                            IDVersion = Convert.ToString(Dr["IDVersion"]),
                            IDPedido = Convert.ToString(Dr["IDPedido"]),
                            Color = Convert.ToString(Dr["Color"]),
                            Estatus = Convert.ToString(Dr["Estatus"]),
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public void Eliminar(string CodPqt)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "DELETE FROM Unidad WHERE NoSerie=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }

        public void Actualizar(Unidad Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Unidad SET IDVersion=@Nm,IdPedido=@App, Color=@Apm,CostoUnitario=@Rfc,Importe=@Cr WHERE NoSerie=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.NoSerie);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDVersion);
                    Cmd.Parameters.AddWithValue("@App", Pqte.IDPedido);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Color);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Estatus);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
