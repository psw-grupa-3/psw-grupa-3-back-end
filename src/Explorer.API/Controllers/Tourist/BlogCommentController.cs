using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristAndAuthorPolicy")]
    [Route("api/tourist/blogComment")]
    public class BlogCommentController : BaseApiController
    {
        private readonly IBlogCommentService _blogCommentService;

        public BlogCommentController(IBlogCommentService blogCommentService)
        {
            _blogCommentService = blogCommentService;
        }

        [HttpPost]
        public ActionResult<BlogCommentDto> Create([FromBody] BlogCommentDto blogComment)
        {
            var result = _blogCommentService.Create(blogComment);
            return CreateResponse(result);
        }

        [HttpGet("getAll")]
        public ActionResult<BlogCommentDto> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_blogCommentService.GetPaged(page, pageSize));
        }


        [HttpPut("{id:int}")]
        public ActionResult<BlogCommentDto> Update([FromBody] BlogCommentDto dataIn)
        {

            return CreateResponse(_blogCommentService.Update(dataIn));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            return CreateResponse(_blogCommentService.Delete(id));
        }
    }
}
