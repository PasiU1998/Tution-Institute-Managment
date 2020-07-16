namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRemoveApplicationUserFromStudentSubjectEnrollmentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjectEnrollments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.StudentSubjectEnrollments", new[] { "ApplicationUserId" });
            DropColumn("dbo.StudentSubjectEnrollments", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentSubjectEnrollments", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentSubjectEnrollments", "ApplicationUserId");
            AddForeignKey("dbo.StudentSubjectEnrollments", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
