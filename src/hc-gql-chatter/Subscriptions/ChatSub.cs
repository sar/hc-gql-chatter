namespace hc_gql_chatter;

using hc_gql_chatter.Model;
using HotChcoolate;
using HotChcoolate.AspNetCore;
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

