using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Entities;
using NETUA2_Egzaminas.DAL.Interfaces;

namespace NETUA2_Egzaminas.API.Services
{
    public class ImageRepository : IImageRepository
	{
		private readonly AppDbContext _context;

		public ImageRepository(AppDbContext context)
		{
			_context = context;
		}

		public int AddImage(ProfileImage image)
		{
			_context.ProfileImages.Add(image);
			_context.SaveChanges();
			return image.Id;
		}

		public ProfileImage GetImage(int id)
		{
			return _context.ProfileImages.Find(id);
		}
		public void DeleteImage(int id)
		{
			var imageToDelete = _context.ProfileImages.Find(id);
			if(imageToDelete != null)
			{
				_context.ProfileImages.Remove(imageToDelete);
				_context.SaveChanges();
			}
		}

	}
}
