using Microsoft.EntityFrameworkCore;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL
{
    /// <summary>
    /// The main database context for the application, responsible for managing database sets (tables) 
    /// and configuring relationships between entities.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Represents the Users table in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Represents the UsersInfo table in the database, storing additional information about users.
        /// </summary>
        public DbSet<UserInfo> UsersInfo { get; set; }

        /// <summary>
        /// Represents the UsersResidences table, containing user residence information.
        /// </summary>
        public DbSet<UserResidence> UsersResidences { get; set; }

        /// <summary>
        /// Represents the ProfileImages table, storing user profile pictures.
        /// </summary>
        public DbSet<ProfileImage> ProfileImages { get; set; }

        /// <summary>
        /// Represents the Items table, storing a database of all items available in the game.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Represents the Characters table, storing the characters created by users.
        /// </summary>
        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// Represents the BaseStats table, containing the basic stats for characters or items.
        /// </summary>
        public DbSet<BaseStats> BaseStats { get; set; }

        /// <summary>
        /// Represents the Stats table, storing detailed character stats.
        /// </summary>
        public DbSet<Stats> Stats { get; set; }

        /// <summary>
        /// Represents the CharSkills table, storing the skills of the characters.
        /// </summary>
        public DbSet<CharSkills> CharSkills { get; set; }

        /// <summary>
        /// Represents the CharQuests table, storing the quests associated with a character.
        /// </summary>
        public DbSet<CharQuests> CharQuests { get; set; }

        /// <summary>
        /// Represents the CharAchievements table, storing achievements unlocked by characters.
        /// </summary>
        public DbSet<CharAchievement> CharAchievements { get; set; }

        /// <summary>
        /// Represents the CharEquipment table, storing the equipment characters are wearing.
        /// </summary>
        public DbSet<CharEquipment> CharEquipment { get; set; }

        /// <summary>
        /// Represents the CharInventory table, storing the inventory of characters. Each character can have multiple item instances in their inventory.
        /// </summary>
        public DbSet<CharInventory> CharInventory { get; set; }
        public DbSet<ItemInstance> ItemInstances { get; set; }
        public DbSet<SkillInstance> SkillInstances { get; set; }

        /// <summary>
        /// Constructor for the <see cref="AppDbContext"/> class. It takes <paramref name="options"/> to configure the context.
        /// </summary>
        /// <param name="options">Database context options used to configure the context, including the connection string.</param>
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Configures the relationships between entities and other database behaviors using the Fluent API.
        /// This method is called when the model for a derived context has been initialized.
        /// </summary>
        /// <param name="modelBuilder">An object used to configure entity relationships and behaviors.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region inventory
            // Configure relationships and disable cascade delete for Slot1 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot1)  // Each CharInventory has one Slot1 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot1Id);  // Foreign key in CharInventory for Slot1.
                //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot1 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot2 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot2)  // Each CharInventory has one Slot2 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot2Id);  // Foreign key in CharInventory for Slot2.
                                                 //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot2 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot3 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot3)  // Each CharInventory has one Slot3 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot3Id);  // Foreign key in CharInventory for Slot3.
                                                 //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot3 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot4 to Slot28 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot4)  // Each CharInventory has one Slot4 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot4Id);  // Foreign key in CharInventory for Slot4.

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot5)
                .WithMany()
                .HasForeignKey(c => c.Slot5Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot6)
                .WithMany()
                .HasForeignKey(c => c.Slot6Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot7)
                .WithMany()
                .HasForeignKey(c => c.Slot7Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot8)
                .WithMany()
                .HasForeignKey(c => c.Slot8Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot9)
                .WithMany()
                .HasForeignKey(c => c.Slot9Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot10)
                .WithMany()
                .HasForeignKey(c => c.Slot10Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot11)
                .WithMany()
                .HasForeignKey(c => c.Slot11Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot12)
                .WithMany()
                .HasForeignKey(c => c.Slot12Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot13)
                .WithMany()
                .HasForeignKey(c => c.Slot13Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot14)
                .WithMany()
                .HasForeignKey(c => c.Slot14Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot15)
                .WithMany()
                .HasForeignKey(c => c.Slot15Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot16)
                .WithMany()
                .HasForeignKey(c => c.Slot16Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot17)
                .WithMany()
                .HasForeignKey(c => c.Slot17Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot18)
                .WithMany()
                .HasForeignKey(c => c.Slot18Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot19)
                .WithMany()
                .HasForeignKey(c => c.Slot19Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot20)
                .WithMany()
                .HasForeignKey(c => c.Slot20Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot21)
                .WithMany()
                .HasForeignKey(c => c.Slot21Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot22)
                .WithMany()
                .HasForeignKey(c => c.Slot22Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot23)
                .WithMany()
                .HasForeignKey(c => c.Slot23Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot24)
                .WithMany()
                .HasForeignKey(c => c.Slot24Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot25)
                .WithMany()
                .HasForeignKey(c => c.Slot25Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot26)
                .WithMany()
                .HasForeignKey(c => c.Slot26Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot27)
                .WithMany()
                .HasForeignKey(c => c.Slot27Id);

            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot28)
                .WithMany()
                .HasForeignKey(c => c.Slot28Id);

            #endregion

            #region equipment

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Helmet)
                .WithMany()
                .HasForeignKey(c => c.HelmetId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Armor)
                .WithMany()
                .HasForeignKey(c => c.ArmorId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Weapon)
                .WithMany()
                .HasForeignKey(c => c.WeaponId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Shield)
                .WithMany()
                .HasForeignKey(c => c.ShieldId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Legs)
                .WithMany()
                .HasForeignKey(c => c.LegsId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Gloves)
                .WithMany()
                .HasForeignKey(c => c.GlovesId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Boots)
                .WithMany()
                .HasForeignKey(c => c.BootsId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.Amulet)
                .WithMany()
                .HasForeignKey(c => c.AmuletId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.RingLeft)
                .WithMany()
                .HasForeignKey(c => c.RingLeftId);

            modelBuilder.Entity<CharEquipment>()
                .HasOne(c => c.RingRight)
                .WithMany()
                .HasForeignKey(c => c.RingRightId);
            #endregion

            #region skills
            // Configure relationships and disable cascade delete for Slot1 in the CharInventory entity.
            modelBuilder.Entity<CharSkills>()
                .HasOne(c => c.Woodcutting)  // Each CharInventory has one Slot1 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Skill1Id);  // Foreign key in CharInventory for Slot1.
                                                  //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot1 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot2 in the CharInventory entity.
            modelBuilder.Entity<CharSkills>()
                .HasOne(c => c.Mining)  // Each CharInventory has one Slot2 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Skill2Id);  // Foreign key in CharInventory for Slot2.
                                                  //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot2 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot3 in the CharInventory entity.
            modelBuilder.Entity<CharSkills>()
                .HasOne(c => c.Fishing)  // Each CharInventory has one Slot3 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Skill3Id);  // Foreign key in CharInventory for Slot3.
                                                  //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot3 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot1 in the CharInventory entity.
            modelBuilder.Entity<CharSkills>()
                .HasOne(c => c.Cooking)  // Each CharInventory has one Slot1 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Skill4Id);  // Foreign key in CharInventory for Slot1.
                                                  //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot1 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot2 in the CharInventory entity.
            modelBuilder.Entity<CharSkills>()
                .HasOne(c => c.Crafting)  // Each CharInventory has one Slot2 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Skill5Id);  // Foreign key in CharInventory for Slot2.
                                                  //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot2 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot3 in the CharInventory entity.
            modelBuilder.Entity<CharSkills>()
                .HasOne(c => c.Smithing)  // Each CharInventory has one Slot3 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Skill6Id);  // Foreign key in CharInventory for Slot3.
                                                  //.OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot3 ItemInstance to prevent cascade delete.
            #endregion

            // One-to-Many: Character to CharAchievements
            modelBuilder.Entity<CharAchievement>()
                .HasOne(ca => ca.Character)  // Each CharAchievement has one Character
                .WithMany(c => c.AchievementsList)  // Each Character has many CharAchievements
                .HasForeignKey(ca => ca.CharId)  // CharId is the FK in CharAchievement
                .OnDelete(DeleteBehavior.Cascade);  // Optional: configure cascade delete if desired

            modelBuilder.Entity<CharQuests>()
                .HasOne(cq => cq.Character)
                .WithMany(c => c.Quests)
                .HasForeignKey(cq => cq.CharId)
                .OnDelete(DeleteBehavior.Cascade);


			// Call the base method to ensure other configurations are applied.
			base.OnModelCreating(modelBuilder);
        }
    }
}
