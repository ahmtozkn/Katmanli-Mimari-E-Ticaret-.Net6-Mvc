using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
   public interface IProductService
    {
        bool AddProduct(AddProductDto addProductDto);

        List<ListProductDto> GetProducts();

        EditProductDto GetProductById(int id);

        void EditProduct(EditProductDto editProductDto);

        void DeleteProduct(int id);

        List<ListProductDto> GetProductByIdCategoryId(int? categoryid);

        DetailProductDto GetDetailProductById(int id);
    }
}
