namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubjectTypeAndApplicationUserModelToSubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "SubjectCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "SubjectCategoryId");
            CreateIndex("dbo.Subjects", "ApplicationUserId");
            AddForeignKey("dbo.Subjects", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Subjects", "SubjectCategoryId", "dbo.SubjectCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "SubjectCategoryId", "dbo.SubjectCategories");
            DropForeignKey("dbo.Subjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Subjects", new[] { "ApplicationUserId" });
            DropIndex("dbo.Subjects", new[] { "SubjectCategoryId" });
            DropColumn("dbo.Subjects", "ApplicationUserId");
            DropColumn("dbo.Subjects", "SubjectCategoryId");
        }
    }
}
