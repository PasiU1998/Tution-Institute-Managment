namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        TeacherPayment = c.Double(nullable: false),
                        NonAcadamicPayment = c.Double(nullable: false),
                        UtilityPayment = c.Double(nullable: false),
                        Others = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profits");
        }
    }
}
