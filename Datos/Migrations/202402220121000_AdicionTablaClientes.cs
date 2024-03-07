namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaClientes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ClasificacionClientes", newName: "ClasificacionCliente");
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        DNI = c.String(nullable: false, maxLength: 25),
                        Nombres = c.String(nullable: false, maxLength: 80),
                        Apellidos = c.String(nullable: false, maxLength: 80),
                        FechaIngreso = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        ClasificacionClienteId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.ClasificacionCliente", t => t.ClasificacionClienteId)
                .Index(t => t.ClasificacionClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "ClasificacionClienteId", "dbo.ClasificacionCliente");
            DropIndex("dbo.Cliente", new[] { "ClasificacionClienteId" });
            DropTable("dbo.Cliente");
            RenameTable(name: "dbo.ClasificacionCliente", newName: "ClasificacionClientes");
        }
    }
}
