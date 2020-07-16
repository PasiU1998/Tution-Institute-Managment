namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserTypesId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserTypes_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserTypes_id");
            AddForeignKey("dbo.AspNetUsers", "UserTypes_id", "dbo.UserTypes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserTypes_id", "dbo.UserTypes");
            DropIndex("dbo.AspNetUsers", new[] { "UserTypes_id" });
            DropColumn("dbo.AspNetUsers", "UserTypes_id");
            DropColumn("dbo.AspNetUsers", "UserTypesId");
        }
    }
}
