namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateExamResultModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Resultpdf = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ExamResults", new[] { "SubjectId" });
            DropTable("dbo.ExamResults");
        }
    }
}
