namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsModifiedTimeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Year = c.String(),
                        TimeTableImage = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeTables");
        }
    }
}
