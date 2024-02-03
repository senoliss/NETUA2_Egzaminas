using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL.Interfaces
{
    public interface IUserManagerService
    {
        User GetUser(string username);
        void SaveUser(User user);
        void DeleteUser(User user);
    }
}
