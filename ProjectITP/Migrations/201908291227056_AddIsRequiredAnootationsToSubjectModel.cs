namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRequiredAnootationsToSubjectModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Subjects", "teacher", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "teacher", c => c.String());
            AlterColumn("dbo.Subjects", "name", c => c.String());
        }
    }
}
