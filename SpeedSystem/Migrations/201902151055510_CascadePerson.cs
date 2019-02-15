namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadePerson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "PersonId", "dbo.People");
            AddForeignKey("dbo.Telephones", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "PersonId", "dbo.People");
            AddForeignKey("dbo.Telephones", "PersonId", "dbo.People", "PersonId");
        }
    }
}
