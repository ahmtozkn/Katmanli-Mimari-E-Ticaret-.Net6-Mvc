using FirstShop.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    

    public class PaymentMethodEntity:BaseEntity
    {
        public PaymentMethodEnum? PaymentMethodName { get; set; }

        public string? CardNumber {  get; set; }

        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }

        public int? CVV {  get; set; }

        public int UserId {  get; set; }

        public UserEntity User { get; set; }

        public List<OrderEntity> Orders { get; set; }
    }

    public class PaymentMethodConfiguration:BaseConfiguration<PaymentMethodEntity>
    {
        public override void Configure(EntityTypeBuilder<PaymentMethodEntity> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CardNumber).IsRequired(false);
            builder.Property(x => x.CVV).IsRequired(false);
            builder.Property(x => x.ExpirationMonth).IsRequired(false);
            builder.Property(x => x.ExpirationYear).IsRequired(false);
           

            builder.HasOne(od => od.User)
             .WithMany(p => p.PaymentMethods)
             .HasForeignKey(od => od.UserId)
             .OnDelete(DeleteBehavior.ClientSetNull);


            base.Configure(builder);
        }
    }
}
