using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Abp.Samples.Blog.EntityFramework.Migrations
{
    public partial class Added_Initial_Blog_Entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);

            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 2000),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false),
                        Tags = c.String(),
                        Status = c.Byte(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Post_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId)
                .ForeignKey("dbo.AbpUsers", t => t.DeleterUserId)
                .ForeignKey("dbo.AbpUsers", t => t.LastModifierUserId)
                .Index(t => t.CategoryId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "LastModifierUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Posts", "DeleterUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Posts", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Comments", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Categories", "CreatorUserId", "dbo.AbpUsers");
            DropIndex("dbo.Posts", new[] { "CreatorUserId" });
            DropIndex("dbo.Posts", new[] { "LastModifierUserId" });
            DropIndex("dbo.Posts", new[] { "DeleterUserId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Comments", new[] { "CreatorUserId" });
            DropIndex("dbo.Categories", new[] { "CreatorUserId" });
            DropTable("dbo.Posts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Post_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
