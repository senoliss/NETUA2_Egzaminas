﻿namespace NETUA2_Egzaminas.API.DTOs
{
	public class UpdateUserInfoDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PersonalID { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
