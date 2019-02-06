namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            AddColumn("dbo.People", "EmployeeId", c => c.Int());
            AddColumn("dbo.People", "Commission", c => c.Single());
            AddColumn("dbo.People", "DepartmentId", c => c.Int());
            CreateIndex("dbo.People", "DepartmentId");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Commission = c.Single(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            DropIndex("dbo.People", new[] { "DepartmentId" });
            DropColumn("dbo.People", "DepartmentId");
            DropColumn("dbo.People", "Commission");
            DropColumn("dbo.People", "EmployeeId");
            CreateIndex("dbo.Employees", "DepartmentId");
        }
    }
}
