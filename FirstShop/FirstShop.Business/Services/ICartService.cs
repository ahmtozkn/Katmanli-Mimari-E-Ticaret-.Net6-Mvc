using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
   public interface ICartService
    {
        bool AddCart(AddCartDto addCartDto);

        GetCartDto GetCartById(int id);

        List<GetCartDto> GetAll();

        GetCartDto GetCart(int userid);
    }
}
