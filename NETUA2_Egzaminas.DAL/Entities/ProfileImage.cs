using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUA2_Egzaminas.DAL.Entities
{
	public class ProfileImage
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Size { get; set; }
		public byte[] ImageBytes { get; set; }
	}
}
