namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsUtilityBillsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UtilityBills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        billNumber = c.Int(nullable: false),
                        billType = c.String(),
                        Date = c.DateTime(nullable: false),
                        description = c.String(),
                        price = c.Double(nullable: false),
                        total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UtilityBills");
        }
    }
}
