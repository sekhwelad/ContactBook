using AddressBook.Application.Abstractions.Messaging;
using ContactBook.Application.Profiles.GetProfile;
using Microsoft.AspNetCore.Http;

namespace AddressBook.Application.Profiles.UploadProfilePicture;

public sealed record UploadProfilePictureCommand(IFormFile file, string Email) : ICommand<ProfileResponse>;

