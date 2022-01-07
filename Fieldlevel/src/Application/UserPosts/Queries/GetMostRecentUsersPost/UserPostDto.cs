using Fieldlevel.Application.Common.Mappings;
using Fieldlevel.Domain.Entities;

namespace Fieldlevel.Application.UserPosts.Queries.GetMostRecentUsersPost;

public class UserPostDto : IMapFrom<UserPost>
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body {  get; set; }
}
