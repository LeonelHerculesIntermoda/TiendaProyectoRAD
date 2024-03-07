using Datos.BaseDatos;
using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Datos.Core;

namespace Datos
{
    public class DClientes
    {
        Repository<Cliente> _repository;
        public DClientes()
        {
            _repository = new Repository<Cliente>();
        }
        public int ClienteId { get; set; }
        public string Codigo { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        public int ClasificacionClienteId { get; set; }

        public List<Cliente> TodasLosClientes()
        {
            return _repository.Consulta().Include(c=>c.ClasificacionCliente).ToList();
        }

        public int Agregar(Cliente cliente)
        {
            cliente.FechaCreacion = DateTime.Now;
            cliente.FechaModificacion = DateTime.Now;
            _repository.Agregar(cliente);

            return 1;
        }

        public int Editar(Cliente cliente)
        {
            //var clienteInDb = context.Clientes.Find(cliente.ClienteId);
            var clienteInDb = _repository.Consulta().FirstOrDefault(C=> C.ClienteId == cliente.ClienteId);

            if (clienteInDb != null)
            {
                clienteInDb.FechaModificacion = DateTime.Now;
                clienteInDb.Codigo = cliente.Codigo;
                clienteInDb.DNI = cliente.DNI;
                clienteInDb.Nombres = cliente.Nombres;
                clienteInDb.Apellidos = cliente.Apellidos;
                clienteInDb.FechaIngreso = cliente.FechaIngreso;
                clienteInDb.Estado = cliente.Estado;
                _repository.Editar(clienteInDb);
                return 1;

            }
            return 0;
        }

        public int Eliminar(int clienteId)
        {
            //var clienteInDb = context.Clientes.Find(clienteId);
            var clienteInDb = _repository.Consulta().FirstOrDefault(C => C.ClienteId == clienteId);
            if (clienteInDb != null)
            {
                _repository.Eliminar(clienteInDb);
                return 1;
            }
            return 0;
        }
    }
}
