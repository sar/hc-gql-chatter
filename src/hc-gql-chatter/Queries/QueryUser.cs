namespace hc_gql_chatter;

using HotChocolate.AspNetCore;
using HotChocolate.Data;
using System;
using Microsoft.EntityFrameworkCore;

[ExtendObjectType(Name = "Query")]
public class QueryUser
{
    [AllowAnonymous]
    [UsePaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<List<User>> GetUsersAsync()
    {
        List<User> users = new()
        {
            new User()
            {
                Name = "Sar",
                Email = "malik@sarthak.ca",
                Pwd = "some_token",
                IsActive = true
            }
        };

        return users;
    }
}

