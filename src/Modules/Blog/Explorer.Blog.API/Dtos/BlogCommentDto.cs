﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.API.Dtos
{
    public class BlogCommentDto
    {
        public int Id { get; set; } = 0;
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public string Comment { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }
}