using Microsoft.EntityFrameworkCore;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<UserInfo> UsersInfo { get; set; }
		public DbSet<UserResidence> UsersResidences { get; set; }
		public DbSet<ProfileImage> ProfileImages { get; set; }
		public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<BaseStats> BaseStats { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<CharSkills> CharSkills { get; set; }
        public DbSet<CharQuests> CharQuests { get; set; }
        public DbSet<CharAcheivements> CharAcheivements { get; set; }
        public DbSet<CharEquipment> CharEquipment { get; set; }
        public DbSet<CharInventory> CharInventory { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
		{
        }
	}
}
