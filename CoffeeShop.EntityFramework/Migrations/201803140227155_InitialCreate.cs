namespace CoffeeShop.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        OfficeID = c.Int(nullable: false, identity: true),
                        OfficeName = c.String(),
                        PantryName = c.String(),
                    })
                .PrimaryKey(t => t.OfficeID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Unit = c.Int(nullable: false),
                        OfficeInfo_OfficeID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Office", t => t.OfficeInfo_OfficeID)
                .Index(t => t.OfficeInfo_OfficeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "OfficeInfo_OfficeID", "dbo.Office");
            DropIndex("dbo.Product", new[] { "OfficeInfo_OfficeID" });
            DropTable("dbo.Product");
            DropTable("dbo.Office");
        }
    }
}
