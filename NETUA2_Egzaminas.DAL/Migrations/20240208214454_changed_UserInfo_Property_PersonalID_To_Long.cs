using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changed_UserInfo_Property_PersonalID_To_Long : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PersonalID",
                table: "UsersInfo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PersonalID",
                table: "UsersInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
