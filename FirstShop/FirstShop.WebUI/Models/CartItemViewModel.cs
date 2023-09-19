﻿namespace FirstShop.WebUI.Models
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string ImagePath { get; set; }

        public string ProductName { get; set; }
        public decimal? Price { get; set; }

    }
}
