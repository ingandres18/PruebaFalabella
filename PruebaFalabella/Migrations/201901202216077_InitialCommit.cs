namespace PruebaFalabella.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asesores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimerNombre = c.String(nullable: false),
                        SegundoNombre = c.String(),
                        PrimerApelldo = c.String(nullable: false),
                        SegundoApellido = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        Asesor_Id = c.Int(),
                        Cliente_Id = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asesores", t => t.Asesor_Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Productos", t => t.Producto_Id)
                .Index(t => t.Asesor_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimerNombre = c.String(nullable: false),
                        SegundoNombre = c.String(),
                        PrimerApelldo = c.String(nullable: false),
                        SegundoApellido = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Compania_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companias", t => t.Compania_Id)
                .Index(t => t.Compania_Id);
            
            CreateTable(
                "dbo.Companias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Ciudad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "Producto_Id", "dbo.Productos");
            DropForeignKey("dbo.Productos", "Compania_Id", "dbo.Companias");
            DropForeignKey("dbo.Ventas", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Ventas", "Asesor_Id", "dbo.Asesores");
            DropIndex("dbo.Productos", new[] { "Compania_Id" });
            DropIndex("dbo.Ventas", new[] { "Producto_Id" });
            DropIndex("dbo.Ventas", new[] { "Cliente_Id" });
            DropIndex("dbo.Ventas", new[] { "Asesor_Id" });
            DropTable("dbo.Companias");
            DropTable("dbo.Productos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Ventas");
            DropTable("dbo.Asesores");
        }
    }
}
