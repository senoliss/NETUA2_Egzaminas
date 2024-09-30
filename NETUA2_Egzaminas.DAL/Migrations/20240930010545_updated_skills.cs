using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updated_skills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Magic = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Helmet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Armor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weapon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shield = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Legs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gloves = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Boots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amulet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RingLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RingRight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Stackable = table.Column<bool>(type: "bit", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Stackable = table.Column<bool>(type: "bit", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ImageBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<double>(type: "float", nullable: false),
                    XpCap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillInstance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Magic = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsersResidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersResidences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slot1Id = table.Column<int>(type: "int", nullable: true),
                    Slot2Id = table.Column<int>(type: "int", nullable: true),
                    Slot3Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstance_Slot1Id",
                        column: x => x.Slot1Id,
                        principalTable: "ItemInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstance_Slot2Id",
                        column: x => x.Slot2Id,
                        principalTable: "ItemInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstance_Slot3Id",
                        column: x => x.Slot3Id,
                        principalTable: "ItemInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    BaseStatsId = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharId);
                    table.ForeignKey(
                        name: "FK_Characters_BaseStats_BaseStatsId",
                        column: x => x.BaseStatsId,
                        principalTable: "BaseStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharEquipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "CharEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_CharInventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "CharInventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharAchievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCompletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharAchievements_Characters_CharId",
                        column: x => x.CharId,
                        principalTable: "Characters",
                        principalColumn: "CharId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharQuests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCompletion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharQuests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharQuests_Characters_CharId",
                        column: x => x.CharId,
                        principalTable: "Characters",
                        principalColumn: "CharId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill1Id = table.Column<int>(type: "int", nullable: true),
                    Skill2Id = table.Column<int>(type: "int", nullable: true),
                    Skill3Id = table.Column<int>(type: "int", nullable: true),
                    Skill4Id = table.Column<int>(type: "int", nullable: true),
                    Skill5Id = table.Column<int>(type: "int", nullable: true),
                    Skill6Id = table.Column<int>(type: "int", nullable: true),
                    CharacterCharId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSkills_Characters_CharacterCharId",
                        column: x => x.CharacterCharId,
                        principalTable: "Characters",
                        principalColumn: "CharId");
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstance_Skill1Id",
                        column: x => x.Skill1Id,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstance_Skill2Id",
                        column: x => x.Skill2Id,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstance_Skill3Id",
                        column: x => x.Skill3Id,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstance_Skill4Id",
                        column: x => x.Skill4Id,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstance_Skill5Id",
                        column: x => x.Skill5Id,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstance_Skill6Id",
                        column: x => x.Skill6Id,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ResidenceId = table.Column<int>(type: "int", nullable: true),
                    CharId = table.Column<int>(type: "int", nullable: true),
                    CharacterCharId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersInfo_Characters_CharacterCharId",
                        column: x => x.CharacterCharId,
                        principalTable: "Characters",
                        principalColumn: "CharId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInfo_ProfileImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ProfileImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersInfo_UsersResidences_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "UsersResidences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharAchievements_CharId",
                table: "CharAchievements",
                column: "CharId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BaseStatsId",
                table: "Characters",
                column: "BaseStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EquipmentId",
                table: "Characters",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InventoryId",
                table: "Characters",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StatsId",
                table: "Characters",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot1Id",
                table: "CharInventory",
                column: "Slot1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot2Id",
                table: "CharInventory",
                column: "Slot2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot3Id",
                table: "CharInventory",
                column: "Slot3Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharQuests_CharId",
                table: "CharQuests",
                column: "CharId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_CharacterCharId",
                table: "CharSkills",
                column: "CharacterCharId");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_Skill1Id",
                table: "CharSkills",
                column: "Skill1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_Skill2Id",
                table: "CharSkills",
                column: "Skill2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_Skill3Id",
                table: "CharSkills",
                column: "Skill3Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_Skill4Id",
                table: "CharSkills",
                column: "Skill4Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_Skill5Id",
                table: "CharSkills",
                column: "Skill5Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharSkills_Skill6Id",
                table: "CharSkills",
                column: "Skill6Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_CharacterCharId",
                table: "UsersInfo",
                column: "CharacterCharId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_ImageId",
                table: "UsersInfo",
                column: "ImageId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharAchievements");

            migrationBuilder.DropTable(
                name: "CharQuests");

            migrationBuilder.DropTable(
                name: "CharSkills");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "SkillInstance");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "ProfileImages");

            migrationBuilder.DropTable(
                name: "UsersResidences");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BaseStats");

            migrationBuilder.DropTable(
                name: "CharEquipment");

            migrationBuilder.DropTable(
                name: "CharInventory");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "ItemInstance");
        }
    }
}
