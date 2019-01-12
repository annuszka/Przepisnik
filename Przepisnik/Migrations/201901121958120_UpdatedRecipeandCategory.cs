namespace Przepisnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRecipeandCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeCategory1",
                c => new
                    {
                        Recipe_RecipeID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeID, t.Category_CategoryID })
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeID)
                .Index(t => t.Category_CategoryID);
            
            AlterColumn("dbo.Category", "CategoryName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeCategory1", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.RecipeCategory1", "Recipe_RecipeID", "dbo.Recipe");
            DropIndex("dbo.RecipeCategory1", new[] { "Category_CategoryID" });
            DropIndex("dbo.RecipeCategory1", new[] { "Recipe_RecipeID" });
            AlterColumn("dbo.Category", "CategoryName", c => c.String());
            DropTable("dbo.RecipeCategory1");
        }
    }
}
