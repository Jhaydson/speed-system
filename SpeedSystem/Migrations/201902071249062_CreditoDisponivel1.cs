namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditoDisponivel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "CreditLimit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "CreditLimit", c => c.Single(nullable: false));
        }
    }
}
