using FirstShop.Business.Dtos;
using FirstShop.Business.Services;
using FirstShop.Data.Entities;
using FirstShop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Managers
{
    public class CartItemManager:ICartItemService
    {
        private readonly IRepository<CartItemEntity> _cartItemRepository;
        public CartItemManager(IRepository<CartItemEntity> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public bool AddCartItem(AddCartItemDto addCartItemDto)
        {
            var cartItemEntity = new CartItemEntity()
            {
                CartId = addCartItemDto.CartId,
                Price = addCartItemDto.Price,
                Quantity = addCartItemDto.Quantity,
                ProductId = addCartItemDto.ProductId,
            };
            _cartItemRepository.Add(cartItemEntity);
            return true;

        }

        public void DeleteCartItem(int id)
        {
            _cartItemRepository.Delete(id);
        }

        public void EditCartItem(EditCartItemDto editCartItemDto)
        {
            var cartItemEntity = _cartItemRepository.GetById(editCartItemDto.Id);



            cartItemEntity.CartId = editCartItemDto.CartId;
            cartItemEntity.Price = editCartItemDto.Price;
            cartItemEntity.Quantity = editCartItemDto.Quantity;
            cartItemEntity.ProductId = editCartItemDto.ProductId;


            _cartItemRepository.Update(cartItemEntity);


        }

        public List<ListCartItemDto> GetAllCartItems()
        {
            var cartItemEntity = _cartItemRepository.GetAll();

            var cartItemDto = cartItemEntity.Select(x => new ListCartItemDto()
            {
                Id = x.Id,
                Price = x.Price,
                Quantity = x.Quantity,
                ProductId = x.ProductId,
                CartId = x.CartId,
                ImagePath = x.Product.ImagePath,
                ProductName = x.Product.Name

            }).ToList();
            return cartItemDto;
        }

        public EditCartItemDto GetCartItemById(int id)
        {
            var cartItemEntity = _cartItemRepository.GetById(id);
            var cartItemDto = new EditCartItemDto()
            {
                Id = cartItemEntity.Id,
                Price = cartItemEntity.Price,
                Quantity = cartItemEntity.Quantity,
                ProductId = cartItemEntity.ProductId,
                CartId = cartItemEntity.CartId,
            };
            return cartItemDto;


        }
    

    }
}
