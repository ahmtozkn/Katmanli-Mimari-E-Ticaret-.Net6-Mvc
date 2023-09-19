namespace FirstShop.WebUI.Models
{
    public class LikeViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public bool IsLiked { get; set; }
    }

}
