namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserTypesFromIdintityModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserTypesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserTypesId", c => c.Byte(nullable: false));
        }
    }
}
