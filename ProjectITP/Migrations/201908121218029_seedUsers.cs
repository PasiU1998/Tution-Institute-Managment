namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2a928527-68cd-48f8-8419-7a1b6cc3f7cf', N'CanManageAll')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'98112b7a-2cd7-4d73-9a52-913ce9280039', N'sd@gmail.com', 0, N'ALRDekd1f3rlXdQCsaYrWi2E4A+hQtNpiUV6ZWES1J0JdYO/hq0669hHRPh5h6/Qbw==', N'db22f343-5643-406c-8601-e5884b0e26e2', NULL, 0, 0, NULL, 1, 0, N'sd@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd026d254-98a6-485f-949d-e0c835a9d2f0', N'admin1@gmail.com', 0, N'AHrE6a3wNevKdNumyD8/w5isJDgZoniRt9Xgx+9l2XmdyWLXDnETtmaveMbScl6JJw==', N'1f930faa-6a07-45f2-9085-e802f66218f0', NULL, 0, 0, NULL, 1, 0, N'admin1@gmail.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd026d254-98a6-485f-949d-e0c835a9d2f0', N'2a928527-68cd-48f8-8419-7a1b6cc3f7cf')



");


        }
        
        public override void Down()
        {
        }
    }
}
