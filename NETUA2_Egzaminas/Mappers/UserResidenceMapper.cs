using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Mappers
{
    public class UserResidenceMapper : IUserResidenceMapper
    {
        public UserResidence Map(PostUserResidenceDTO userResidenceToPost)
        {
            return new UserResidence
            {
                Town = userResidenceToPost.Town,
                Street = userResidenceToPost.Street,
                BuildingNumber = userResidenceToPost.BuildingNumber,
                FlatNumber = userResidenceToPost.FlatNumber
            };
        }

        public UserResidence Map(UpdateUserResidenceDTO userResidenceToUpdate, UserResidence existingUserResidence)
        {
            existingUserResidence.Town = userResidenceToUpdate.Town;
            existingUserResidence.Street = userResidenceToUpdate.Street;
            existingUserResidence.BuildingNumber = userResidenceToUpdate.BuildingNumber;
            existingUserResidence.FlatNumber = userResidenceToUpdate.FlatNumber;

            return existingUserResidence;
        }
    }
}
