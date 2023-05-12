using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.Data.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DNO], [Location], [WorkingHours], [profilePic]) VALUES (N'612323bf-eb52-448c-bf6b-196a0a0b661f', N'salmaabdelhakeem8@gmail.com', N'SALMAABDELHAKEEM8@GMAIL.COM', N'salmaabdelhakeem8@gmail.com', N'SALMAABDELHAKEEM8@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDtKP2Z5RT9qMXfb7K1yEMTABSKzXMXTNhwZH3tyWFM/hGQKJfINjV797x3QckTBRQ==', N'QEPVY2MWBRPZQOPYDKWOSLOXFTWMIPYT', N'ef052cdc-de22-497a-91b2-1c3f45ac878c', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, NULL)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM  [dbo].[AspNetUsers] WHERE Id='612323bf-eb52-448c-bf6b-196a0a0b661f' ");
        }
    }
}
