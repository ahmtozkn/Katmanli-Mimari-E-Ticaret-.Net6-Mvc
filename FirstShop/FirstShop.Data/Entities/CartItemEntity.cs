using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class CartItemEntity : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

        public CartEntity Cart { get; set; }

        public ProductEntity Product { get; set; }

    }
    public class CartItemConfiguration : BaseConfiguration<CartItemEntity>
    {

        public override void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {


            builder.Property(x => x.CartId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.Price).IsRequired(false);
            builder.HasOne(od => od.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(od => od.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            base.Configure(builder);

        }
    }

}
