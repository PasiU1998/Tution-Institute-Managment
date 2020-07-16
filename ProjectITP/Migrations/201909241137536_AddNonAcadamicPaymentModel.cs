namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNonAcadamicPaymentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NonAcadamicPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        NonAcadamicEmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NonAcadamicEmployees", t => t.NonAcadamicEmployeeId, cascadeDelete: true)
                .Index(t => t.NonAcadamicEmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NonAcadamicPayments", "NonAcadamicEmployeeId", "dbo.NonAcadamicEmployees");
            DropIndex("dbo.NonAcadamicPayments", new[] { "NonAcadamicEmployeeId" });
            DropTable("dbo.NonAcadamicPayments");
        }
    }
}
