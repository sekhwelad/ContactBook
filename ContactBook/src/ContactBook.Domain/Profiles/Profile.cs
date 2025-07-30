using ContactBook.Domain.Abstractions;

namespace ContactBook.Domain.Persons;

public sealed class Profile : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string Cellphone { get; set; }
    public string Website { get; set; }
}
