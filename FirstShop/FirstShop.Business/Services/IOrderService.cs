using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
    public interface IOrderService
    {
        int AddOrder(AddOrderDto cart);
        List<ListOrderDto> GetOrders();

        GetOrderDto GetOrder(int id);

        void DeleteOrder(int id);

        void EditOrder(GetOrderDto order);
    }
}
