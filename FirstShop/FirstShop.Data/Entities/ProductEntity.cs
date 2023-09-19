using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; } // ? nullable
        public int UnitInStock { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        // Relational Property

        public int UserId { get; set; }

        public List<LikeEntity> Likes { get; set; }
        public UserEntity User { get; set; }

        public CategoryEntity Category { get; set; }

        public List<CartItemEntity> CartItems { get; set; }

        public List<CommentEntity> Comments { get; set; }

        public List<OrderDetailEntity> OrderDetails { get; set; }

    }

    public class ProductConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {



            // Name zorunlu ve max 50 karakter
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);




            // description null olabilir
            builder.Property(x => x.Description)
                .IsRequired(false);

            // unitprice null olabilir
            builder.Property(x => x.UnitPrice)
                .IsRequired(false);

            // ImagePath null olabilir.
            builder.Property(x => x.ImagePath)
                .IsRequired(false);

            // categoryId zorunlu
            builder.Property(x => x.CategoryId)
                .IsRequired();

            // zorunlu olacak kısımları yazılmasa da entity framework otomatik olarak zorunlu kılar.

            base.Configure(builder);
        }
    }
}
