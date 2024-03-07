using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos
{
    public class TiendaContext : DbContext
    {
        public TiendaContext():base("name=Tienda")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ClasificacionCliente> ClasificacionClientes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<GrupoCliente> GrupoClientes { get; set; }
    }
}
