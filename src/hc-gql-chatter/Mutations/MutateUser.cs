namespace hc_gql_chatter;

using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.AspNetCore;
using hc_gql_chatter.Model;
using HotChocolate.Execution;
using HotChocolate.Types;

[ExtendObjectType(Name = "Mutation")]
public class MutateUser
{
    public User AddUser(User u)
    {
        return u;
    }
}

