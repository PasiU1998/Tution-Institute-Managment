namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTheExamClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "ExamTypeId", "dbo.ExamTypes");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Exams", new[] { "ExamTypeId" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropTable("dbo.Exams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        ExamTypeId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Exams", "SubjectId");
            CreateIndex("dbo.Exams", "ExamTypeId");
            AddForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects", "id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "ExamTypeId", "dbo.ExamTypes", "Id", cascadeDelete: true);
        }
    }
}
