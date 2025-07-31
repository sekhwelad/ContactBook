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

    private Profile(
        Guid id,
        string firstName,
        string lastName,
        string description,
        string email,
        string cellPhone,
        string website
        ) :base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Description = description;
        Email = email;
        Cellphone = cellPhone;
        Website = website;
    }

    public Profile(){}

    public static Profile CreateProfile(string firstName, string lastName, string description, string email, string cellPhone, string website)
    {
        var profile = new Profile(
            Guid.NewGuid(),
            firstName,
            lastName,
            description,
            email,
            cellPhone,
            website
            );

        return profile;
    }
}
