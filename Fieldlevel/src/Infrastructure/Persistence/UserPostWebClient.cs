using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fieldlevel.Application.Common.Exceptions;
using Fieldlevel.Application.Common.Interfaces;
using Fieldlevel.Domain.Entities;
using Fieldlevel.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Fieldlevel.Infrastructure.Persistence;

public class UserPostWebClient : IUserPostWebClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _memoryCache;

    public UserPostWebClient(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
    {
        _httpClientFactory = httpClientFactory;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<UserPost>?> GetMostRecentUsersPost()
    {
        if (!_memoryCache.TryGetValue(CacheKeys.MostRecentUserPosts, out IEnumerable<UserPost>? cacheMostRecentUsersPosts))
        {
            var httpClient = _httpClientFactory.CreateClient("UserPost");
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (!response.IsSuccessStatusCode)
            {
                throw new NotFoundException("Third party API is down or no user posts found");
            }

            var userPosts = await response.Content.ReadFromJsonAsync<IEnumerable<UserPost>>();
            if(userPosts == null || !userPosts.Any())
            {
                throw new NotFoundException("No user posts found");
            }

            var mostRecentUsersPosts = userPosts
                            .OrderByDescending(x => x.Id)
                            .DistinctBy(x => x.UserId);

            cacheMostRecentUsersPosts = mostRecentUsersPosts;

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));

            _memoryCache.Set(CacheKeys.MostRecentUserPosts, cacheMostRecentUsersPosts, cacheEntryOptions);
        }
            
        return cacheMostRecentUsersPosts;
    }
}
