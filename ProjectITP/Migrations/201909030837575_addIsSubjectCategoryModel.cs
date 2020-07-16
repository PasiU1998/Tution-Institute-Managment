namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsSubjectCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubjectCategories");
        }
    }
}
