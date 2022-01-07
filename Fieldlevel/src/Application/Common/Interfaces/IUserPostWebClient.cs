using Fieldlevel.Domain.Entities;

namespace Fieldlevel.Application.Common.Interfaces;

public interface IUserPostWebClient
{
    Task<IEnumerable<UserPost>?> GetMostRecentUsersPost();
}
