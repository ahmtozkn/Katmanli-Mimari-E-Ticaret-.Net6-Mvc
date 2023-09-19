namespace FirstShop.WebUI.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ImagePath { get; set; }

        public decimal? Total { get; set; }
    }
}
