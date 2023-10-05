using ModeloParcial.Servicios.Implementacion;
using ModeloParcial.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicios
{
    public class FabricaServiciosImp: FabricaServicio
    {
        public override IServicio CrearServicio()
        {
            return new Servicio();
        }
    }
}
