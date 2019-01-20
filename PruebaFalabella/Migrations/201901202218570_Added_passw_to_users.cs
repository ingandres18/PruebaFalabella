namespace PruebaFalabella.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_passw_to_users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asesores", "Clave", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asesores", "Clave");
        }
    }
}
