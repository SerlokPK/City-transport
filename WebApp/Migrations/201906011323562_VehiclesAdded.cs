namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehiclesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleDbModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        LineDbModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LineDbModels", t => t.LineDbModelId, cascadeDelete: true)
                .Index(t => t.LineDbModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleDbModels", "LineDbModelId", "dbo.LineDbModels");
            DropIndex("dbo.VehicleDbModels", new[] { "LineDbModelId" });
            DropTable("dbo.VehicleDbModels");
        }
    }
}
