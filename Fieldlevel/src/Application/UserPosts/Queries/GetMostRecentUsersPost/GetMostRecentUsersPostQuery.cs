using AutoMapper;
using Fieldlevel.Application.Common.Interfaces;
using MediatR;

namespace Fieldlevel.Application.UserPosts.Queries.GetMostRecentUsersPost;

public class GetMostRecentUsersPostQuery : IRequest<IEnumerable<UserPostDto>>
{
}

public class GetMostRecentUsersPostQueryHandler : IRequestHandler<GetMostRecentUsersPostQuery, IEnumerable<UserPostDto>>
{
    private readonly IUserPostWebClient _userPostWebClient;
    private readonly IMapper _mapper;

    public GetMostRecentUsersPostQueryHandler(IUserPostWebClient userPostWebClient, IMapper mapper)
    {
        _userPostWebClient = userPostWebClient;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserPostDto>> Handle(GetMostRecentUsersPostQuery request, CancellationToken cancellationToken)
    {
        var userPosts = await _userPostWebClient.GetMostRecentUsersPost();

        return _mapper.Map<List<UserPostDto>>(userPosts);
    }
}

