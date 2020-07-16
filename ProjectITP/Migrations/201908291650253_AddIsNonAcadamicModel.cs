namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsNonAcadamicModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NonAcadamicEmployees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        address = c.String(),
                        ProfileImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NonAcadamicEmployees");
        }
    }
}
