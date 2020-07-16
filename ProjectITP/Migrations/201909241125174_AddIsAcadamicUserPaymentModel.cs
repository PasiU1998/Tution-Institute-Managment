namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsAcadamicUserPaymentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcadamicUserPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Payment = c.Single(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcadamicUserPayments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AcadamicUserPayments", new[] { "ApplicationUserId" });
            DropTable("dbo.AcadamicUserPayments");
        }
    }
}
