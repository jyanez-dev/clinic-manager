namespace ClinicManager.DTOs.Users
{
    public class UpdateUserRolesDto
    {
        public List<int> RoleIds { get; set; } = new();
        public int EditUser { get; set; }
    }
}
