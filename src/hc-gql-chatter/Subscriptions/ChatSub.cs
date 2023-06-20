namespace hc_gql_chatter;

using hc_gql_chatter.Model;
using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore;
using HotChocolate.Data;
using HotChocolate.Execution;
using HotChocolate.Types;

[ExtendObjectType(Name = "Subscription")]
public class ChatSub
{
    [Topic]
    [Subscribe]
    public Message ChatMessageSub([EventMessage] Message m)
    {
        return m;
    }
}

