namespace FirstShop.WebUI.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
