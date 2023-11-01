using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Stakeholder.Blogging
{
    [Authorize(Policy = "authorOrTouristPolicy")]
    [Route("api/blog")]
    public class BlogController: BaseApiController
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        public ActionResult<BlogDto> Create([FromBody] BlogDto blog)
        {
            var result = _blogService.Create(blog);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet("get/{blogId:int}")]
        public ActionResult<BlogDto> Get([FromQuery] int id)
        {
            return CreateResponse(_blogService.Get(id));
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public ActionResult<BlogDto> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_blogService.GetPaged(page, pageSize));
        }

        [HttpPut("{blogId:int}")]
        public ActionResult<BlogDto> Update([FromBody] BlogDto blog)
        {
            return CreateResponse(_blogService.Update(blog));
        }

        [HttpDelete("{blogId:int}")]
        public ActionResult Delete(int blogId)
        {
            return CreateResponse(_blogService.Delete(blogId));
        }
    }
}
