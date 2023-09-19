using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
    public interface ICartItemService
    {
        bool AddCartItem(AddCartItemDto addCartItemDto);

        List<ListCartItemDto> GetAllCartItems();

        void EditCartItem(EditCartItemDto editCartItemDto);

        void DeleteCartItem(int id);

        EditCartItemDto GetCartItemById(int id);
    }
}
