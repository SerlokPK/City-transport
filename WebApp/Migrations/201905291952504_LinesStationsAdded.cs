namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinesStationsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineDbModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StationLineDbModels",
                c => new
                    {
                        StationId = c.Int(nullable: false),
                        LineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StationId, t.LineId })
                .ForeignKey("dbo.LineDbModels", t => t.LineId, cascadeDelete: true)
                .ForeignKey("dbo.StationDbModels", t => t.StationId, cascadeDelete: true)
                .Index(t => t.StationId)
                .Index(t => t.LineId);
            
            CreateTable(
                "dbo.StationDbModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StationLineDbModels", "StationId", "dbo.StationDbModels");
            DropForeignKey("dbo.StationLineDbModels", "LineId", "dbo.LineDbModels");
            DropIndex("dbo.StationLineDbModels", new[] { "LineId" });
            DropIndex("dbo.StationLineDbModels", new[] { "StationId" });
            DropTable("dbo.StationDbModels");
            DropTable("dbo.StationLineDbModels");
            DropTable("dbo.LineDbModels");
        }
    }
}
