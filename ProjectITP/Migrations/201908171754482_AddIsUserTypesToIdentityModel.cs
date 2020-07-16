namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsUserTypesToIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsStudent", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsTeacher", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsTeacher");
            DropColumn("dbo.AspNetUsers", "IsStudent");
        }
    }
}
