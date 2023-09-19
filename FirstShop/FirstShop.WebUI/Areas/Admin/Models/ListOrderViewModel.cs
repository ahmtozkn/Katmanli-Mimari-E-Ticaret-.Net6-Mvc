using FirstShop.Data.Enums;

namespace FirstShop.WebUI.Areas.Admin.Models
{
    public class ListOrderViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserName { get; set; }

        public int AddressId { get; set; }
        public int UserId { get; set; }

        public int PaymentMethodId {  get; set; }

        public string Adres { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
