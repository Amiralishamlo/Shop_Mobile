﻿using Microsoft.AspNetCore.Hosting;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Application.Interfaces.FacadPatterns;
using Shop_Mobile.Application.Services.Products.Commands.AddNewCategory;
using Shop_Mobile.Application.Services.Products.Commands.AddNewProduct;
using Shop_Mobile.Application.Services.Products.Queries.GetAllCategories;
using Shop_Mobile.Application.Services.Products.Queries.GetCategories;
using Shop_Mobile.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Shop_Mobile.Application.Services.Products.Queries.GetProductForAdmin;
using Shop_Mobile.Application.Services.Products.Queries.GetProductForSite;

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
        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }


        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }


        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }
    }
}
