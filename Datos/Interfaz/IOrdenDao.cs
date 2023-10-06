using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos.Interfaz
{
    public interface IOrdenDao
    {
        bool crear(OrdenRetiro oOrdenRetiro);
        List<Material> obtenerMateriales(); // cargar el combo 
    }
}
