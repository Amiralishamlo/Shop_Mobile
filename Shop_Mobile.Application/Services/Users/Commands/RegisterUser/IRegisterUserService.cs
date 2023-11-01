using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Users.Commands.RegisterUser
{
    public interface IRgegisterUserService
    {
        ResultDto<ResultRgegisterUserDto> Execute(RequestRgegisterUserDto request);
    }

}
