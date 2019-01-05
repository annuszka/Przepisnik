namespace Przepisnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.RecipeCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        RecipePhotoUrl = c.String(),
                        AddingDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Ingredients = c.String(),
                        Preparation = c.String(),
                        PrepTime = c.String(),
                        Portions = c.Int(nullable: false),
                        Source = c.String(),
                        IfPublic = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        AverageRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeCategory", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeCategory", "CategoryID", "dbo.Category");
            DropIndex("dbo.RecipeCategory", new[] { "CategoryID" });
            DropIndex("dbo.RecipeCategory", new[] { "RecipeID" });
            DropTable("dbo.Recipe");
            DropTable("dbo.RecipeCategory");
            DropTable("dbo.Category");
        }
    }
}
