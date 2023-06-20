namespace hc_gql_chatter.Model;

public class Chat
{
    public Guid Id { get; set; }

    public string? Label { get; set; }

    public ICollection<User> Users { get; set; }

    public ICollection<Message> Messages { get; set; }
}
