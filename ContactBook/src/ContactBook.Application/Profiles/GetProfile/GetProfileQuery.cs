using AddressBook.Application.Abstractions.Messaging;
using ContactBook.Application.Profiles.GetProfile;

namespace AddressBook.Application.Profiles.GetProfile;

public sealed record GetProfileQuery(string Email) : IQuery<ProfileResponse>;

