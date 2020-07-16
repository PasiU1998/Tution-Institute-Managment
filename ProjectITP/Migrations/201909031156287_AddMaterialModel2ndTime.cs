namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaterialModel2ndTime : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypesId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.MaterialTypesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Materials", "MaterialTypesId", "dbo.MaterialTypes");
            DropIndex("dbo.Materials", new[] { "MaterialTypesId" });
            DropIndex("dbo.Materials", new[] { "SubjectId" });
            DropTable("dbo.Materials");
        }
    }
}
