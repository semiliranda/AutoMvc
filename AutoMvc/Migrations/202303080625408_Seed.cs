namespace AutoMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autoes", "Lessee", c => c.String());
            AddColumn("dbo.Autoes", "Status", c => c.String());
            DropColumn("dbo.Autoes", "ReleaseDate");
            DropColumn("dbo.Autoes", "Type");
            DropColumn("dbo.Autoes", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Autoes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Autoes", "Type", c => c.String());
            AddColumn("dbo.Autoes", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Autoes", "Status");
            DropColumn("dbo.Autoes", "Lessee");
        }
    }
}
