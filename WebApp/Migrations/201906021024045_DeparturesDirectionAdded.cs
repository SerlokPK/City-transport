namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeparturesDirectionAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeparturesDbModels", "Direction", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeparturesDbModels", "Direction");
        }
    }
}
