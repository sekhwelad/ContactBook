using AddressBook.Application.Abstractions;
using AddressBook.Application.Abstractions.Messaging;
using ContactBook.Application.Profiles.GetProfile;

namespace AddressBook.Application.Profiles.GetProfile;

public sealed record GetProfileQuery(int PageSize, int PageNumber) : IQuery<PagedResult<ProfileResponse>>;

