using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
