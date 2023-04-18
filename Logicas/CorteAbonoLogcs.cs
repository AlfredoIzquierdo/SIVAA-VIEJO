using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class CorteAbonoLogcs
    {
        private CorteAbonoD Pdto = new CorteAbonoD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(CorteAbono Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDAbono) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del corteabono ya se encuentra en la B.D.");
            }
        }

        public List<CorteAbono> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public CorteAbono LeerPorClave(string ClPdto)
        {
            CorteAbono Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo del corteabono no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        //public List<Pago> ListadoPorNA(string ClPdto, string Ap)
        //{
        //    List<Pago> Pd = new List<Pago>();
        //    Mensaje.Clear();
        //    if (ClPdto == "0")
        //        Mensaje.Append("Por favor proporcionar una clave valida");
        //    if (Mensaje.Length == 0)
        //    {
        //        Pd = Pdto.ListadoTotalESP(ClPdto, Ap);
        //        if (Pd == null)
        //            Mensaje.Append("Nombre o apellido del cliente no existe en la B.D.");
        //        return Pd;
        //    }
        //    return null;
        //}

        //public void Eliminar(string CodPqte)
        //{
        //    Mensaje.Clear();
        //    if (CodPqte == "0")
        //        Mensaje.Append("Por favor proporcionar un Codigo valido");
        //    if (Mensaje.Length == 0)
        //        Pdto.Eliminar(CodPqte);
        //}

        private bool ValidarProducto(CorteAbono Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDCorteCaja))
                Mensaje.Append("El campo IDcortecaja no puede estar vacio");
            return Mensaje.Length == 0;

        }

        //public void Modificar(Pago Pqte)
        //{
        //    if (ValidarProducto(Pqte))
        //    {
        //        Pdto.Actualizar(Pqte);

        //    }
        //}
    }
}
