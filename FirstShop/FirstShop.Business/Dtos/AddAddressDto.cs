using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class AddAddressDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }
    }
}
