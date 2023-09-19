using FirstShop.Data.Entities;
using FirstShop.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace FirstShop.WebUI.Models
{
    public class PaymentMethodViewModel
    {
        public int Id { get; set; }
        public PaymentMethodEnum PaymentMethodName { get; set; }

     
        public string? CardNumber { get; set; }

       
        public int? ExpirationMonth { get; set; }

      
        public int? ExpirationYear { get; set; }

     
        public int? CVV { get; set; }

        public int UserId { get; set; }
        public int AddressId {  get; set; }


    }
}
