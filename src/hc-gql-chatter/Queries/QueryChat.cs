namespace hc_gql_chatter;

using hc_gql_chatter.Model;
using System;

[ExtendObjectType(Name = "Query")]
public class QueryChat
{
    public List<Message> GetMessages()
    {
        List<Message> m = new();

        for (int i = 0; i < 8; i++)
        {
            Message x = new()
            {
                Sender = "foo",
                Text = "random_text_"
            };
            m.Add(x);
        };

        return m.ToList();
    }
}

