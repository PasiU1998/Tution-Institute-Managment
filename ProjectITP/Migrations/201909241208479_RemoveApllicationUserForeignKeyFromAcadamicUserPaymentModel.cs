namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApllicationUserForeignKeyFromAcadamicUserPaymentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AcadamicUserPayments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AcadamicUserPayments", new[] { "ApplicationUserId" });
            DropColumn("dbo.AcadamicUserPayments", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AcadamicUserPayments", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.AcadamicUserPayments", "ApplicationUserId");
            AddForeignKey("dbo.AcadamicUserPayments", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
