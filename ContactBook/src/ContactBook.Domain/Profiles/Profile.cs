using ContactBook.Domain.Abstractions;

namespace ContactBook.Domain.Persons;

public sealed class Profile : Entity
{
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
    public Description Description { get; set; }
    public string Email { get; set; }
    public string Cellphone { get; set; }
    public string Website { get; set; }
}
