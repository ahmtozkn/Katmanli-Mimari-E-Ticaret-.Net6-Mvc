using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class AddressEntity : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string PostaKodu { get; set; }
        public int UserId { get; set; }

        public UserEntity User { get; set; }
        public List<OrderEntity> Orders { get; set; }
    }

    public class AddressConfiguration : BaseConfiguration<AddressEntity>
    {
        public override void Configure(EntityTypeBuilder<AddressEntity> builder)
        {



            builder.Property(x => x.Id).IsRequired();
            base.Configure(builder);
        }

    }
}
