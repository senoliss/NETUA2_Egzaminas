namespace NETUA2_Egzaminas.API.DTOs
{
	public class UpdateUserInfoDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public long PersonalID { get; set; }
		public int PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
