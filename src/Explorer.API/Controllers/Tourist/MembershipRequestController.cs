using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Explorer.API.Controllers.Tourist
{
    //[Authorize(Policy = "_ROLE_Policy")]
    [Route("api/membershipRequests")]
    public class MembershipRequestController : BaseApiController
    {
        private readonly IMembershipRequestService _membershipRequestService;

        public MembershipRequestController(IMembershipRequestService membershipRequestService)
        {
            _membershipRequestService = membershipRequestService;

        }

        [HttpPut("accept/{id:int}")]
        public ActionResult<MembershipRequestDto> Accept([FromBody] MembershipRequestDto req)
        {
            var result = _membershipRequestService.AcceptMembershipRequest(req);
            return CreateResponse(result);
        }
        [HttpPost]
        public ActionResult<MembershipRequestDto> Create([FromBody] MembershipRequestDto req)
        {
            if (HttpContext.User.Identity != null)
            {
                var userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == "id").Value);
                req.TouristId = userId;
                var result = _membershipRequestService.CreateMembershipRequest(req);
                return CreateResponse(result);
            }

            return Unauthorized();
        }  
      
        [HttpPut("reject/{id:int}")]
        public ActionResult<MembershipRequestDto> Reject([FromBody] MembershipRequestDto req)
        {
            var result = _membershipRequestService.RejectMembershipRequest(req);
            return CreateResponse(result);
        }
        

    }
}
