using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureInventorySlots2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_Characters_CharId",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_CharId",
                table: "CharInventory");

            migrationBuilder.AddColumn<int>(
                name: "CharacterCharId",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Weapon",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Shield",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RingRight",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RingLeft",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Legs",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Helmet",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Gloves",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Boots",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Armor",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Amulet",
                table: "CharEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_CharacterCharId",
                table: "CharInventory",
                column: "CharacterCharId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_Characters_CharacterCharId",
                table: "CharInventory",
                column: "CharacterCharId",
                principalTable: "Characters",
                principalColumn: "CharId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_Characters_CharacterCharId",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_CharacterCharId",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "CharacterCharId",
                table: "CharInventory");

            migrationBuilder.AlterColumn<int>(
                name: "Weapon",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Shield",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RingRight",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RingLeft",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Legs",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Helmet",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gloves",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Boots",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Armor",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amulet",
                table: "CharEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_CharId",
                table: "CharInventory",
                column: "CharId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_Characters_CharId",
                table: "CharInventory",
                column: "CharId",
                principalTable: "Characters",
                principalColumn: "CharId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
