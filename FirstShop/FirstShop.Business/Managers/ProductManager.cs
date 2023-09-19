using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.Data.Entities;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Managers
{
    public class ProductManager:IProductService
    {
        private readonly IRepository<ProductEntity> _productRepository;
        public ProductManager(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }
        public bool AddProduct(AddProductDto addProductDto)
        {
            var hasProduct = _productRepository.GetAll(x => x.Name.ToLower() == addProductDto.Name.ToLower()).ToList();

            if (hasProduct.Any())
            {
                return false;
            }

            var productEntity = new ProductEntity()
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                UnitInStock = addProductDto.UnitInStock,
                UnitPrice = addProductDto.UnitPrice,
                CategoryId = addProductDto.CategoryId,
                ImagePath = addProductDto.ImagePath,
                UserId = addProductDto.UserId

            };

            _productRepository.Add(productEntity);
            return true;


        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }

        public void EditProduct(EditProductDto editProductDto)
        {
            var productEntity = _productRepository.GetById(editProductDto.Id);
          

            productEntity.Name = editProductDto.Name;
            productEntity.Description = editProductDto.Description;
            productEntity.UnitPrice = editProductDto.UnitPrice;
            productEntity.UnitInStock = editProductDto.UnitInStock;
            productEntity.CategoryId = editProductDto.CategoryId;
            productEntity.UserId = editProductDto.UserId;

            if (editProductDto.ImagePath is not null)
            {
                productEntity.ImagePath = editProductDto.ImagePath;
            }
           

            _productRepository.Update(productEntity);

        }

        public DetailProductDto GetDetailProductById(int id)
        {
            var productsEntity = _productRepository.GetById(id);
            var detailproductdto = new DetailProductDto()
            {
                Id = productsEntity.Id,
                Name = productsEntity.Name,
                Description = productsEntity.Description,
                UnitPrice = productsEntity.UnitPrice,
                UnitInStock = productsEntity.UnitInStock,
                CategoryId = productsEntity.CategoryId,
                UserId = productsEntity.UserId,
                ImagePath = productsEntity.ImagePath
            };
            return detailproductdto;
        }

        public EditProductDto GetProductById(int id)
        {
            var productEntity = _productRepository.GetById(id);

            var editProductDto = new EditProductDto()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                UnitInStock = productEntity.UnitInStock,
                UnitPrice = productEntity.UnitPrice,
                CategoryId = productEntity.CategoryId,
                ImagePath = productEntity.ImagePath,
                UserId = productEntity.UserId

            };

            return editProductDto;

        }

        public List<ListProductDto> GetProductByIdCategoryId(int? categoryid)
        {
            if (categoryid.HasValue)
            {
                var productEntites = _productRepository.GetAll(x => x.CategoryId == categoryid).OrderBy(x => x.Name);

                var productListDto = productEntites.Select(x => new ListProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitInStock = x.UnitInStock,
                    UnitPrice = x.UnitPrice,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    ImagePath = x.ImagePath,
                    UserId = x.UserId

                }).ToList();

                return productListDto;
            }
            return GetProducts();
            

        }

        public List<ListProductDto> GetProducts()
        {
            var productEntites = _productRepository.GetAll().OrderBy(x => x.Category.Name).ThenBy(x => x.Name);
            

            var productDtoList = productEntites.Select(x => new ListProductDto
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                UnitInStock = x.UnitInStock,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                ImagePath = x.ImagePath,
                UserName = x.User.FirstName + " " + x.User.LastName
            }).ToList();

            return productDtoList;
        }
    }
}
