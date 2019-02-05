namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mi3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meshes", "ColorMesh_ColorMeshId", "dbo.ColorMeshes");
            DropIndex("dbo.Meshes", new[] { "ColorMesh_ColorMeshId" });
            AlterColumn("dbo.Meshes", "ColorMesh_ColorMeshId", c => c.Int(nullable: false));
            CreateIndex("dbo.Meshes", "ColorMesh_ColorMeshId");
            AddForeignKey("dbo.Meshes", "ColorMesh_ColorMeshId", "dbo.ColorMeshes", "ColorMeshId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meshes", "ColorMesh_ColorMeshId", "dbo.ColorMeshes");
            DropIndex("dbo.Meshes", new[] { "ColorMesh_ColorMeshId" });
            AlterColumn("dbo.Meshes", "ColorMesh_ColorMeshId", c => c.Int());
            CreateIndex("dbo.Meshes", "ColorMesh_ColorMeshId");
            AddForeignKey("dbo.Meshes", "ColorMesh_ColorMeshId", "dbo.ColorMeshes", "ColorMeshId");
        }
    }
}
