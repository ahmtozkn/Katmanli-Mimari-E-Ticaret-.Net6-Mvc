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
    public class CartManager:ICartService
    {
        private readonly IRepository<CartEntity> _cartRepository;

        public CartManager(IRepository<CartEntity> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public bool AddCart(AddCartDto addCartDto)
        {

            var hasUser = _cartRepository.GetAll(x => x.UserId == addCartDto.UserId);
            if (hasUser.Any())
            {
                return false;
            }

            var cartEnity = new CartEntity()
            {
                UserId = addCartDto.UserId,
            };
            _cartRepository.Add(cartEnity);

            return true;

        }

        public List<GetCartDto> GetAll()
        {
            var cartEntity = _cartRepository.GetAll();
            var getCart = cartEntity.Select(x => new GetCartDto()
            {
                Id = x.Id,
                UserId = x.UserId,

            }).ToList();
            return getCart;

        }

        public GetCartDto GetCartById(int id)
        {
            var cartEntity = _cartRepository.GetById(id);
            var getCartDto = new GetCartDto()
            {
                Id = cartEntity.Id,
                UserId = cartEntity.UserId,

            };
            return getCartDto;

        }

        public GetCartDto GetCart(int userid)
        {
            var cartEntity = _cartRepository.Get(x => x.UserId == userid);

            if(cartEntity is not null)
            { 
                var getCartDto = new GetCartDto()
              {
                Id = cartEntity.Id,
                UserId = cartEntity.UserId,
              };
              return (getCartDto);

            }
            return null;
             
            
        }
    }
}
