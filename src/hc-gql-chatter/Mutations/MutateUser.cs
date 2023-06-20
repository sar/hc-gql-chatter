namespace hc_gql_chatter;

using Microsoft.EntityFrameworkCore;
using HotChocolate.Data;
using HotChocolate.AspNetCore;

[ExtendObjectType(Name = "Mutation")]
public class MutateUser
{
    public async User AddUser(User u)
    {
        return u;
    }
}

