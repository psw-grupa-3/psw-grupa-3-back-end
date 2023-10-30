using Explorer.Blog.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Blog.API.Public
{
    public interface IBlogService
    {
        Result<BlogDto> Create(BlogDto blog);
        Result <PagedResult<BlogDto>>GetPaged(int page, int pageSize);
        Result <BlogDto>Update(BlogDto blog);
        Result Delete(int blogId);
    }
}
