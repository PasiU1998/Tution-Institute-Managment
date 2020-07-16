namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAllSetToPushToBackUpSajeewa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjectEnrollments", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.StudentSubjectEnrollments", new[] { "SubjectId" });
            DropTable("dbo.StudentSubjectEnrollments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentSubjectEnrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.StudentSubjectEnrollments", "SubjectId");
            AddForeignKey("dbo.StudentSubjectEnrollments", "SubjectId", "dbo.Subjects", "id");
        }
    }
}
