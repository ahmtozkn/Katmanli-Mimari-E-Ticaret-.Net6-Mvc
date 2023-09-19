using FirstShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class AddOrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int AddressId { get; set; }

        public int PaymentMethodId {  get; set; }

        public OrderStatusEnum OrderStatus { get; set; }
    }
}
