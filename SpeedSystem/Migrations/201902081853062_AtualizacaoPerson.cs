namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PhysicalOrLegalName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.People", "LastNameOrFantasyName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.People", "RGOrStateRegistration", c => c.String());
            AddColumn("dbo.People", "DateBirthOrOpening", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "Responsible", c => c.String(maxLength: 100));
            AddColumn("dbo.People", "DataCreate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.People", "FirstName");
            DropColumn("dbo.People", "LastName");
            DropColumn("dbo.People", "DateBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "DateBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.People", "DataCreate");
            DropColumn("dbo.People", "Responsible");
            DropColumn("dbo.People", "DateBirthOrOpening");
            DropColumn("dbo.People", "RGOrStateRegistration");
            DropColumn("dbo.People", "LastNameOrFantasyName");
            DropColumn("dbo.People", "PhysicalOrLegalName");
        }
    }
}
