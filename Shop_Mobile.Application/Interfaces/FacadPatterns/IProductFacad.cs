using Shop_Mobile.Application.Services.Products.Commands.AddNewCategory;
using Shop_Mobile.Application.Services.Products.Commands.AddNewProduct;
using Shop_Mobile.Application.Services.Products.Queries.GetAllCategories;
using Shop_Mobile.Application.Services.Products.Queries.GetCategories;

namespace Shop_Mobile.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }

        IGetCategoriesService GetCategoriesService { get; }

        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
    }
}
