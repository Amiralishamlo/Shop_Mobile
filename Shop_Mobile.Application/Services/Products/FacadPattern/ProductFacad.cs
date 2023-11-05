using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Application.Interfaces.FacadPatterns;
using Shop_Mobile.Application.Services.Products.Commands.AddNewCategory;
using Shop_Mobile.Application.Services.Products.Queries.GetCategories;

namespace Shop_Mobile.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        public ProductFacad(IDataBaseContext context)
        {
            _context = context;
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
    }
}
