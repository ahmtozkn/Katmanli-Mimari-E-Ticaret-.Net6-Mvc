using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
  public interface ICommentService
    {
        void AddComment(AddCommentDto commentDto);
        List<ListCommentDto> GetAllComments();

        EditCommentDto GetCartItem(int id);

        void EditComment(EditCommentDto edit);
    }
}
