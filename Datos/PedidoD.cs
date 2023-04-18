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
    public class PedidoD
    {
        string CdCnx = ConfigurationManager.ConnectionStrings["CnxSQL"].ToString();
        public void Insertar(Pedido Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abrir la conexión y crear el Query
                Cnx.Open();
                string CdSql = "INSERT INTO Pedido (IDPedido,IDProovedor,IDEmpleado,NoSerie,Dia,Mes,Año,Importe) VALUES (@Cl,@Nm,@App,@Apm,@Rfc,@Cr,@I)";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))//SolicitA: la cadena de SQL y la conexeión
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDPedido);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDProveedor);
                    Cmd.Parameters.AddWithValue("@App", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@I", Pqte.Importe);

                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                //Cierre
                Cnx.Close();
            }
        }

        public List<Pedido> ListadoTotal()
        {
            List<Pedido> productos = new List<Pedido>();

            //Vuelvo a crear la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                //Creo el Query (todos los registros de la tabla Pedido
                string CdSql = "Select * from Pedido";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    //Leo registro por registro que tiene la tabla 
                    while (Dr.Read())
                    {
                        //Cada vez que lo lea se crea un nuevo objeto
                        Pedido Pqte = new Pedido
                        {
                            IDPedido = Convert.ToString(Dr["IDPedido"]),
                            IDProveedor = Convert.ToString(Dr["IDProovedor"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Importe = Convert.ToDouble(Dr["Importe"])
                        };
                        productos.Add(Pqte);
                    }
                }
                Cnx.Close();
            }
            return productos;
        }

        public Pedido ObtenerPdto(string CodPqt)
        {
            //Using que crea la conexión
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                //Abro la conexión y creo el Query insertar, eliminar, consultar, elminar, actualizar, consulta individaul, general, orrar todo
                Cnx.Open();
                string CdSql = "SELECT * FROM Pedido WHERE IDPedido=@Cl";
                //Using que crea el comando que voy a ejecutar con relación al query que planeteo
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Asignar el valor a @Cl
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {

                        Pedido Pqte = new Pedido
                        {
                            IDPedido = Convert.ToString(Dr["IDVenta"]),
                            IDEmpleado = Convert.ToString(Dr["IDEmpleado"]),
                            IDProveedor = Convert.ToString(Dr["IDProovedor"]),
                            Dia = Convert.ToInt32(Dr["Dia"]),
                            Mes = Convert.ToInt32(Dr["Mes"]),
                            Año = Convert.ToInt32(Dr["Año"]),
                            Importe = Convert.ToDouble(Dr["Importe"]),
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
                string CdSql = "DELETE FROM Pedido WHERE IDPedido=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    Cmd.Parameters.AddWithValue("@Cl", CodPqt);
                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }

        public void Actualizar(Pedido Pqte)
        {
            using (SqlConnection Cnx = new SqlConnection(CdCnx))
            {
                Cnx.Open();
                string CdSql = "UPDATE Pedido SET IDProovedor=@Nm,IDEmpleado=@App, Dia=@Apm,Mes=@Rfc,Año=@Cr,Importe=@Tl WHERE IDPedido=@Cl";
                using (SqlCommand Cmd = new SqlCommand(CdSql, Cnx))
                {
                    //Añadir los parámetros
                    Cmd.Parameters.AddWithValue("@Cl", Pqte.IDPedido);//Get y set de la capa entidad
                    Cmd.Parameters.AddWithValue("@Nm", Pqte.IDProveedor);
                    Cmd.Parameters.AddWithValue("@App", Pqte.IDEmpleado);
                    Cmd.Parameters.AddWithValue("@Apm", Pqte.Dia);
                    Cmd.Parameters.AddWithValue("@Rfc", Pqte.Mes);
                    Cmd.Parameters.AddWithValue("@Cr", Pqte.Año);
                    Cmd.Parameters.AddWithValue("@Tl", Pqte.Importe);
                    Cmd.ExecuteNonQuery();
                    //Borrar variable cmd de la memoria
                    Cmd.Dispose();
                }
                Cnx.Close();
            }
        }
    }
}
