namespace SuperShoes.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeofthedatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Articles", "TotalInVault", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "TotalInVault", c => c.Double(nullable: false));
            AlterColumn("dbo.Articles", "Price", c => c.Double(nullable: false));
        }
    }
}
