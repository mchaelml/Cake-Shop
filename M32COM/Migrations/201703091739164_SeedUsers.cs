namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5c4871b2-c4d6-4dc9-80a8-64b6e4503f21', N'admin@admin.com', 0, N'AAKH7vJg7VJez80KkqPapDirLjVAwuCxTRPZgWEtFPbLzbj4zys8F5YbkpXrAKvpbg==', N'154eb487-2d8e-47fb-a023-2965016bbfab', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'75a87445-5281-4d90-bed3-a8699a228d6d', N'guest@guest.com', 0, N'ALPIQpGqmx9SfliZtaoJE/QWbLRiJwIBcJrnSGE7JSQCk0UhlwsO2kp0W/uCICTE7g==', N'5ec44b10-7ec9-45d5-b863-489a37ed7f06', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'65893ff3-bbc4-4d7a-aef1-a057866501e7', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5c4871b2-c4d6-4dc9-80a8-64b6e4503f21', N'65893ff3-bbc4-4d7a-aef1-a057866501e7')

");
        }
        
        public override void Down()
        {
        }
    }
}
