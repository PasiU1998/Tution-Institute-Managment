namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSubjectFeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectFees", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubjectFees", "SubjectId");
            AddForeignKey("dbo.SubjectFees", "SubjectId", "dbo.Subjects", "id", cascadeDelete: true);
            DropColumn("dbo.SubjectFees", "grade");
            DropColumn("dbo.SubjectFees", "subject");
            DropColumn("dbo.SubjectFees", "TeacherName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectFees", "TeacherName", c => c.String(nullable: false));
            AddColumn("dbo.SubjectFees", "subject", c => c.String(nullable: false));
            AddColumn("dbo.SubjectFees", "grade", c => c.Int(nullable: false));
            DropForeignKey("dbo.SubjectFees", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.SubjectFees", new[] { "SubjectId" });
            DropColumn("dbo.SubjectFees", "SubjectId");
        }
    }
}
