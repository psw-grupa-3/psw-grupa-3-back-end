﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class ShoppingCartDto
    {
         public int Id { get; set; }
         public int IdUser { get; init; }
         public List<OrderItemDto> Items { get; init; }
    }
}
