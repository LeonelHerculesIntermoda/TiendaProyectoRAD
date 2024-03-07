namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionRelacionGrupoClienteConCliente2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cliente", "GrupoClienteId");
            AddForeignKey("dbo.Cliente", "GrupoClienteId", "dbo.GrupoCliente", "GrupoClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "GrupoClienteId", "dbo.GrupoCliente");
            DropIndex("dbo.Cliente", new[] { "GrupoClienteId" });
        }
    }
}
