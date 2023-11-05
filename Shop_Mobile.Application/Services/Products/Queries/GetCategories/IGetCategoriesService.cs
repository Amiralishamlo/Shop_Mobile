using Shop_Mobile.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Mobile.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execute(long? ParentId);
    }
}
