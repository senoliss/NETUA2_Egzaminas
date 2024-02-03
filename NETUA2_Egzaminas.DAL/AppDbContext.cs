using Microsoft.EntityFrameworkCore;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
	}
}
