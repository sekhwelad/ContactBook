using ContactBook.Domain.Abstractions;

namespace ContactBook.Domain.Persons;

public sealed class Profile : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Description { get; private set; }
    public string Email { get; private set; }
    public string Cellphone { get; private set; }
    public string Website { get; private set; }
    public string ImageUrl { get; private set; }
}
