namespace hc_gql_chatter.Model;

using HotChocolate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [GraphQLName("active")]
    public bool IsActive { get; set; }
}
