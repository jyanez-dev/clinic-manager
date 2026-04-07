namespace ClinicManager.DTOs.Users
{
	public class UserDto
	{
		public int UserId { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
	}
}