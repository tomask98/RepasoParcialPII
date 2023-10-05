using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Datos
{
    internal class Parametro
    {
        public string Nombre { get; set; }
        public int Valor { get; set; }

        public Parametro(string nombre,int valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
