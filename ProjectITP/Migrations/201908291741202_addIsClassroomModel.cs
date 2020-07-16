namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsClassroomModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        className = c.String(),
                        building = c.String(),
                        floor = c.String(),
                        capasity = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classrooms");
        }
    }
}
