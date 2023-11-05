using Shop_Mobile.Application.Services.Products.Commands.AddNewCategory;
using Shop_Mobile.Application.Services.Products.Queries.GetCategories;

namespace Shop_Mobile.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }

        IGetCategoriesService GetCategoriesService { get; }
    }
}
