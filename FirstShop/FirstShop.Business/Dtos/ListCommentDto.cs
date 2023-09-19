using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class ListCommentDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int UserId { get; set; }

        public int ProdcutId { get; set; }

        public DateTime CreatDate { get; set; }

        public string UserName { get; set; }

    }
}
