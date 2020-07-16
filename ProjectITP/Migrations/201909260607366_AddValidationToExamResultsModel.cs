namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToExamResultsModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExamResults", "Resultpdf", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExamResults", "Resultpdf", c => c.String());
        }
    }
}
