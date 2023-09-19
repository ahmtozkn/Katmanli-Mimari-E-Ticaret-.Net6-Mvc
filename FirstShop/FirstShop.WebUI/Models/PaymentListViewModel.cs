namespace FirstShop.WebUI.Models
{
    public class PaymentListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CardNumber { get; set; }

        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
    }
}
