using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Common.Dto;
using Shop_Mobile.Domain.Entites.Products;

namespace Shop_Mobile.Application.Services.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddNewProductService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }


        public ResultDto Execute(RequestAddNewProductDto request)
        {

            try
            {

                var category = _context.Categories.Find(request.CategoryId);

                Product product = new Product()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    Category = category,
                    Displayed = request.Displayed,
                };
                _context.Products.Add(product);

                List<ProductImages> productImages = new List<ProductImages>();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    productImages.Add(new ProductImages
                    {
                        Product = product,
                        Src = uploadedResult.FileNameAddress,
                    });
                }

                _context.ProductImages.AddRange(productImages);


                List<ProductFeatures> productFeatures = new List<ProductFeatures>();
                foreach (var item in request.Features)
                {
                    productFeatures.Add(new ProductFeatures
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = product,
                    });
                }
                _context.ProductFeatures.AddRange(productFeatures);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
                };
            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }

        }



        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}
