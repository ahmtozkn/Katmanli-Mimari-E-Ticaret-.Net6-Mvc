using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class CartEntity : BaseEntity
    {
        public int UserId { get; set; }

        public List<CartItemEntity> CartItems { get; set; }

        public UserEntity User { get; set; }
    }


    public class CartConfiguration : BaseConfiguration<CartEntity>
    {

        public override void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            base.Configure(builder);
        }
    }
}
