using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class extended_inv_to_28_slots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Slot10Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot11Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot12Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot13Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot14Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot15Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot16Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot17Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot18Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot19Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot20Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot21Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot22Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot23Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot24Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot25Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot26Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot27Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot28Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot4Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot5Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot6Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot7Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot8Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Slot9Id",
                table: "CharInventory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot10Id",
                table: "CharInventory",
                column: "Slot10Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot11Id",
                table: "CharInventory",
                column: "Slot11Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot12Id",
                table: "CharInventory",
                column: "Slot12Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot13Id",
                table: "CharInventory",
                column: "Slot13Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot14Id",
                table: "CharInventory",
                column: "Slot14Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot15Id",
                table: "CharInventory",
                column: "Slot15Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot16Id",
                table: "CharInventory",
                column: "Slot16Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot17Id",
                table: "CharInventory",
                column: "Slot17Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot18Id",
                table: "CharInventory",
                column: "Slot18Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot19Id",
                table: "CharInventory",
                column: "Slot19Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot20Id",
                table: "CharInventory",
                column: "Slot20Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot21Id",
                table: "CharInventory",
                column: "Slot21Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot22Id",
                table: "CharInventory",
                column: "Slot22Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot23Id",
                table: "CharInventory",
                column: "Slot23Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot24Id",
                table: "CharInventory",
                column: "Slot24Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot25Id",
                table: "CharInventory",
                column: "Slot25Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot26Id",
                table: "CharInventory",
                column: "Slot26Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot27Id",
                table: "CharInventory",
                column: "Slot27Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot28Id",
                table: "CharInventory",
                column: "Slot28Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot4Id",
                table: "CharInventory",
                column: "Slot4Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot5Id",
                table: "CharInventory",
                column: "Slot5Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot6Id",
                table: "CharInventory",
                column: "Slot6Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot7Id",
                table: "CharInventory",
                column: "Slot7Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot8Id",
                table: "CharInventory",
                column: "Slot8Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot9Id",
                table: "CharInventory",
                column: "Slot9Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot10Id",
                table: "CharInventory",
                column: "Slot10Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot11Id",
                table: "CharInventory",
                column: "Slot11Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot12Id",
                table: "CharInventory",
                column: "Slot12Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot13Id",
                table: "CharInventory",
                column: "Slot13Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot14Id",
                table: "CharInventory",
                column: "Slot14Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot15Id",
                table: "CharInventory",
                column: "Slot15Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot16Id",
                table: "CharInventory",
                column: "Slot16Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot17Id",
                table: "CharInventory",
                column: "Slot17Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot18Id",
                table: "CharInventory",
                column: "Slot18Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot19Id",
                table: "CharInventory",
                column: "Slot19Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot20Id",
                table: "CharInventory",
                column: "Slot20Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot21Id",
                table: "CharInventory",
                column: "Slot21Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot22Id",
                table: "CharInventory",
                column: "Slot22Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot23Id",
                table: "CharInventory",
                column: "Slot23Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot24Id",
                table: "CharInventory",
                column: "Slot24Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot25Id",
                table: "CharInventory",
                column: "Slot25Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot26Id",
                table: "CharInventory",
                column: "Slot26Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot27Id",
                table: "CharInventory",
                column: "Slot27Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot28Id",
                table: "CharInventory",
                column: "Slot28Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot4Id",
                table: "CharInventory",
                column: "Slot4Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot5Id",
                table: "CharInventory",
                column: "Slot5Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot6Id",
                table: "CharInventory",
                column: "Slot6Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot7Id",
                table: "CharInventory",
                column: "Slot7Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot8Id",
                table: "CharInventory",
                column: "Slot8Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot9Id",
                table: "CharInventory",
                column: "Slot9Id",
                principalTable: "ItemInstances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot10Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot11Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot12Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot13Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot14Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot15Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot16Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot17Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot18Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot19Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot20Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot21Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot22Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot23Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot24Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot25Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot26Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot27Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot28Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot4Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot5Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot6Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot7Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot8Id",
                table: "CharInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_CharInventory_ItemInstances_Slot9Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot10Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot11Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot12Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot13Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot14Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot15Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot16Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot17Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot18Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot19Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot20Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot21Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot22Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot23Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot24Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot25Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot26Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot27Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot28Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot4Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot5Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot6Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot7Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot8Id",
                table: "CharInventory");

            migrationBuilder.DropIndex(
                name: "IX_CharInventory_Slot9Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot10Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot11Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot12Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot13Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot14Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot15Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot16Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot17Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot18Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot19Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot20Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot21Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot22Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot23Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot24Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot25Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot26Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot27Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot28Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot4Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot5Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot6Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot7Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot8Id",
                table: "CharInventory");

            migrationBuilder.DropColumn(
                name: "Slot9Id",
                table: "CharInventory");
        }
    }
}
