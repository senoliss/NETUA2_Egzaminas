using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Mappers
{
    public class UserInfoMapper : IUserInfoMapper
	{
		public UserInfo Map(PostUserInfoDTO userInfoToPost)
		{
			var entity = new UserInfo
			{
				Name = userInfoToPost.Name,
				Surname = userInfoToPost.Surname,
				PersonalID = userInfoToPost.PersonalID,
				PhoneNumber = userInfoToPost.PhoneNumber,
				Email = userInfoToPost.Email
			};
			return entity;
		}

		public UserInfo Map(UpdateUserInfoDTO userInfoToUpdate, UserInfo existingUserInfo)
		{
            //var entity = new UserInfo
            //{
            //	Name = userInfoToUpdate.Name,
            //	Surname = userInfoToUpdate.Surname,
            //	PersonalID = userInfoToUpdate.PersonalID,
            //	PhoneNumber = userInfoToUpdate.PhoneNumber,
            //	Email = userInfoToUpdate.Email
            //};

            existingUserInfo.Name = userInfoToUpdate.Name;
            existingUserInfo.Surname = userInfoToUpdate.Surname;
            existingUserInfo.PersonalID = userInfoToUpdate.PersonalID;
            existingUserInfo.PhoneNumber = userInfoToUpdate.PhoneNumber;
            existingUserInfo.Email = userInfoToUpdate.Email;

            return existingUserInfo;
		}
		public GetUserInfoDTO Map(UserInfo model)
		{
			var entity = new GetUserInfoDTO
			{
				Id = model.Id,
				Name = model.Name,
				Surname = model.Surname,
				PersonalID = model.PersonalID,
				PhoneNumber = model.PhoneNumber,
				Email = model.Email
			};
			return entity;
		}
	}
}
