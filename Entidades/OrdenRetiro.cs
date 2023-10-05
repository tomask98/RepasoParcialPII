using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Entidades
{
    public class OrdenRetiro
    {
        public int NroOrden { get; set; }
        public DateTime Fecha { get; set; }

        public string Responsable { get; set; }

        public List<DetalleOrden> LstDetalle { get; set; }
        public OrdenRetiro()
        {
            LstDetalle = new List<DetalleOrden>();
        }

        public void AgregarDetalle (DetalleOrden detalle)
        {
            LstDetalle.Add(detalle);
        }
        public void quitarDetalle(int posicion)
        {
            LstDetalle.RemoveAt(posicion);
        }



    }
}
