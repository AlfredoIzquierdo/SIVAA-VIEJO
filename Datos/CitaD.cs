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
    public class CitaD
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Cita Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Cita (IDCita,IDEmpleado,IDCliente,Dia,Mes,Año,Hora) VALUES (@Ci,@Em,@C,@D,@M,@A,@H)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Ci", Pqte.IDCita);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Em", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@C", Pqte.IDCliente);
                    Cmd.Parameters.AddWithValue("@D", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@M", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@A", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@H", Pqte.Hora);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<Cita> ListadoTotal()
        {
            List<Cita> productos = new List<Cita>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "Select * from Cita";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Cita Pqte = new Cita
                        {
                            IDCita = Convert.ToString(Dr["IDCita"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }
        public List<Cita> ListadoTotalPorCliente(string idcliente)
        {
            List<Cita> productos = new List<Cita>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Venta
                string CdSql = "Select * from Cita Where IDCliente=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", idcliente);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Cita Pqte = new Cita
                        {
                            IDCita = Convert.ToString(Dr["IDCita"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public Cita ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Cita WHERE IDCita=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        Cita Pqte = new Cita
                        {
                            IDCita = Convert.ToString(Dr["IDCita"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDCliente = Convert.ToString(Dr["IDCliente"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Hora = Convert.ToString(Dr["Hora"])
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
                string CdSql = "DELETE FROM Cita WHERE IDCita=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }

        public void Actualizar(Cita Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Cita SET IDEmpleado=@Nm,IDCliente=@App, Dia=@Apm,Mes=@Rfc,Año=@Cr,Hora=@Tl WHERE IDCita=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDCita);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@App", Pqte.IDCliente);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Año);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
