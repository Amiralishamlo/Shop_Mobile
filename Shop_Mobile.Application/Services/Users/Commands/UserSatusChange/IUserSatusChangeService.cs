using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Users.Commands.UserSatusChange
{
    public interface IUserSatusChangeService
    {
        ResultDto Execute(long UserId);
    }
}
