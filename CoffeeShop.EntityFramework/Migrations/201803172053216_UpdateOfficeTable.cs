namespace CoffeeShop.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOfficeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Office", "HasProduct", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Office", "HasProduct");
        }
    }
}
