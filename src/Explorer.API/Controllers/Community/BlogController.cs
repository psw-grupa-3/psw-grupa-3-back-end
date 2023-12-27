using Explorer.Blog.API.Dtos;
using static Explorer.Blog.API.Enums.BlogEnums;
using Explorer.Blog.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Community
{
    [Authorize(Policy = "authorOrTouristPolicy")]
    [Route("api/blog")]
    public class BlogController : BaseApiController
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
        public ActionResult<BlogDto> Get([FromRoute] int blogId)
        {
            return CreateResponse(_blogService.Get(blogId));
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public ActionResult<BlogDto> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_blogService.GetPaged(page, pageSize));
        }

        [HttpGet("getReviewedReports")]
        public ActionResult<ReportDto> GetReviewedReports()
        {
            var pagedResults = _blogService.GetPaged(1, int.MaxValue).Value.Results;
            var reviewedReports = new List<ReportDto>();

            foreach (var result in pagedResults)
            {
                var reviewed = result.Reports.FindAll(report => report.IsReviewed);
                reviewedReports.AddRange(reviewed);
            }

            return Ok(reviewedReports);
        }

        [HttpGet("getUnreviewedReports")]
        public ActionResult<ReportDto> GetUnreviewedReports()
        {
            var pagedResults = _blogService.GetPaged(1, int.MaxValue).Value.Results;
            var reviewedReports = new List<ReportDto>();

            foreach (var result in pagedResults)
            {
                var reviewed = result.Reports.FindAll(report => !report.IsReviewed);
                reviewedReports.AddRange(reviewed);
            }

            return Ok(reviewedReports);
        }

        [AllowAnonymous]
        [HttpGet("getFiltered")]
        public ActionResult<BlogDto> GetFiltered([FromQuery] BlogStatus filter)
        {
            return CreateResponse(_blogService.GetFiltered(filter));
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

        [AllowAnonymous]
        [HttpPost("rate/{blogId:int}")]
        public ActionResult<BlogRatingDto> Rate([FromRoute] int blogId,[FromBody] BlogRatingDto rating)
        {
            return CreateResponse(_blogService.RateBlog(blogId, rating));
        }

        [Authorize(Policy = "authorOrTouristPolicy")]
        [HttpPatch("publish/{blogId:int}")]
        public ActionResult<BlogRatingDto> Publish([FromRoute] int blogId)
        {
            return CreateResponse(_blogService.PublishBlog(blogId));
        }

        [HttpPost("commentBlog/{blogId:int}")]
        public ActionResult<BlogCommentDto> CommentBlog([FromRoute] int blogId, [FromBody] BlogCommentDto comment)
        {
            return CreateResponse(_blogService.CommentBlog(blogId, comment));
        }

        [HttpPost("reportBlogComment/{blogId:int}")]
        public ActionResult<ReportDto> ReportBlogComment([FromRoute] int blogId, [FromBody] ReportDto report)
        {
            return CreateResponse(_blogService.CreateReport(blogId, report));
        }

        [HttpPut("updateBlogComment/{blogId:int}")]
        public ActionResult<BlogCommentDto> UpdateBlogComment([FromRoute] int blogId, [FromBody] BlogCommentDto comment)
        {
            return CreateResponse(_blogService.UpdateComment(blogId, comment));
        }

        [HttpPut("reviewReport/{blogId:int}")]
        public ActionResult<ReportDto> ReviewReport([FromRoute] int blogId, [FromBody] ReportDto report)
        {
            return CreateResponse(_blogService.UpdateReport(blogId, report));
        }

        [HttpPut("deleteBlogComment/{blogId:int}")]
        public ActionResult<BlogCommentDto> DeleteBlogComment([FromRoute] int blogId, [FromBody] BlogCommentDto comment)
        {
            return CreateResponse(_blogService.DeleteComment(blogId, comment));
        }

        [HttpPut("deleteReportedBlogComment/{blogId:int}")]
        public ActionResult<BlogCommentDto> deleteReportedBlogComment([FromRoute] int blogId, [FromBody] ReportDto report)
        {
            var pagedResults = _blogService.GetPaged(1, int.MaxValue).Value.Results;
            var comment = new BlogCommentDto();

            foreach (var result in pagedResults)
            {
                var reviewed = result.BlogComments.Find(comment => comment.UserId == report.UserId && comment.TimeCreated == report.TimeCommentCreated);
                comment = reviewed;
            }
            return CreateResponse(_blogService.DeleteComment(blogId, comment));
        }
    }
}
