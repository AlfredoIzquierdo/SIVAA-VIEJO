using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class EmpleadoLog
    {
        private EmpleadoD Pdto = new EmpleadoD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(Empleado Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDEmpleado) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cliente ya se encuentra en la B.D.");
            }
        }

        public List<Empleado> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }
        public List<Empleado> ListadoAllCajeros()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoCajeros();
        }
        public Empleado LeerPorClave(string ClPdto, string Con)
        {
            Empleado Pd = null;
            Mensaje.Clear();
            if (ClPdto == "")
                Mensaje.Append("Por favor proporcionar una correo valido");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto,Con);
                if (Pd == null)
                    Mensaje.Append("El correo o contraseña son incorrectos");
                return Pd;
            }
            return null;
        }
        public Empleado LeerPorClave(string ClPdto)
        {
            Empleado Pd = null;
            Mensaje.Clear();
            if (ClPdto == "")
                Mensaje.Append("Por favor proporcionar una correo valido");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("El correo no existe en la B.D.");
                return Pd;
            }
            return null;
        }

        public void Eliminar(string CodPqte)
        {
            Mensaje.Clear();
            if (CodPqte == "0")
                Mensaje.Append("Por favor proporcionar un Codigo valido");
            if (Mensaje.Length == 0)
                Pdto.Eliminar(CodPqte);
        }

        private bool ValidarProducto(Empleado Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.Nombre))
                Mensaje.Append("El campo nombre no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.ApellidoPat))
                Mensaje.Append("El campo apellido paterno no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.ApellidoMat))
                Mensaje.Append("El campo apellido materno no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.RFC))
                Mensaje.Append("El campo RFC no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Correo))
                Mensaje.Append("El campo correo no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Telefono))
                Mensaje.Append("El campo telefono no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Contraseña))
                Mensaje.Append("El campo no.exterior no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Tipo))
                Mensaje.Append("El campo colonia no puede estar vacio");
            return Mensaje.Length == 0;

        }

        public void Modificar(Empleado Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }
        }
    }
}
