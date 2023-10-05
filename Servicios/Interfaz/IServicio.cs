using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicios.Interfaz
{
    public interface IServicio
    {
        bool crearOrden(OrdenRetiro oOrdenRetirro);
        List<Material> TraerMaterial();
    }
}
