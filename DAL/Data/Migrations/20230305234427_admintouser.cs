using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.Data.Migrations
{
    public partial class admintouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(" INSERT INTO [dbo].[AspNetUserRoles] (UserId,RoleId)  SELECT '612323bf-eb52-448c-bf6b-196a0a0b661f',Id FROM [dbo].[roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles]  WHERE UserId ='612323bf-eb52-448c-bf6b-196a0a0b661f'");
        }
    }
}
