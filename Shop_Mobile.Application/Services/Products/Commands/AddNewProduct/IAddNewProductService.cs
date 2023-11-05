using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(RequestAddNewProductDto request);
    }
}
