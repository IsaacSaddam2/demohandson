namespace TruYumCaseStudyMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelCategoryData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Category Values('Main Course'),('Starters'),('Snack')");
        }
        
        public override void Down()
        {
        }
    }
}
