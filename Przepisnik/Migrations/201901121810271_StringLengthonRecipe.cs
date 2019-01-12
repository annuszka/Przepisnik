namespace Przepisnik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLengthonRecipe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipe", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.Recipe", "Description", c => c.String(maxLength: 150));
            AlterColumn("dbo.Recipe", "Ingredients", c => c.String(maxLength: 300));
            AlterColumn("dbo.Recipe", "Preparation", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipe", "Preparation", c => c.String());
            AlterColumn("dbo.Recipe", "Ingredients", c => c.String());
            AlterColumn("dbo.Recipe", "Description", c => c.String());
            AlterColumn("dbo.Recipe", "Title", c => c.String());
        }
    }
}
