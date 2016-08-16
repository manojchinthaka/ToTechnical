namespace DataCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingSalesOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesOrderItems", "CustomerId_Id", "dbo.Customers");
            DropIndex("dbo.SalesOrderItems", new[] { "CustomerId_Id" });
            DropColumn("dbo.SalesOrderItems", "CustomerId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesOrderItems", "CustomerId_Id", c => c.Guid());
            CreateIndex("dbo.SalesOrderItems", "CustomerId_Id");
            AddForeignKey("dbo.SalesOrderItems", "CustomerId_Id", "dbo.Customers", "Id");
        }
    }
}
