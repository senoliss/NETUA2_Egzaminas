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
    public class UserInfoRepository : IUserInfoRepository
	{
		private readonly AppDbContext _context;

		public UserInfoRepository(AppDbContext context)
		{
			_context = context;
		}

		public void AddUserInfo(UserInfo userInfoToPost)
		{
			_context.UsersInfo.Add(userInfoToPost);
			_context.SaveChanges();
		}

		public UserInfo GetUserInfoById(int id)
		{
			return _context.UsersInfo
			.Include(u => u.Image)
			.Include(u => u.Residence)
			.SingleOrDefault(u => u.UserId == id);

			//return _context.UsersInfo.SingleOrDefault(u => u.Id == id); ;
		}

		public void UpdateUserInfo(UserInfo userInfoToUpdate)
		{
			//_context.UsersInfo.Update(userInfoToUpdate);

			// No more attaching the info of the UserInfo entity since then EF thinks that this is new entity and tries to create it. We're working with already created entity.
			// Ensuring that the entity is atatched to context and being tracked by Entity Framework and should consider it as update.
			//_context.UsersInfo.Attach(userInfoToUpdate);

			// Marking the entity as modified
			_context.Entry(userInfoToUpdate).State = EntityState.Modified;

			_context.SaveChanges();
		}
		public void DeleteUserInfo(UserInfo userInfoToDelete)
		{
			_context.UsersInfo.Remove(userInfoToDelete);
			_context.SaveChanges();
		}
	}
}
