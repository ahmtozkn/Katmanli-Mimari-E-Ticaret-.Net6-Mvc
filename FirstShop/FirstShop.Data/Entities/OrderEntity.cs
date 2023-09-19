using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstShop.Data.Enums;

namespace FirstShop.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        public int UserId { get; set; }

        public int AddressId { get; set; }

        public int PaymentMethodId {  get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        
        public PaymentMethodEntity PaymentMethod { get; set; }

        public List<OrderDetailEntity> OrderDetails { get; set; }

        //public List<AddressEntity> Addresses { get; set; }
        // FOREIGN KEY ilişkisi için kullanılır
        public UserEntity User { get; set; }

        public AddressEntity Address { get; set; }

    }

    public class OrderConfiguration : BaseConfiguration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {

            

            builder.Property(x => x.UserId).IsRequired();
          
            builder.HasOne(od => od.PaymentMethod)
             .WithMany(p => p.Orders)
             .HasForeignKey(od => od.PaymentMethodId)
             .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(od => od.Address)
             .WithMany(p => p.Orders)
             .HasForeignKey(od => od.AddressId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            base.Configure(builder);
        }

    }

}
