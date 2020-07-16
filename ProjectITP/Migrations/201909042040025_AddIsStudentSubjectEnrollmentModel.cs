namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsStudentSubjectEnrollmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubjectEnrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        ApplicationUserId = c.Int(nullable: false),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjectEnrollments", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjectEnrollments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.StudentSubjectEnrollments", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubjectEnrollments", new[] { "ApplicationUserId" });
            DropTable("dbo.StudentSubjectEnrollments");
        }
    }
}
