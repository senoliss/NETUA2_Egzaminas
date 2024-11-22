using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "ItemInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    Stackable = table.Column<bool>(type: "bit", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Defense = table.Column<int>(type: "int", nullable: true),
                    Attack = table.Column<int>(type: "int", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstances", x => x.Id);
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
                name: "SkillInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<double>(type: "float", nullable: false),
                    XpCap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillInstances", x => x.Id);
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
                name: "CharEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelmetId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ShieldId = table.Column<int>(type: "int", nullable: true),
                    LegsId = table.Column<int>(type: "int", nullable: true),
                    GlovesId = table.Column<int>(type: "int", nullable: true),
                    BootsId = table.Column<int>(type: "int", nullable: true),
                    AmuletId = table.Column<int>(type: "int", nullable: true),
                    RingLeftId = table.Column<int>(type: "int", nullable: true),
                    RingRightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_AmuletId",
                        column: x => x.AmuletId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_BootsId",
                        column: x => x.BootsId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_GlovesId",
                        column: x => x.GlovesId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_HelmetId",
                        column: x => x.HelmetId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_LegsId",
                        column: x => x.LegsId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_RingLeftId",
                        column: x => x.RingLeftId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_RingRightId",
                        column: x => x.RingRightId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_ShieldId",
                        column: x => x.ShieldId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharEquipment_ItemInstances_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CharInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slot1Id = table.Column<int>(type: "int", nullable: true),
                    Slot2Id = table.Column<int>(type: "int", nullable: true),
                    Slot3Id = table.Column<int>(type: "int", nullable: true),
                    Slot4Id = table.Column<int>(type: "int", nullable: true),
                    Slot5Id = table.Column<int>(type: "int", nullable: true),
                    Slot6Id = table.Column<int>(type: "int", nullable: true),
                    Slot7Id = table.Column<int>(type: "int", nullable: true),
                    Slot8Id = table.Column<int>(type: "int", nullable: true),
                    Slot9Id = table.Column<int>(type: "int", nullable: true),
                    Slot10Id = table.Column<int>(type: "int", nullable: true),
                    Slot11Id = table.Column<int>(type: "int", nullable: true),
                    Slot12Id = table.Column<int>(type: "int", nullable: true),
                    Slot13Id = table.Column<int>(type: "int", nullable: true),
                    Slot14Id = table.Column<int>(type: "int", nullable: true),
                    Slot15Id = table.Column<int>(type: "int", nullable: true),
                    Slot16Id = table.Column<int>(type: "int", nullable: true),
                    Slot17Id = table.Column<int>(type: "int", nullable: true),
                    Slot18Id = table.Column<int>(type: "int", nullable: true),
                    Slot19Id = table.Column<int>(type: "int", nullable: true),
                    Slot20Id = table.Column<int>(type: "int", nullable: true),
                    Slot21Id = table.Column<int>(type: "int", nullable: true),
                    Slot22Id = table.Column<int>(type: "int", nullable: true),
                    Slot23Id = table.Column<int>(type: "int", nullable: true),
                    Slot24Id = table.Column<int>(type: "int", nullable: true),
                    Slot25Id = table.Column<int>(type: "int", nullable: true),
                    Slot26Id = table.Column<int>(type: "int", nullable: true),
                    Slot27Id = table.Column<int>(type: "int", nullable: true),
                    Slot28Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot10Id",
                        column: x => x.Slot10Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot11Id",
                        column: x => x.Slot11Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot12Id",
                        column: x => x.Slot12Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot13Id",
                        column: x => x.Slot13Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot14Id",
                        column: x => x.Slot14Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot15Id",
                        column: x => x.Slot15Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot16Id",
                        column: x => x.Slot16Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot17Id",
                        column: x => x.Slot17Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot18Id",
                        column: x => x.Slot18Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot19Id",
                        column: x => x.Slot19Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot1Id",
                        column: x => x.Slot1Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot20Id",
                        column: x => x.Slot20Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot21Id",
                        column: x => x.Slot21Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot22Id",
                        column: x => x.Slot22Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot23Id",
                        column: x => x.Slot23Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot24Id",
                        column: x => x.Slot24Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot25Id",
                        column: x => x.Slot25Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot26Id",
                        column: x => x.Slot26Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot27Id",
                        column: x => x.Slot27Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot28Id",
                        column: x => x.Slot28Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot2Id",
                        column: x => x.Slot2Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot3Id",
                        column: x => x.Slot3Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot4Id",
                        column: x => x.Slot4Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot5Id",
                        column: x => x.Slot5Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot6Id",
                        column: x => x.Slot6Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot7Id",
                        column: x => x.Slot7Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot8Id",
                        column: x => x.Slot8Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharInventory_ItemInstances_Slot9Id",
                        column: x => x.Slot9Id,
                        principalTable: "ItemInstances",
                        principalColumn: "Id");
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
                    Skill6Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstances_Skill1Id",
                        column: x => x.Skill1Id,
                        principalTable: "SkillInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstances_Skill2Id",
                        column: x => x.Skill2Id,
                        principalTable: "SkillInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstances_Skill3Id",
                        column: x => x.Skill3Id,
                        principalTable: "SkillInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstances_Skill4Id",
                        column: x => x.Skill4Id,
                        principalTable: "SkillInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstances_Skill5Id",
                        column: x => x.Skill5Id,
                        principalTable: "SkillInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharSkills_SkillInstances_Skill6Id",
                        column: x => x.Skill6Id,
                        principalTable: "SkillInstances",
                        principalColumn: "Id");
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
                    SkillsId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Characters_CharSkills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "CharSkills",
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
                name: "IX_Characters_SkillsId",
                table: "Characters",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StatsId",
                table: "Characters",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_AmuletId",
                table: "CharEquipment",
                column: "AmuletId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_ArmorId",
                table: "CharEquipment",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_BootsId",
                table: "CharEquipment",
                column: "BootsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_GlovesId",
                table: "CharEquipment",
                column: "GlovesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_HelmetId",
                table: "CharEquipment",
                column: "HelmetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_LegsId",
                table: "CharEquipment",
                column: "LegsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_RingLeftId",
                table: "CharEquipment",
                column: "RingLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_RingRightId",
                table: "CharEquipment",
                column: "RingRightId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_ShieldId",
                table: "CharEquipment",
                column: "ShieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CharEquipment_WeaponId",
                table: "CharEquipment",
                column: "WeaponId");

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
                name: "IX_CharInventory_Slot1Id",
                table: "CharInventory",
                column: "Slot1Id");

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
                name: "IX_CharInventory_Slot2Id",
                table: "CharInventory",
                column: "Slot2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CharInventory_Slot3Id",
                table: "CharInventory",
                column: "Slot3Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_CharQuests_CharId",
                table: "CharQuests",
                column: "CharId");

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
                name: "Items");

            migrationBuilder.DropTable(
                name: "UsersInfo");

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
                name: "CharSkills");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "ItemInstances");

            migrationBuilder.DropTable(
                name: "SkillInstances");
        }
    }
}
