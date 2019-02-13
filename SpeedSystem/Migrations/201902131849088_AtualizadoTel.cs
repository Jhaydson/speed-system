namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizadoTel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TelephonePersons", "Telephone_TelephoneId", "dbo.Telephones");
            DropForeignKey("dbo.TelephonePersons", "Person_PersonId", "dbo.People");
            DropIndex("dbo.TelephonePersons", new[] { "Telephone_TelephoneId" });
            DropIndex("dbo.TelephonePersons", new[] { "Person_PersonId" });
            CreateIndex("dbo.Telephones", "PersonId");
            AddForeignKey("dbo.Telephones", "PersonId", "dbo.People", "PersonId");
            DropTable("dbo.TelephonePersons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TelephonePersons",
                c => new
                    {
                        Telephone_TelephoneId = c.Int(nullable: false),
                        Person_PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Telephone_TelephoneId, t.Person_PersonId });
            
            DropForeignKey("dbo.Telephones", "PersonId", "dbo.People");
            DropIndex("dbo.Telephones", new[] { "PersonId" });
            CreateIndex("dbo.TelephonePersons", "Person_PersonId");
            CreateIndex("dbo.TelephonePersons", "Telephone_TelephoneId");
            AddForeignKey("dbo.TelephonePersons", "Person_PersonId", "dbo.People", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.TelephonePersons", "Telephone_TelephoneId", "dbo.Telephones", "TelephoneId", cascadeDelete: true);
        }
    }
}
