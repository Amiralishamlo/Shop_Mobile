using Microsoft.EntityFrameworkCore;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Common;
using Shop_Mobile.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Mobile.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        ResultDto<ResultProductForSiteDto> Execute(int Page);
    }


    public class GetProductForSiteService : IGetProductForSiteService
    {

        private readonly IDataBaseContext _context;
        public GetProductForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultProductForSiteDto> Execute(int Page)
        {
            int totalRow = 0;
            var poducts = _context.Products
                .Include(p => p.ProductImages)
                .ToPaged(Page, 5, out totalRow);

            Random rd = new Random();
            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = poducts.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Price = p.Price
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }
    }

    public class ResultProductForSiteDto
    {

        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }

    public class ProductForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public int Star { get; set; }
        public int Price { get; set; }
    }
}
