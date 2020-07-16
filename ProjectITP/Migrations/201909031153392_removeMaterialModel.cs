namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMaterialModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Materials", "MaterialTypesId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Materials", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Materials", new[] { "SubjectId" });
            DropIndex("dbo.Materials", new[] { "MaterialTypesId" });
            DropTable("dbo.Materials");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        teacher = c.String(nullable: false),
                        quantity = c.Int(nullable: false),
                        materialURL = c.String(),
                        SubjectId = c.Int(nullable: false),
                        MaterialTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Materials", "MaterialTypesId");
            CreateIndex("dbo.Materials", "SubjectId");
            AddForeignKey("dbo.Materials", "SubjectId", "dbo.Subjects", "id", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "MaterialTypesId", "dbo.MaterialTypes", "id", cascadeDelete: true);
        }
    }
}
