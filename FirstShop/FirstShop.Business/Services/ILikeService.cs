using FirstShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Services
{
    public interface ILikeService
    {
        int AddLike(AddLikeDto addLikeDto);
        void DeletehLike(int id);
        List<ListLikeDto> GetAllLike();

        GetLikeDto GetLike(int id);

        void EditLike(EditLikeDto editLikeDto);

    }
}
