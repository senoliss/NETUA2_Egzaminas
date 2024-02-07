using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IUserInfoMapper
    {
        UserInfo Map(PostUserInfoDTO userInfoToPost);
        UserInfo Map(UpdatetUserInfoDTO userInfoToUpdate);
    }
}
