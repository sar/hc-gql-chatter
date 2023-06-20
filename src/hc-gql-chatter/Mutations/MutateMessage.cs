namespace hc_gql_chatter;

using hc_gql_chatter.Model;
using HotChocolate;
using HotChocolate.AspNetCore;

[ExtendObjectType(Name = "Mutation")]
public class MutateMessage
{
    public Message AddMessage(Message m)
    {
        return m;
    }
}

