using Microsoft.AspNetCore.Mvc;
using Shop_Mobile.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(int Page=1)
        {
            return View(_productFacad.GetProductForSiteService.Execute(Page).Data);
        }
    }
}
