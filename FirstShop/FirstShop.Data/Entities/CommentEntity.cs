using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Entities
{
    public class CommentEntity : BaseEntity
    {
        public int UserId { get; set; }

        public string Comment { get; set; }

        public int ProductId { get; set; }


        public UserEntity User { get; set; }

        public ProductEntity Product { get; set; }

    }
    public class CommentConfiguration : BaseConfiguration<CommentEntity>
    {
        public override void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasOne(c => c.User)
       .WithMany(u => u.Comments)
       .HasForeignKey(c => c.UserId)
       .OnDelete(DeleteBehavior.NoAction);




            base.Configure(builder);
        }
    }
}
