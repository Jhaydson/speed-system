namespace SpeedSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditoDisponivel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "AvailableCredit", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "AvailableCredit");
        }
    }
}
