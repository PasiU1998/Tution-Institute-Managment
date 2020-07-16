namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRegularExperssionForEnrolmentKeyInSubject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "name", c => c.String(nullable: false));
        }
    }
}
