using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class OrderDetailEntity : BaseEntity
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ImagePath { get; set; }

        public ProductEntity Product { get; set; }
        public OrderEntity Order { get; set; }


    }
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetailEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.Property(X => X.Id).IsRequired();
            builder.Property(X => X.OrderId).IsRequired();
            builder.Property(X => X.ProductId).IsRequired();
            builder.Property(x => x.Price).IsRequired(false);

            builder.Property(x => x.ImagePath).IsRequired(false);

            builder.HasOne(od => od.Product)
             .WithMany(p => p.OrderDetails)
             .HasForeignKey(od => od.ProductId)
             .OnDelete(DeleteBehavior.ClientSetNull);





            base.Configure(builder);
        }
    }


}
