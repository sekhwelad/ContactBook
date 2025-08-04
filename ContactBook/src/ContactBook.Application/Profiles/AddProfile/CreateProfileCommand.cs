using AddressBook.Application.Abstractions.Messaging;

namespace AddressBook.Application.Profiles.AddProfile;

public sealed record CreateProfileCommand(
    string FirstName, 
    string LastName, 
    string Description, 
    string Email,
    string CellPhone,
    string Website,
    DateTime CreatedDate) : ICommand<Guid>;

