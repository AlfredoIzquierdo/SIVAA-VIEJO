using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class VersionLog
    {
        private VersionD Pdto = new VersionD();//No poner public
        private VersionD Pdto2 = new VersionD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();
        public readonly StringBuilder Mensaje2 = new StringBuilder();

        public void Registrar(Versions Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDVersion) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Identificador de la versión ya se encuentra en la B.D.");
            }
        }

        public List<Versions> ListadoTotal()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }
        public Versions ObtenerFicha(string id,string nombre )
        {
            Versions datos = Pdto.ObtenerPdtoPorNombreModelo(id, nombre);
            return datos;
        }

        public Versions ObtenerPdto(string ClPdto, string idVeh)
        {
            Versions Pd = null;
            Mensaje.Clear();
            if (ClPdto == "")
                Mensaje.Append("Por favor proporcionar una versión");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdtoPorNombreModelo(ClPdto, idVeh);
                if (Pd == null)
                    Mensaje.Append("La versión no existe en la B.D.");
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

        public void Modificar(Versions Pqte)
        {
            if (ValidarProducto(Pqte))
                Pdto.Actualizar(Pqte);
        }


        private bool ValidarProducto(Versions Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDVersion))
                Mensaje.Append("El campo IDVersión no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDVehiculo))
                Mensaje.Append("El campo IDVehiculo no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Llantas))
                Mensaje.Append("El campo Llantas no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.TipoAsientos))
                Mensaje.Append("El campo Tipo asientos no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.CamaraTrasera))
                Mensaje.Append("El campo Cámara trasera no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Pantalla))
                Mensaje.Append("El campo Pantalla no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.TipoCombustible))
                Mensaje.Append("El campo tipo de combustible no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Version))
                Mensaje.Append("El campo Version no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Rines))
                Mensaje.Append("El campo tamaño de rines no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Cilindraje))
                Mensaje.Append("El campo cilindraje no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Costo.ToString()))
                Mensaje.Append("El campo Costo no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.CapacidadCajuela))
                Mensaje.Append("El campo Capacidad de Cajuela no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.DistanciaEjes))
                Mensaje.Append("El campo Distancia de ejes no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Anchura))
                Mensaje.Append("El campo Anchura no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Altura))
                Mensaje.Append("El campo Altura no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.AudioVelC))
                Mensaje.Append("El campo AudioVelC no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.TomaCorriente))
                Mensaje.Append("El campo Toma Corriente no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.TipoTraccion))
                Mensaje.Append("El campo Tipo Tracción no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.NumPuertas))
                Mensaje.Append("El campo número de puertas no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Transmision))
                Mensaje.Append("El campo Transmisión no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.FarosHal))
                Mensaje.Append("El campo Faros hal no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.NumEngranajes))
                Mensaje.Append("El campo Número de engranajes no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.ACAutom))
                Mensaje.Append("El campo Aire acondicionado automático no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.FarosLED))
                Mensaje.Append("El campo Faros LED no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.RendimientoCombustible))
                Mensaje.Append("El campo Rendimiento de combustible no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.FrenosTraseros))
                Mensaje.Append("El campo Frenos traseros no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.SuspensionDelantera))
                Mensaje.Append("El campo Suspensión delantera no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.SuspensionTrasera))
                Mensaje.Append("El campo Suspensión trasera no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.EspejosLatDirC))
                Mensaje.Append("El campo Espejos laterales dirección no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.EspejosLatAE))
                Mensaje.Append("El campo Espejos Laterales AE no puede estar vacio");
            return Mensaje.Length == 0;

        }

    }
}
