namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterialTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MaterialTypes");
        }
    }
}
