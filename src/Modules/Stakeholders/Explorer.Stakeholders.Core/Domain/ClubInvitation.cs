using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain
{
    public class ClubInvitation : Entity
    {
        
        //public int ClubOwnerId { get; init; }
        public int TouristId { get; init; }
        public int ClubId { get; init; }
        public bool IsRead { get; init; }=false;

        public ClubInvitation() { }
        public ClubInvitation(int touristId,int clubId,bool isRead)
        {
            if (TouristId == 0) throw new ArgumentException("Invalid TouristId");
            TouristId = touristId;
            if (ClubId == 0) throw new ArgumentException("Invalid ClubId");
            ClubId = clubId;
            IsRead = isRead;
           
        }
    }
}

