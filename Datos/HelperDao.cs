﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos
{
    internal class HelperDao
    {
        private static HelperDao instancia;

        private SqlConnection conexion;

        HelperDao()
        {
            conexion = new SqlConnection(Properties.Resources.CadenaConexion);
        }
        public static HelperDao obtenerInstancia()
        {
            if(instancia== null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        internal DataTable consultar(string nombreSP) 
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public SqlConnection ObtenerConexion()
        {
            return this.conexion;
        }
    }
}
