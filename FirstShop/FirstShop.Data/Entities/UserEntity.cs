using FirstShop.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserTypeEnum UserType { get; set; }
        public List<ProductEntity> Products { get; set; }

        public List<CartEntity> Carts { get; set; }

        public List<LikeEntity> Likes { get; set; }
        public List<AddressEntity> Addresses { get; set; }
        public List<CommentEntity> Comments { get; set; }
        public List<OrderEntity> Orders { get; set; }
        //public List<OrderEntity> Orders { get; set; }
        public List<PaymentMethodEntity> PaymentMethods { get; set; }
    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
