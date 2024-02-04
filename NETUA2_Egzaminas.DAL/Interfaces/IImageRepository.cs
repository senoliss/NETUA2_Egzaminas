using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.DAL.Interfaces
{
    public interface IImageRepository
    {
        int AddImage(ProfileImage image);
        ProfileImage GetImage(int id);
        void DeleteImage(int id);
    }
}
