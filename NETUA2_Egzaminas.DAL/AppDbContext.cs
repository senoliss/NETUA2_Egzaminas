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
            // Configure relationships and disable cascade delete for Slot1 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot1)  // Each CharInventory has one Slot1 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot1Id)  // Foreign key in CharInventory for Slot1.
                .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot1 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot2 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot2)  // Each CharInventory has one Slot2 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot2Id)  // Foreign key in CharInventory for Slot2.
                .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot2 ItemInstance to prevent cascade delete.

            // Configure relationships and disable cascade delete for Slot3 in the CharInventory entity.
            modelBuilder.Entity<CharInventory>()
                .HasOne(c => c.Slot3)  // Each CharInventory has one Slot3 item.
                .WithMany()            // No back-reference from ItemInstance to CharInventory.
                .HasForeignKey(c => c.Slot3Id)  // Foreign key in CharInventory for Slot3.
                .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion of Slot3 ItemInstance to prevent cascade delete.

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

            modelBuilder.Entity<CharSkills>()
                .HasOne(cs => cs.Character)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CharId)
                .OnDelete(DeleteBehavior.Cascade);

            // Call the base method to ensure other configurations are applied.
            base.OnModelCreating(modelBuilder);
        }
    }
}
