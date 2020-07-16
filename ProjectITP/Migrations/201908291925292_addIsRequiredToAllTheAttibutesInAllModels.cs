namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsRequiredToAllTheAttibutesInAllModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classrooms", "className", c => c.String(nullable: false));
            AlterColumn("dbo.Classrooms", "building", c => c.String(nullable: false));
            AlterColumn("dbo.Classrooms", "floor", c => c.String(nullable: false));
            AlterColumn("dbo.Classrooms", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Time", c => c.String(nullable: false));
            AlterColumn("dbo.Materials", "teacher", c => c.String(nullable: false));
            AlterColumn("dbo.NonAcadamicEmployees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.NonAcadamicEmployees", "email", c => c.String(nullable: false));
            AlterColumn("dbo.NonAcadamicEmployees", "address", c => c.String(nullable: false));
            AlterColumn("dbo.SubjectFees", "subject", c => c.String(nullable: false));
            AlterColumn("dbo.SubjectFees", "TeacherName", c => c.String(nullable: false));
            AlterColumn("dbo.TimeTables", "Year", c => c.String(nullable: false));
            AlterColumn("dbo.TimeTables", "TimeTableImage", c => c.String(nullable: false));
            AlterColumn("dbo.UtilityBills", "billType", c => c.String(nullable: false));
            AlterColumn("dbo.UtilityBills", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UtilityBills", "description", c => c.String());
            AlterColumn("dbo.UtilityBills", "billType", c => c.String());
            AlterColumn("dbo.TimeTables", "TimeTableImage", c => c.String());
            AlterColumn("dbo.TimeTables", "Year", c => c.String());
            AlterColumn("dbo.SubjectFees", "TeacherName", c => c.String());
            AlterColumn("dbo.SubjectFees", "subject", c => c.String());
            AlterColumn("dbo.NonAcadamicEmployees", "address", c => c.String());
            AlterColumn("dbo.NonAcadamicEmployees", "email", c => c.String());
            AlterColumn("dbo.NonAcadamicEmployees", "Name", c => c.String());
            AlterColumn("dbo.Materials", "teacher", c => c.String());
            AlterColumn("dbo.Exams", "Time", c => c.String());
            AlterColumn("dbo.Exams", "Date", c => c.String());
            AlterColumn("dbo.Exams", "Location", c => c.String());
            AlterColumn("dbo.Classrooms", "description", c => c.String());
            AlterColumn("dbo.Classrooms", "floor", c => c.String());
            AlterColumn("dbo.Classrooms", "building", c => c.String());
            AlterColumn("dbo.Classrooms", "className", c => c.String());
        }
    }
}
