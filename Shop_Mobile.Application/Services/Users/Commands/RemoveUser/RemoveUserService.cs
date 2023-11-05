using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Common.Dto;
using System.Net.Http.Headers;

namespace Shop_Mobile.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService:IRemoveUserService
    {
        private readonly IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long UserId)
        {
            var result=_context.Users.Find(UserId);
            if(result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            result.RemoveTime = DateTime.Now;
            result.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
