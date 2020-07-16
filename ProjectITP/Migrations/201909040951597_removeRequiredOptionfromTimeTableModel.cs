namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequiredOptionfromTimeTableModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TimeTables", "TimeTableImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeTables", "TimeTableImage", c => c.String(nullable: false));
        }
    }
}
