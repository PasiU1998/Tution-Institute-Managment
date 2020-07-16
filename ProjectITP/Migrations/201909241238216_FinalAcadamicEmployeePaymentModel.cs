namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalAcadamicEmployeePaymentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AcadamicUserPayments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.AcadamicUserPayments", new[] { "ApplicationUserId" });
            AddColumn("dbo.AcadamicUserPayments", "TeacherName", c => c.String(nullable: false));
            AddColumn("dbo.AcadamicUserPayments", "IdNumber", c => c.Int(nullable: false));
            DropColumn("dbo.AcadamicUserPayments", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AcadamicUserPayments", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.AcadamicUserPayments", "IdNumber");
            DropColumn("dbo.AcadamicUserPayments", "TeacherName");
            CreateIndex("dbo.AcadamicUserPayments", "ApplicationUserId");
            AddForeignKey("dbo.AcadamicUserPayments", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
