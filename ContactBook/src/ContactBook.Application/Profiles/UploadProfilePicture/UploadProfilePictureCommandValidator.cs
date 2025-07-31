using FluentValidation;

namespace AddressBook.Application.Profiles.UploadProfilePicture;

internal sealed class UploadProfilePictureCommandValidator : AbstractValidator<UploadProfilePictureCommand>
{
    public UploadProfilePictureCommandValidator()
    {
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c=> c.File).NotEmpty();
        RuleFor(c=>c.Email).NotEmpty();
    }
}
