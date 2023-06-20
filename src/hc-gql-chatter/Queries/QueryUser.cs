namespace hc_gql_chatter;

using hc_gql_chatter.Model;
using HotChocolate.AspNetCore;
using HotChocolate.Data;
using System;
using Microsoft.EntityFrameworkCore;
using HotChocolate.Execution;
using HotChocolate.Types;

[ExtendObjectType(Name = "Query")]
public class QueryUser
{
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
                IsActive = true
            }
        };

        return users;
    }
}

