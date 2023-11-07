using Microsoft.EntityFrameworkCore;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Common;
using Shop_Mobile.Common.Dto;

namespace Shop_Mobile.Application.Services.Products.Queries.GetProductForAdmin
{
    public interface IGetProductForAdminService
    {
        ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20);
    }

    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(p => p.Category)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(p => new ProductsFormAdminList_Dto
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Category = p.Category.Name,
                    Description = p.Description,
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    Products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }

    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ProductsFormAdminList_Dto> Products { get; set; }
    }

    public class ProductsFormAdminList_Dto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
    }
}
