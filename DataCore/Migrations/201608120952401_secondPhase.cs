namespace DataCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondPhase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemMasters", "ItemCategoryId_Id", "dbo.ItemCategories");
            DropIndex("dbo.ItemMasters", new[] { "ItemCategoryId_Id" });
            RenameColumn(table: "dbo.ItemMasters", name: "ItemCategoryId_Id", newName: "ItemCategoryId");
            AlterColumn("dbo.ItemMasters", "ItemCategoryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ItemMasters", "ItemCategoryId");
            AddForeignKey("dbo.ItemMasters", "ItemCategoryId", "dbo.ItemCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemMasters", "ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.ItemMasters", new[] { "ItemCategoryId" });
            AlterColumn("dbo.ItemMasters", "ItemCategoryId", c => c.Guid());
            RenameColumn(table: "dbo.ItemMasters", name: "ItemCategoryId", newName: "ItemCategoryId_Id");
            CreateIndex("dbo.ItemMasters", "ItemCategoryId_Id");
            AddForeignKey("dbo.ItemMasters", "ItemCategoryId_Id", "dbo.ItemCategories", "Id");
        }
    }
}
