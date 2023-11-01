namespace Shop_Mobile.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRgegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public List<RolesInRgegisterUserDto> roles { get; set; }
    }
}
