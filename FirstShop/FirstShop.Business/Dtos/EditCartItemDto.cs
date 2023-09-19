﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShop.Business.Dtos
{
    public class EditCartItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int CartId { get; set; }


        public decimal? Price { get; set; }

        public int Quantity { get; set; }
    }
}
