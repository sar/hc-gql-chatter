namespace hc_gql_chatter;

using hc_gql_chatter.Model;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Susbcriptions;
using HotChocolate.AspNetCore;
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

