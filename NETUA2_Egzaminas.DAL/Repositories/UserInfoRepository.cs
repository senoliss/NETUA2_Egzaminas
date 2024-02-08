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
            .SingleOrDefault(u => u.Id == id);
        }

		public void UpdateUserInfo(UserInfo userInfoToUpdate)
		{
			var userInfo = GetUserInfoById(userInfoToUpdate.Id);
			if (userInfo == null)
			{
				throw new Exception("User Info not found");
			}
			_context.UsersInfo.Update(userInfoToUpdate);
			_context.SaveChanges();
		}
		public void DeleteUserInfo(UserInfo userInfoToDelete)
		{
			_context.UsersInfo.Remove(userInfoToDelete);
			_context.SaveChanges();
		}
	}
}
