namespace PruebaFalabella.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Includ_Documento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Documento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Documento");
        }
    }
}
