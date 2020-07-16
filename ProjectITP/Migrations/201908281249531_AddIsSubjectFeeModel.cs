namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubjectFeeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectFees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        grade = c.Int(nullable: false),
                        subject = c.String(),
                        TeacherName = c.String(),
                        fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubjectFees");
        }
    }
}
