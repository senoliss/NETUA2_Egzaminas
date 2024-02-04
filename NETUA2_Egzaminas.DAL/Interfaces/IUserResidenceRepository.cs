using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL.Interfaces
{
    public interface IUserResidenceRepository
    {
        void AddUserResidence(UserResidence userResidenceToPost);
        UserResidence GetUserResidenceById(int id);
        void UpdateUserResidence(UserResidence userResidenceToUpdate);
        void DeleteUserResidence(UserResidence userResidenceToDelete);
    }
}
