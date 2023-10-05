using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos.Implementacion
{
    public class OrdenDao : IOrdenDao
    {
        public bool crear(OrdenRetiro oOrdenRetiro)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.obtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;


            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_ORDEN";
                comando.Parameters.AddWithValue("@responsable", oOrdenRetiro.Responsable);
                comando.Parameters.AddWithValue("@stock", oOrdenRetiro.RestarStock());

                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@nro";
                

                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();

                int ordenNro = (int)parametro.Value;
                int detalleNro = 1;
                SqlCommand cmdDetalle;
                

                foreach(DetalleOrden Do in oOrdenRetiro.LstDetalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", conexion,t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_orden", ordenNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle",detalleNro);
                    cmdDetalle.Parameters.AddWithValue("@codigo",Do.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad",Do.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;


                }

                t.Commit();
            }
            catch { 
                if (t!=null)
                    t.Rollback();  
                resultado = false;
            }
            finally { if(conexion != null && conexion.State== ConnectionState.Open) conexion.Close(); }

            return resultado;
        }

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
