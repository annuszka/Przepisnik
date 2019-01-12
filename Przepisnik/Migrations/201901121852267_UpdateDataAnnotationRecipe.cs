namespace Przepisnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataAnnotationRecipe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipe", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Recipe", "Ingredients", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Recipe", "Preparation", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Recipe", "AverageRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipe", "AverageRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipe", "Preparation", c => c.String(maxLength: 500));
            AlterColumn("dbo.Recipe", "Ingredients", c => c.String(maxLength: 300));
            AlterColumn("dbo.Recipe", "Title", c => c.String(maxLength: 150));
        }
    }
}
