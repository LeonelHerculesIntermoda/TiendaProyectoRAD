namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionRelacionGrupoClienteConCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "GrupoClienteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "GrupoClienteId");
        }
    }
}
