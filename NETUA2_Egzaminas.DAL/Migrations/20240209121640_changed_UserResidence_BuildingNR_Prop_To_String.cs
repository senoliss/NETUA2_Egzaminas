using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changed_UserResidence_BuildingNR_Prop_To_String : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BuildingNumber",
                table: "UsersResidences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BuildingNumber",
                table: "UsersResidences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
