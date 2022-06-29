using Fieldlevel.Application.UserPosts.Queries.GetMostRecentUsersPost;
using FluentAssertions;
using NUnit.Framework;

namespace Fieldlevel.Application.IntegrationTests.UserPosts.Queries;

using static Testing;

public class GetMostRecentUsersPostTests : TestBase
{
    [Test]
    public async Task ShouldReturnGetMostRecentUsersPost()
    {
        var query = new GetMostRecentUsersPostQuery();

        var result = await SendAsync(query);

        result.Should().HaveCount(10);
    }
}
