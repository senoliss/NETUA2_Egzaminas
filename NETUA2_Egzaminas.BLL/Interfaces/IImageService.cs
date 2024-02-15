using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.BLL.Interfaces
{
    public interface IImageService
    {
        void AttemptAddImage(ProfileImage image, int id);
        void AddImage(ProfileImage image);
        byte[] CreateImageThumbnail(MemoryStream imageStream, int sizeX, int sizeY);
        ProfileImage GetImage(int id);
        void DeleteImage(int id);
    }
}
