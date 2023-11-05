using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop_Mobile.Application.Services.Users.Commands.EditUser;
using Shop_Mobile.Application.Services.Users.Commands.RegisterUser;
using Shop_Mobile.Application.Services.Users.Commands.RemoveUser;
using Shop_Mobile.Application.Services.Users.Commands.UserSatusChange;
using Shop_Mobile.Application.Services.Users.Queries.GetRoles;
using Shop_Mobile.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService; 
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetUsersService getUsersService
            , IGetRolesService getRolesService
            , IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IUserSatusChangeService userSatusChangeService,
            IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService= userSatusChangeService;
            _editUserService= editUserService;
        }
        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Email,string Fullname,long RoleId,string Password,string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                FullName = Fullname,
                Email = Email,
                roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id = RoleId,
                    }
                },
                Password=Password,
                RePasword=RePassword
            });
            return  Json(result);
        }
        [HttpPost]
        public IActionResult Delete(long userId)
        {
            return Json(_removeUserService.Execute(userId));
        }
        [HttpPost]
        public IActionResult UserSatusChange(long userId)  
        {
            return Json(_userSatusChangeService.Execute(userId));
        }
        [HttpPost]
        public IActionResult Edit(long userId,string FullName)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = FullName,
                UserId = userId
            }));
        }
    }
}
