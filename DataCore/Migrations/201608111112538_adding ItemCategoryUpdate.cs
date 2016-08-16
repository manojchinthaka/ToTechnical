namespace DataCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingItemCategoryUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemMasters", "ItemCategoryId_Id", c => c.Guid());
            CreateIndex("dbo.ItemMasters", "ItemCategoryId_Id");
            AddForeignKey("dbo.ItemMasters", "ItemCategoryId_Id", "dbo.ItemCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemMasters", "ItemCategoryId_Id", "dbo.ItemCategories");
            DropIndex("dbo.ItemMasters", new[] { "ItemCategoryId_Id" });
            DropColumn("dbo.ItemMasters", "ItemCategoryId_Id");
        }
    }
}
