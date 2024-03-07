using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NClasificacionClientes
    {
        DClasificacionCliente dClasificacionCLiente;
        public NClasificacionClientes()
        {
            dClasificacionCLiente = new DClasificacionCliente();
        }

        public List<ClasificacionCliente> obtenerClasificacionesCliente() 
        {
            return dClasificacionCLiente.TodasLasClasificaciones();
        }

        public List<ClasificacionCliente> obtenerClasificacionesInactivas()
        {
            var clasificaciones = dClasificacionCLiente.TodasLasClasificaciones();
            return clasificaciones.Where(c => c.Estado == true).ToList();
        }

        public int Guardar(ClasificacionCliente clasificacionCliente)
        {
            if (clasificacionCliente.ClasificacionClienteId == 0) 
            {
                return dClasificacionCLiente.Agregar(clasificacionCliente);
            }
            else
            {
                return dClasificacionCLiente.Editar(clasificacionCliente);
            }
            
        }

        public int Eliminar(int clasificacionId)
        {
            return dClasificacionCLiente.Eliminar(clasificacionId);
        }
    }
}
