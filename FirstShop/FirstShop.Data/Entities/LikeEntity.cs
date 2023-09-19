using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class LikeEntity : BaseEntity
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public bool IsLiked { get; set; }

        public UserEntity User { get; set; }

        public ProductEntity Product { get; set; }

    }



    public class LikeConfiguration : BaseConfiguration<LikeEntity>
    {

        public override void Configure(EntityTypeBuilder<LikeEntity> builder)
        {

            builder.HasOne(c => c.Product)
              .WithMany(u => u.Likes)
              .HasForeignKey(c => c.ProductId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(c => c.User)
              .WithMany(u => u.Likes)
              .HasForeignKey(c => c.UserId)
              .OnDelete(DeleteBehavior.ClientSetNull);


            base.Configure(builder);
        }


    }
}
