namespace lab_49_ToDoItems_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLastLoggedIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50, unicode: false),
                        CategoryDescription = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50, unicode: false),
                        ToDoItemID = c.Int(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.ToDoItems", t => t.ToDoItemID)
                .Index(t => t.ToDoItemID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ToDoItems",
                c => new
                    {
                        ToDoItemId = c.Int(nullable: false, identity: true),
                        Item = c.String(maxLength: 50, unicode: false),
                        DateDue = c.DateTime(storeType: "date"),
                        Done = c.Boolean(),
                    })
                .PrimaryKey(t => t.ToDoItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ToDoItemID", "dbo.ToDoItems");
            DropForeignKey("dbo.Users", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "CategoryID" });
            DropIndex("dbo.Users", new[] { "ToDoItemID" });
            DropTable("dbo.ToDoItems");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
