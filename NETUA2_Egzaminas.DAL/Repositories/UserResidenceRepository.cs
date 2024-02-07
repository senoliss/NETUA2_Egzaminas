using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Repositories
{
    public class UserResidenceRepository : IUserResidenceRepository
	{
		private readonly AppDbContext _context;

		public UserResidenceRepository(AppDbContext context)
		{
			_context = context;
		}

		public void AddUserResidence(UserResidence userResidenceToPost)
		{
			_context.UsersResidences.Add(userResidenceToPost);
			_context.SaveChanges();
		}

		public UserResidence GetUserResidenceById(int id)
		{
			return _context.UsersResidences
				.Include(ur => ur.UserInfo)
				.SingleOrDefault(u => u.Id == id);
		}

		public void UpdateUserResidence(UserResidence userResidenceToUpdate)
		{
			var userInfo = GetUserResidenceById(userResidenceToUpdate.Id);
			if (userInfo == null)
			{
				throw new Exception("User Info not found");
			}
			_context.UsersResidences.Update(userResidenceToUpdate);
			_context.SaveChanges();
		}
		public void DeleteUserResidence(UserResidence userResidenceToDelete)
		{
			_context.UsersResidences.Remove(userResidenceToDelete);
			_context.SaveChanges();
		}
	}
}
