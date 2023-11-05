using Microsoft.AspNetCore.Hosting;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Application.Interfaces.FacadPatterns;
using Shop_Mobile.Application.Services.Products.Commands.AddNewCategory;
using Shop_Mobile.Application.Services.Products.Commands.AddNewProduct;
using Shop_Mobile.Application.Services.Products.Queries.GetAllCategories;
using Shop_Mobile.Application.Services.Products.Queries.GetCategories;

namespace Shop_Mobile.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context,IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }

        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get { 
                return _getCategoriesService=_getCategoriesService ?? new GetCategoriesService(_context); 
            }
        }
        private  AddNewProductService _addNewProduct;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProduct = _addNewProduct??new AddNewProductService(_context,_environment);
            }
        }
        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }
    }
}
