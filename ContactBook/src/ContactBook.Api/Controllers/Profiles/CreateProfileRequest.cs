namespace AddressBook.Api.Controllers.Profiles;

public sealed record CreateProfileRequest(
     string FirstName,
     string LastName,
     string Description,
     string Email,
     string Cellphone,
     string Website);

