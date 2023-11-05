using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long UserId);
    }
}
