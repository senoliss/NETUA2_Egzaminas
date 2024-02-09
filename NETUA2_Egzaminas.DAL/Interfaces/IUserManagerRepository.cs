using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL.Interfaces
{
    public interface IUserManagerRepository
    {
        User GetUser(string username);
        User GetUserById(int id);
        void SaveUser(User user);
        void DeleteUser(User user);
        bool CheckIfUserIsAdmin(User user);
    }
}
