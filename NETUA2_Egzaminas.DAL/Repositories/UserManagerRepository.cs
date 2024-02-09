using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Repositories
{
    public class UserManagerRepository : IUserManagerRepository
	{
		private readonly AppDbContext _context;

		public UserManagerRepository(AppDbContext context)
		{
			_context = context;
		}
		public User GetUser(string username)
		{
			return _context.Users.SingleOrDefault(u => u.UserName == username);
		}

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == id);
        }
		public bool CheckIfUserIsAdmin(User user)
		{
			return user != null && user.Role == "Admin";	// Checks if user is not empty and if it his role as Administrator
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
