namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29th1stcorrectionisdone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        ExamTypeId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ExamTypes", t => t.ExamTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.ExamTypeId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "ExamTypeId", "dbo.ExamTypes");
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "ExamTypeId" });
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Exams");
            CreateIndex("dbo.Students", "ApplicationUserId");
            AddForeignKey("dbo.Students", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
