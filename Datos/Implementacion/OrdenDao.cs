using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos.Implementacion
{
    public class OrdenDao : IOrdenDao
    {
        public List<Material> obtenerMateriales()
        {
            List<Material> lmaterial = new List<Material>();
            DataTable tabla = HelperDao.obtenerInstancia().consultar("SP_CONSULTAR_MATERIALES");
            foreach (DataRow fila in tabla.Rows)
            {
                int codigo = int.Parse(fila["codigo"].ToString());
                string nombre = fila["nombre"].ToString();
                double stock = double.Parse(fila["stock"].ToString());

                Material M = new Material(codigo,nombre,stock);

                lmaterial.Add(M);
            }

            return lmaterial;
        }
    }
}
