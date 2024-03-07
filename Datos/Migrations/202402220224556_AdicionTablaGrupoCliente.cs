namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaGrupoCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoCliente",
                c => new
                    {
                        GrupoClienteId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoCliente");
        }
    }
}
