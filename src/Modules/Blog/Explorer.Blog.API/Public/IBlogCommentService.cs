﻿using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Blog.API.Public
{
    public interface IBlogCommentService
    {
        Result<BlogCommentDto> Create(BlogCommentDto comment);
        Result<PagedResult<BlogCommentDto>> GetPaged(int page, int pageSize);
        Result<BlogCommentDto> Update(BlogCommentDto comment);
        Result Delete(int id);
    }
}
