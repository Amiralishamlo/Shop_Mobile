using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEdituserDto request);
    }
}
