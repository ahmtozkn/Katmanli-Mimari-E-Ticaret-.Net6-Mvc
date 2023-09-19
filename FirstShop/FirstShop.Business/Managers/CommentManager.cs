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
    public class CommentManager:ICommentService
    {
        private readonly IRepository<CommentEntity> _commentRepository;

        public CommentManager(IRepository<CommentEntity> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddComment(AddCommentDto commentDto)
        {
            var commentEntity = new CommentEntity()
            {
                UserId = commentDto.UserId,
                ProductId = commentDto.ProductId,
                Comment = commentDto.Comment,

            };
            _commentRepository.Add(commentEntity);


        }

        public void EditComment(EditCommentDto edit)
        {
            var commentEntity = new CommentEntity()
            {
                Id = edit.Id,
                UserId = edit.UserId,
                ProductId = edit.ProductId,
                Comment = edit.Comment,
            };
            _commentRepository.Update(commentEntity);

        }

        public List<ListCommentDto> GetAllComments()
        {
            var commentEntity = _commentRepository.GetAll();
            var addCommentDto = commentEntity.Select(x => new ListCommentDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                Comment = x.Comment,
                ProdcutId = x.ProductId,
                CreatDate = x.CreatedDate,
                UserName = x.User.FirstName + " " + x.User.LastName,

            }).ToList();

            return addCommentDto;





        }

        public EditCommentDto GetCartItem(int id)
        {
            var entity = _commentRepository.GetById(id);
            var dto = new EditCommentDto()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ProductId = entity.ProductId,
                Comment = entity.Comment,


            };
            return dto;

        }
    }
}
