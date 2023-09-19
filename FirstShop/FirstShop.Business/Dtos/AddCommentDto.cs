using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class AddCommentDto
    {
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public string Comment { get; set; }

    }
}
