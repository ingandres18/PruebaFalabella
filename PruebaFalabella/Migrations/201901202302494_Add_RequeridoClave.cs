namespace PruebaFalabella.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RequeridoClave : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Asesores", "Clave", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asesores", "Clave", c => c.String());
        }
    }
}
