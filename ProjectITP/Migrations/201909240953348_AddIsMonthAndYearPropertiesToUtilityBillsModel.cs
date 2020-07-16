namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsMonthAndYearPropertiesToUtilityBillsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UtilityBills", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.UtilityBills", "Month", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UtilityBills", "Month");
            DropColumn("dbo.UtilityBills", "Year");
        }
    }
}
