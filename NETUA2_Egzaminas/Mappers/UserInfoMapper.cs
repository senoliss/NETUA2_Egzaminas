using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Mappers
{
	public interface IUserInfoMapper
	{
		UserInfo Map(PostUserInfoDTO userInfoToPost);
		UserInfo Map(UpdatetUserInfoDTO userInfoToUpdate);
	}
	public class UserInfoMapper : IUserInfoMapper
	{
		public UserInfo Map(PostUserInfoDTO userInfoToPost)
		{
			var entity = new UserInfo
			{
				Id = userInfoToPost.Id,
				Name = userInfoToPost.Name,
				Surname = userInfoToPost.Surname,
				PersonalID = userInfoToPost.PersonalID,
				PhoneNumber = userInfoToPost.PhoneNumber,
				Email = userInfoToPost.Email
			};
			return entity;
		}

		public UserInfo Map(UpdatetUserInfoDTO userInfoToUpdate)
		{
			var entity = new UserInfo
			{
				Id = userInfoToUpdate.Id,
				Name = userInfoToUpdate.Name,
				Surname = userInfoToUpdate.Surname,
				PersonalID = userInfoToUpdate.PersonalID,
				PhoneNumber = userInfoToUpdate.PhoneNumber,
				Email = userInfoToUpdate.Email
			};
			return entity;
		}
		public GetUserInfoDTO(UserInfo model)
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
