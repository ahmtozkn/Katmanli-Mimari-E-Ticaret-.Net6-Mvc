using FirstShop.Business.Dtos;
using FirstShop.Data.Enums;

namespace FirstShop.WebUI.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal? Price { get; set; }

        public int PaymentMethodId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }

        public string Adres { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedDate { get; set; }

        public string PaymentMethodName {  get; set; }
        public decimal? TotalPrice { get; set; }

        public List<ListOrderDetailDto> ImagePaths { get; set; }
    }
}
