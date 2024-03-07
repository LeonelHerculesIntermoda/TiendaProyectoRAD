using Datos.BaseDatos;
using Datos.Core;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DClasificacionCliente
    {
        //TiendaContext context;
        Repository<ClasificacionCliente> _repository; 
        public DClasificacionCliente()
        {
            _repository = new Repository<ClasificacionCliente>();
            //context = new TiendaContext();
        }
        public int ClasificacionClienteId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public List<ClasificacionCliente> TodasLasClasificaciones() 
        {
            return _repository.Consulta().ToList();
            //return new List<ClasificacionCliente>();  //context.ClasificacionClientes.ToList();
        }

        public int Agregar(ClasificacionCliente clasificacionCliente) 
        {
            clasificacionCliente.FechaCreacion = DateTime.Now;
            clasificacionCliente.FechaModificacion = DateTime.Now;
            //context.ClasificacionClientes.Add(clasificacionCliente);
            //return context.SaveChanges();
            _repository.Agregar(clasificacionCliente);
            return 1;
        }

        public int Editar(ClasificacionCliente clasificacionCliente)
        {
            var clasificacionInDb = _repository.Consulta().FirstOrDefault(c => c.ClasificacionClienteId == clasificacionCliente.ClasificacionClienteId);

            if (clasificacionInDb != null)
            {
                clasificacionInDb.FechaModificacion = DateTime.Now;
                clasificacionInDb.Codigo = clasificacionCliente.Codigo;
                clasificacionInDb.Descripcion = clasificacionCliente.Descripcion;
                clasificacionInDb.Estado = clasificacionCliente.Estado;
                _repository.Editar(clasificacionInDb);

                return 1;
            }
            return 0;
        }
        public int Eliminar(int clasificacionId)
        {
            var clasificacionInDb = _repository.Consulta().FirstOrDefault(c => c.ClasificacionClienteId == clasificacionId);

            if (clasificacionInDb != null)
            {
                _repository.Eliminar(clasificacionInDb);
                return 1;
            }
            return 0;

        }
    }
}
