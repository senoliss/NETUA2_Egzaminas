using NETUA2_Egzaminas.API.DTOs;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.BLL.Interfaces;
using NETUA2_Egzaminas.DAL.Entities;

namespace NETUA2_Egzaminas.API.Mappers
{
    public class ImageMapper : IImageMapper
    {
        private readonly IImageService _imageService;

        public ImageMapper(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ProfileImage Map(PostImageDTO dto)
        {
            using var memoryStream = new MemoryStream();
            dto.Image.CopyTo(memoryStream);

            var imageBytes = _imageService.CreateImageThumbnail(memoryStream, 200, 200);

            var imageFile = new ProfileImage
            {
                ImageBytes = imageBytes,
                Description = dto.Image.ContentType,
                Name = dto.Image.FileName,
                Size = imageBytes.Length
            };
            return imageFile;
        }
    }
}
