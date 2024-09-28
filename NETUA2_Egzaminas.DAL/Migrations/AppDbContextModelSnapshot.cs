﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETUA2_Egzaminas.DAL;

#nullable disable

namespace NETUA2_Egzaminas.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.BaseStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Magic")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BaseStats");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharAchievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharId")
                        .HasColumnType("int");

                    b.Property<string>("DateOfCompletion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharId");

                    b.ToTable("CharAchievements");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amulet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Armor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Boots")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gloves")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Helmet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Legs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RingLeft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RingRight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shield")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weapon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CharEquipment");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Slot1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Slot2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Slot3Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Slot1Id");

                    b.HasIndex("Slot2Id");

                    b.HasIndex("Slot3Id");

                    b.ToTable("CharInventory");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharQuests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharId")
                        .HasColumnType("int");

                    b.Property<string>("DateOfCompletion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharId");

                    b.ToTable("CharQuests");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Xp")
                        .HasColumnType("float");

                    b.Property<int>("XpCap")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharId");

                    b.ToTable("CharSkills");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.Character", b =>
                {
                    b.Property<int>("CharId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharId"));

                    b.Property<int>("BaseStatsId")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatsId")
                        .HasColumnType("int");

                    b.HasKey("CharId");

                    b.HasIndex("BaseStatsId");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("StatsId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<int?>("Attack")
                        .HasColumnType("int");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Durability")
                        .HasColumnType("int");

                    b.Property<string>("ImgId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Stackable")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.ItemInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Attack")
                        .HasColumnType("int");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Durability")
                        .HasColumnType("int");

                    b.Property<string>("ImgId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Stackable")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ItemInstance");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.ProfileImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProfileImages");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Magic")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterCharId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResidenceId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterCharId");

                    b.HasIndex("ImageId");

                    b.HasIndex("ResidenceId")
                        .IsUnique()
                        .HasFilter("[ResidenceId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.UserResidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersResidences");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharAchievement", b =>
                {
                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.Character", "Character")
                        .WithMany("AchievementsList")
                        .HasForeignKey("CharId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharInventory", b =>
                {
                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.ItemInstance", "Slot1")
                        .WithMany()
                        .HasForeignKey("Slot1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.ItemInstance", "Slot2")
                        .WithMany()
                        .HasForeignKey("Slot2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.ItemInstance", "Slot3")
                        .WithMany()
                        .HasForeignKey("Slot3Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Slot1");

                    b.Navigation("Slot2");

                    b.Navigation("Slot3");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharQuests", b =>
                {
                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.Character", "Character")
                        .WithMany("Quests")
                        .HasForeignKey("CharId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.CharSkills", b =>
                {
                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.Character", b =>
                {
                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.BaseStats", "BaseStats")
                        .WithMany()
                        .HasForeignKey("BaseStatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.CharEquipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.CharInventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.Stats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseStats");

                    b.Navigation("Equipment");

                    b.Navigation("Inventory");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.UserInfo", b =>
                {
                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterCharId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.ProfileImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.UserResidence", "Residence")
                        .WithOne("UserInfo")
                        .HasForeignKey("NETUA2_Egzaminas.DAL.Entities.UserInfo", "ResidenceId");

                    b.HasOne("NETUA2_Egzaminas.DAL.Entities.User", null)
                        .WithOne("UserInfo")
                        .HasForeignKey("NETUA2_Egzaminas.DAL.Entities.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Image");

                    b.Navigation("Residence");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.Character", b =>
                {
                    b.Navigation("AchievementsList");

                    b.Navigation("Quests");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.User", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("NETUA2_Egzaminas.DAL.Entities.UserResidence", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
