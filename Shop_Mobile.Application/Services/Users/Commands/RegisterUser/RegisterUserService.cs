using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Common.Dto;
using Shop_Mobile.Domain.Entites.Users;

namespace Shop_Mobile.Application.Services.Users.Commands.RegisterUser
{
    public class RgegisterUserService : IRgegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RgegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRgegisterUserDto> Execute(RequestRgegisterUserDto request)
        {
            User user = new User()
            {
                Email = request.Email,
                FullName = request.FullName,

            };
            List<UserInRole> userInRoles = new List<UserInRole>();

            foreach (var item in request.roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole
                {
                    Role = roles,
                    RoleId = roles.Id,
                    User = user,
                    UserId = user.Id,
                });
            }
            user.UserInRoles = userInRoles;

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto<ResultRgegisterUserDto>()
            {
                Data = new ResultRgegisterUserDto()
                {
                    UserId = user.Id,

                },
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد",
            };
        }
    }
}