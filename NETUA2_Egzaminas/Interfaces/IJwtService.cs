namespace NETUA2_Egzaminas.API.Interfaces
{
    public interface IJwtService
    {
        string GetJwtToken(int userId, string userName, string role);
    }
}
