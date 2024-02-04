using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL.Interfaces
{
    public interface IUserInfoRepository
    {
        void AddUserInfo(UserInfo userInfoToPost);
        UserInfo GetUserInfoById(int id);
        void UpdateUserInfo(UserInfo userInfoToUpdate);
        void DeleteUserInfo(UserInfo userInfoToDelete);
    }
}
