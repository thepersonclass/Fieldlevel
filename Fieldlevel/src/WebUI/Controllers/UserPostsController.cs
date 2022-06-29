using Fieldlevel.Application.UserPosts.Queries.GetMostRecentUsersPost;
using Microsoft.AspNetCore.Mvc;

namespace FieldlevelWebApi.Fieldlevel.Controllers;

public class UserPostsController : ApiControllerBase
{
    [HttpGet("recent")]
    public async Task<IEnumerable<UserPostDto>> GetMostRecentUsersPosts()
    {
        return await Mediator.Send(new GetMostRecentUsersPostQuery());
    }
}
