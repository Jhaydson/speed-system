namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Departments", "Name", unique: true, name: "Department_Name_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", "Department_Name_Index");
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
        }
    }
}
