using Microsoft.AspNetCore.Mvc;
using Shop_Mobile.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {

        private readonly IProductFacad _productFacad;

        public CategoriesController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }


        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }

        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
    }
}
