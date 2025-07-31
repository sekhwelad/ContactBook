using AddressBook.Application.Abstractions.Messaging;
using ContactBook.Domain.Abstractions;
using ContactBook.Domain.Persons;

namespace AddressBook.Application.Profiles.AddProfile;

internal sealed class CreateProfileCommandHandler : ICommandHandler<CreateProfileCommand, Guid>
{
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfwork _unitOfwork;

    public CreateProfileCommandHandler(IProfileRepository profileRepository,IUnitOfwork unitOfwork)
    {
        _profileRepository = profileRepository;
        _unitOfwork = unitOfwork;
    }
    public async Task<Result<Guid>> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = Profile.CreateProfile
            (
                request.LastName,
                request.FirstName,
                request.Description,
                request.Email,
                request.CellPhone,
                request.Website
            );

        _profileRepository.Add(profile);

        await _unitOfwork.SaveChangesAsync();

        return Result.Success(profile.Id);  
    }
}
