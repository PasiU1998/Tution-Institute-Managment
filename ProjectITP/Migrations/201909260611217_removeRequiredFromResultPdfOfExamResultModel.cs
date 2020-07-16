namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequiredFromResultPdfOfExamResultModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExamResults", "Resultpdf", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExamResults", "Resultpdf", c => c.String(nullable: false));
        }
    }
}
