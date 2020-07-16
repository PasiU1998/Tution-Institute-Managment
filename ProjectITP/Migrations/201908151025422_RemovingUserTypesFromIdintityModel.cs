namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingUserTypesFromIdintityModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserTypes_id", "dbo.UserTypes");
            DropIndex("dbo.AspNetUsers", new[] { "UserTypes_id" });
            DropColumn("dbo.AspNetUsers", "UserTypesId");
            DropColumn("dbo.AspNetUsers", "UserTypes_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserTypes_id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "UserTypesId", c => c.Byte(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserTypes_id");
            AddForeignKey("dbo.AspNetUsers", "UserTypes_id", "dbo.UserTypes", "id");
        }
    }
}
