namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class erros : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Telephones", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Telephones", new[] { "Person_PersonId" });
            CreateTable(
                "dbo.TelephonePersons",
                c => new
                    {
                        Telephone_TelephoneId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Telephone_TelephoneId, t.Person_PersonId })
                .ForeignKey("dbo.Telephones", t => t.Telephone_TelephoneId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_PersonId, cascadeDelete: true)
                .Index(t => t.Telephone_TelephoneId)
                .Index(t => t.Person_PersonId);
            
            AddColumn("dbo.Telephones", "PersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Telephones", "Person_PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Telephones", "Person_PersonId", c => c.Int());
            DropForeignKey("dbo.TelephonePersons", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.TelephonePersons", "Telephone_TelephoneId", "dbo.Telephones");
            DropIndex("dbo.TelephonePersons", new[] { "Person_PersonId" });
            DropIndex("dbo.TelephonePersons", new[] { "Telephone_TelephoneId" });
            DropColumn("dbo.Telephones", "PersonId");
            DropTable("dbo.TelephonePersons");
            CreateIndex("dbo.Telephones", "Person_PersonId");
            AddForeignKey("dbo.Telephones", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
