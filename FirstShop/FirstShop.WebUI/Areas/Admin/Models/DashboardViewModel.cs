namespace FirstShop.WebUI.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int UserCount { get; set; }

        public int AdminCount { get; set; }

        public int AllUserCount { get; set; }

        public int OrderCount { get; set; }

        public int OrderWeekCount { get; set; }

        public decimal? Income { get; set; }

        public int ProductCount { get; set; }

        public int PendingOrderCount { get; set; }

    }
}
