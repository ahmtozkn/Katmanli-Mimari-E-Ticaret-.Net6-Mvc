using FirstShop.Data.Entities;
using FirstShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class ListPaymentMethodDto
    {
        public int Id { get; set; }
        public PaymentMethodEnum? PaymentMethodName { get; set; }

        public string? CardNumber { get; set; }

        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }

        public int? CVV { get; set; }

        public int UserId { get; set; }
    }
}
