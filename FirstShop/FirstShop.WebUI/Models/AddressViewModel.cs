namespace FirstShop.WebUI.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }

        public int UserId { get; set; }
    }
}
