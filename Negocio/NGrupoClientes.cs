using Datos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NGrupoClientes
    {
        DGrupoCliente dGrupoCLiente;
        public NGrupoClientes()
        {
            dGrupoCLiente = new DGrupoCliente();
        }

        public List<GrupoCliente> obtenerGruposCliente() 
        {
            return dGrupoCLiente.TodasLosGrupos();
        }
    }
}
