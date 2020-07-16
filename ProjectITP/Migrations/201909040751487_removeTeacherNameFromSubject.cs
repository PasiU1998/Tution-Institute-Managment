namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTeacherNameFromSubject : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subjects", "teacher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "teacher", c => c.String(nullable: false));
        }
    }
}
