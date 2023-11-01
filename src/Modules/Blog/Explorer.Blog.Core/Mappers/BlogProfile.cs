using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.Core.Domain;
using System.Linq;
using Vote = Explorer.Blog.Core.Domain.Vote;

namespace Explorer.Blog.Core.Mappers;

public class BlogProfile : Profile
{
    public BlogProfile()
    {

        CreateMap<BlogDto, Domain.Blog>()
            .ForMember(dest => dest.Ratings, opt =>
                opt.MapFrom(src =>
                    src.Ratings.Select( x =>
                        new BlogRating(x.BlogId, x.UserId, x.VotingDate, (Vote)x.Mark)
                        )));

        CreateMap<Domain.Blog, BlogDto>()
            .ForMember(dest => dest.Ratings, opt =>
                opt.MapFrom(src =>
                    src.Ratings.Select( x =>
                        new BlogRatingDto
                        {
                            BlogId = (int)x.BlogId,
                            UserId = (int)x.UserId,
                            VotingDate = x.VotingDate,
                            Mark = (API.Dtos.Vote)x.Mark
                        }
                    )));
    }
}