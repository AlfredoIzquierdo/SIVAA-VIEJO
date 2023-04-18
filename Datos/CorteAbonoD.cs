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
    public class CorteAbonoD
    {
        //CnxSQL es la variable en app.config que contiene el nombre del servidor y de los datos en la base de datos
        //string CdCnx = @"server=DESKTOP-P7GH3IM\MSSQLSERVER01 ; integrated security = true database=SIIVA";
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(CorteAbono Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO CorteAbono (IDAbono,IDCorteCaja) VALUES (@Cl,@Nm)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDAbono);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDCorteCaja);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<CorteAbono> ListadoTotal()
        {
            List<CorteAbono> productos = new List<CorteAbono>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla cliente
                string CdSql = "Select * from CorteAbono";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        CorteAbono Pqte = new CorteAbono
                        {
                            IDAbono = Convert.ToString(Dr["IDAbono"]),
                            IDCorteCaja = Convert.ToString(Dr["IDCorteCaja"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public CorteAbono ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM CorteAbono WHERE IDAbono=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    //Cmd.Parameters.AddWithValue("@Con", Con);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        CorteAbono Pqte = new CorteAbono
                        {
                            IDAbono = Convert.ToString(Dr["IDAbono"]),
                            IDCorteCaja = Convert.ToString(Dr["IDCorteCaja"])
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
