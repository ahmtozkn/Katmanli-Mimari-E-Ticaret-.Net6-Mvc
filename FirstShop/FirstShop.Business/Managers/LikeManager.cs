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
    public class LikeManager:ILikeService
    {
        private readonly IRepository<LikeEntity> _likeRepository;

        public LikeManager(IRepository<LikeEntity> likeRepository)
        {
            _likeRepository = likeRepository;
        }


        public int AddLike(AddLikeDto addLikeDto)
        {
            var likeEntity = new LikeEntity()
            {
                UserId = addLikeDto.UserId,
                ProductId = addLikeDto.ProductId,
                IsLiked = addLikeDto.IsLiked

            };
            _likeRepository.Add(likeEntity);
            return likeEntity.Id;


        }

        public void DeletehLike(int id)
        {
            _likeRepository.Delete(id);
        }

        public void EditLike(EditLikeDto editLikeDto)
        {
            var likeEntity = _likeRepository.GetById(editLikeDto.Id);
            likeEntity.ProductId = editLikeDto.ProductId;
            likeEntity.IsLiked = editLikeDto.IsLiked;
            likeEntity.UserId = editLikeDto.UserId;
            _likeRepository.Update(likeEntity);
        }

        public List<ListLikeDto> GetAllLike()
        {
            var likeDto = _likeRepository.GetAll().Select(x => new ListLikeDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProductId = x.ProductId,
                IsLiked = x.IsLiked

            }).ToList();

            return likeDto;


        }

        public GetLikeDto GetLike(int id)
        {
            var likeEntity = _likeRepository.GetById(id);
            var likeDto = new GetLikeDto()
            {
                Id = likeEntity.Id,
                UserId = likeEntity.UserId,
                ProductId = likeEntity.ProductId,
                IsLiked = likeEntity.IsLiked
            };
            return likeDto;

        }

    }
}
