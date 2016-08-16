namespace DataCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemMasters",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ItemCode = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        imagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId_Id = c.Guid(),
                        ItemId_Id = c.Guid(),
                        OrderId_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId_Id)
                .ForeignKey("dbo.ItemMasters", t => t.ItemId_Id)
                .ForeignKey("dbo.SalesOrders", t => t.OrderId_Id)
                .Index(t => t.CustomerId_Id)
                .Index(t => t.ItemId_Id)
                .Index(t => t.OrderId_Id);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderNo = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerId_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId_Id)
                .Index(t => t.CustomerId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrderItems", "OrderId_Id", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesOrders", "CustomerId_Id", "dbo.Customers");
            DropForeignKey("dbo.SalesOrderItems", "ItemId_Id", "dbo.ItemMasters");
            DropForeignKey("dbo.SalesOrderItems", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.SalesOrders", new[] { "CustomerId_Id" });
            DropIndex("dbo.SalesOrderItems", new[] { "OrderId_Id" });
            DropIndex("dbo.SalesOrderItems", new[] { "ItemId_Id" });
            DropIndex("dbo.SalesOrderItems", new[] { "CustomerId_Id" });
            DropTable("dbo.SalesOrders");
            DropTable("dbo.SalesOrderItems");
            DropTable("dbo.ItemMasters");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Customers");
        }
    }
}
