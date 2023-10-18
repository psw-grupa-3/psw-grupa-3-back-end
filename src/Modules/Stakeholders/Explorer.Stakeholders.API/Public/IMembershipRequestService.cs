using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public
{
    public interface IMembershipRequestService
    {
         Result<MembershipRequestDto> CreateMembershipRequest(MembershipRequestDto req);
         Result<MembershipRequestDto> AcceptMembershipRequest(MembershipRequestDto req);
         Result<MembershipRequestDto> RejectMembershipRequest(MembershipRequestDto req);

    }
}
