using Datos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos
{
    public class DGrupoCliente
    {
        TiendaContext context;
        public DGrupoCliente()
        {
            context = new TiendaContext();
        }
        public int GrupoClienteId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public List<GrupoCliente> TodasLosGrupos()
        {
            return context.GrupoClientes.ToList();
        }
    }
}
