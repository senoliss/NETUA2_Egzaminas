using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IUserService
    {
        User? CreateAccount(string userName, string password, string email);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool TryVerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        ResponseDTO TryLogin(User user, string password);
        //ResponseDTO Login(string username, string password, out string role);
        User GetUser(string userName);
        int GetCurrentUserId();
        User GetUserById(int id);
        List<User> GetAll();
        bool CheckIfUserIsAdmin(User user);
        void DeleteUser(User user);
        UserInfo GetUserInfoByUserId(int userId);
        ResponseDTO SaveUserInfoToDb(UserInfo userInfoToCreate);
    }
}
