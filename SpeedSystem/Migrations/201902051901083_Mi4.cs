namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mi4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meshes", "Measure_MeasureId", "dbo.Measures");
            DropIndex("dbo.Meshes", new[] { "Measure_MeasureId" });
            AlterColumn("dbo.Meshes", "Measure_MeasureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Meshes", "Measure_MeasureId");
            AddForeignKey("dbo.Meshes", "Measure_MeasureId", "dbo.Measures", "MeasureId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meshes", "Measure_MeasureId", "dbo.Measures");
            DropIndex("dbo.Meshes", new[] { "Measure_MeasureId" });
            AlterColumn("dbo.Meshes", "Measure_MeasureId", c => c.Int());
            CreateIndex("dbo.Meshes", "Measure_MeasureId");
            AddForeignKey("dbo.Meshes", "Measure_MeasureId", "dbo.Measures", "MeasureId");
        }
    }
}
