using ModeloParcial.Datos.Implementacion;
using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Entidades;
using ModeloParcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IOrdenDao Dao;
        public Servicio()
        {
            Dao = new OrdenDao();
        }
        public List<Material> TraerMaterial()
        {
            return Dao.obtenerMateriales();
        }
    }
}
