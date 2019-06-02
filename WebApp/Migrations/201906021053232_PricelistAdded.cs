namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PricelistAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DeparturesDbModels", newName: "DepartureDbModels");
            CreateTable(
                "dbo.PriceDbModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.Int(nullable: false),
                        PassengerType = c.Int(nullable: false),
                        TicketType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PriceDbModels");
            RenameTable(name: "dbo.DepartureDbModels", newName: "DeparturesDbModels");
        }
    }
}
