namespace Abp.Samples.Blog.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamed_Tables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "BlgCategories");
            RenameTable(name: "dbo.Comments", newName: "BlgComments");
            RenameTable(name: "dbo.Posts", newName: "BlgPosts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BlgPosts", newName: "Posts");
            RenameTable(name: "dbo.BlgComments", newName: "Comments");
            RenameTable(name: "dbo.BlgCategories", newName: "Categories");
        }
    }
}
