using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
   public interface IOrderDetailService
    {
        void AddOrderDetail(AddOrderDetailDto orderDetail);

        void DeleteOrderDetail(int id);

        List<ListOrderDetailDto> GetAllOrders();

        void EditOrderDetail(EditOrderDetailDto orderDetail);

        GetOrderDetailDto GetOrderDetail(int id);
    }
}
