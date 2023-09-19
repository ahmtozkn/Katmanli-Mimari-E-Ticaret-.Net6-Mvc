using FirstShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class ListOrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Address { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal? Price { get; set; }
        public string UserName { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PaymentMethodName {  get; set; }


        public string ImagePath { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }

    }
}
