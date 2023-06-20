namespace hc_gql_chatter;

using hc_gql_chatter.Model;

using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore;
using HotChocolate.Data;
using HotChocolate.Execution;
using HotChocolate.Types;

using System;
using System.Threading.Tasks;
using System.Linq;

[ExtendObjectType(Name = "Mutation")]
public class MutateMessage
{
    public async Task<Message> AddMessageAsync(
        Message m, 
        [Service] ITopicEventSender eventSender,
        CancellationToken ct)
    {
        await eventSender.SendAsync(
                nameof(ChatSub.ChatMessageSub),
                m, ct);

        return m;
    }
}

