namespace CoffeeShop.EntityFramework.Migrations
{
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
                        OfficeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Office", t => t.OfficeID, cascadeDelete: true)
                .Index(t => t.OfficeID);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        ClientName = c.String(),
                        OfficeID = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "OfficeID", "dbo.Office");
            DropIndex("dbo.Product", new[] { "OfficeID" });
            DropTable("dbo.OrderItem");
            DropTable("dbo.Product");
            DropTable("dbo.Office");
        }
    }
}
