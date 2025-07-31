namespace AddressBook.Api.Controllers.Profiles;

public sealed record UploadProfilePictureRequest(IFormFile file, string email);

