using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IUserResidenceMapper
    {
        UserResidence Map(PostUserResidenceDTO userResidenceToPost);
        UserResidence Map(UpdateUserResidenceDTO userResidenceToUpdate, UserResidence existingUserResidence);
    }
}
