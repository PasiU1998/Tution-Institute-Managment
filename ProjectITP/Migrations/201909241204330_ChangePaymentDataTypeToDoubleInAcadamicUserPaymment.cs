namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePaymentDataTypeToDoubleInAcadamicUserPaymment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AcadamicUserPayments", "Payment", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AcadamicUserPayments", "Payment", c => c.Single(nullable: false));
        }
    }
}
