using FluentValidation;

namespace AddressBook.Application.Profiles.AddProfile;

internal sealed class CreateProfileCommandValidator :AbstractValidator<CreateProfileCommand>
{
    public CreateProfileCommandValidator()
    {
        RuleFor(c=> c.FirstName).NotEmpty();
        RuleFor(c=> c.LastName).NotEmpty();
        RuleFor(c=> c.Description).NotEmpty();
        RuleFor(c=> c.CellPhone).NotEmpty();
        RuleFor(c=> c.Website).NotEmpty();
        RuleFor(c=> c.Email).EmailAddress();
    }
}
