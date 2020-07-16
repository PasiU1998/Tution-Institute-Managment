namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentAttributeToNonAcadamicPaymentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NonAcadamicPayments", "Payment", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NonAcadamicPayments", "Payment");
        }
    }
}
