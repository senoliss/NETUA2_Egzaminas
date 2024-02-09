using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_ProfileImages_ImageId",
                table: "UsersInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_UsersResidences_ResidenceId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_ResidenceId",
                table: "UsersInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ResidenceId",
                table: "UsersInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "UsersInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_ResidenceId",
                table: "UsersInfo",
                column: "ResidenceId",
                unique: true,
                filter: "[ResidenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserId",
                table: "UsersInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_ProfileImages_ImageId",
                table: "UsersInfo",
                column: "ImageId",
                principalTable: "ProfileImages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_UsersResidences_ResidenceId",
                table: "UsersInfo",
                column: "ResidenceId",
                principalTable: "UsersResidences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_Users_UserId",
                table: "UsersInfo",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_ProfileImages_ImageId",
                table: "UsersInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_UsersResidences_ResidenceId",
                table: "UsersInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_Users_UserId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_ResidenceId",
                table: "UsersInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserId",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ResidenceId",
                table: "UsersInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "UsersInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_ResidenceId",
                table: "UsersInfo",
                column: "ResidenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_ProfileImages_ImageId",
                table: "UsersInfo",
                column: "ImageId",
                principalTable: "ProfileImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_UsersResidences_ResidenceId",
                table: "UsersInfo",
                column: "ResidenceId",
                principalTable: "UsersResidences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
