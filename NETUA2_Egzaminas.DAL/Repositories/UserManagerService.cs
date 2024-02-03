using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Repositories
{
    public class UserManagerService : IUserManagerService
	{
		private readonly AppDbContext _context;

		public UserManagerService(AppDbContext context)
		{
			_context = context;
		}
		public User GetUser(string username)
		{
			return _context.Users.SingleOrDefault(u => u.UserName == username);
		}

		public void SaveUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
		public void DeleteUser(User user)
		{
			_context.Users.Remove(user);
			_context.SaveChanges();
		}
	}
}
