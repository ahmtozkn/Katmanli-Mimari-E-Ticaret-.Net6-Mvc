using FirstShop.Data.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Data.Context
{
    public class FirstShopContext:DbContext
    {
        private readonly IDataProtector _dataProtector;
        public FirstShopContext(DbContextOptions<FirstShopContext> options,IDataProtectionProvider dataProtectionProvider):base(options)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }
        public FirstShopContext(DbContextOptions<FirstShopContext> options):base(options) 
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());



            var pwd = "123";
            pwd=_dataProtector.Protect(pwd);
            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id=7,
                    FirstName="Admin",
                    LastName="Admin",
                    Email="Admin@email.com",
                    Password=pwd,
                    UserType=Enums.UserTypeEnum.Admin

                }
            });




           base.OnModelCreating(modelBuilder);

        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<CartEntity> Carts => Set<CartEntity>();
        public DbSet<CartItemEntity> CartItems => Set<CartItemEntity>();
        public DbSet<OrderDetailEntity> OrderDetails => Set<OrderDetailEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<CommentEntity> Comments => Set<CommentEntity>();
        public DbSet<AddressEntity> Addresses => Set<AddressEntity>();

        public DbSet<LikeEntity> Likes => Set<LikeEntity>();

        public DbSet<PaymentMethodEntity> PaymentMethods => Set<PaymentMethodEntity>();

        


    }
}

