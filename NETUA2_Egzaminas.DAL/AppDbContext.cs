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
		public AppDbContext(DbContextOptions options) : base(options)
		{
        }
	}
}
