using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class EditCommentDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int UserId { get; set; }


        public int ProductId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
