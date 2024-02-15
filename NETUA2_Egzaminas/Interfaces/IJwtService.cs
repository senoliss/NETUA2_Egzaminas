using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IJwtService
    {
        string GetJwtToken(User user);
    }
}
