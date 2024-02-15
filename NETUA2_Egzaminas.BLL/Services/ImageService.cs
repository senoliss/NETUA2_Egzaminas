using NETUA2_Egzaminas.BLL.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;
using System.Drawing;

namespace NETUA2_Egzaminas.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public void AttemptAddImage(ProfileImage image, int id)
        {
            var existingImage = GetImage(id);
            if (existingImage != null)
            {
                DeleteImage(id);
                AddImage(image);
            }
            else AddImage(image);
        }

        public void AddImage(ProfileImage image)
        {
            _imageRepository.AddImage(image);
        }

        public byte[] CreateImageThumbnail(MemoryStream imageStream, int sizeX, int sizeY)
        {
            var dtoImageBytes = imageStream.ToArray();
            using var copyDtoImageInStream = new MemoryStream(dtoImageBytes);
            using var originalImage = new Bitmap(copyDtoImageInStream);

            using var resizedImage = new Bitmap(sizeX, sizeY);

            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(originalImage, 0, 0, sizeX, sizeY);
            }

            using var resultStream = new MemoryStream();
            resizedImage.Save(resultStream, originalImage.RawFormat);
            return resultStream.ToArray();
        }

        public void DeleteImage(int id)
        {
            _imageRepository.DeleteImage(id);
        }

        public ProfileImage GetImage(int id)
        {
            return _imageRepository.GetImage(id);
        }

        
    }
}
