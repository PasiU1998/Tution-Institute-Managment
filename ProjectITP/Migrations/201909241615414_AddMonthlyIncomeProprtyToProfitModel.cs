namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMonthlyIncomeProprtyToProfitModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profits", "MonthlyIncome", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profits", "MonthlyIncome");
        }
    }
}
