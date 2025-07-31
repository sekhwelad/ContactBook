using AddressBook.Application.Abstractions.Messaging;
using AddressBook.Application.Abstractions.Services;
using AddressBook.Domain.Profiles;
using ContactBook.Application.Profiles.GetProfile;
using ContactBook.Domain.Abstractions;
using ContactBook.Domain.Persons;

namespace AddressBook.Application.Profiles.UploadProfilePicture;

internal sealed class UploadProfilePictureCommandHandler : ICommandHandler<UploadProfilePictureCommand, ProfileResponse>
{
    private readonly IFileStorageService _fileStorage;
    private readonly IProfileRepository _profileRepository;
    private readonly IUnitOfwork _unitOfwork;

    public UploadProfilePictureCommandHandler(IFileStorageService fileStorage,
        IProfileRepository profileRepository, IUnitOfwork unitOfwork)
    {
        _fileStorage = fileStorage;
        _profileRepository = profileRepository;
        _unitOfwork = unitOfwork;
    }
    public async Task<Result<ProfileResponse>> Handle(UploadProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileRepository.GetByEmailAsync(request.Email);
        if (profile == null) 
        {
            return Result.Failure<ProfileResponse>(ProfileErrors.NotFound); 
        }

        var uploadUrl = await _fileStorage.SaveFileAsync(request.file, "uploads", profile.Id);
        profile.UpdateImageUrl(uploadUrl);

        await _unitOfwork.SaveChangesAsync(cancellationToken);

        return Result.Success(ProfileResponse(profile));
    }

    private ProfileResponse ProfileResponse(Profile profile)
    {
        return new ProfileResponse
        {
            Id = profile.Id,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Email = profile.Email,
            Description = profile.Description,
            Cellphone = profile.Cellphone,
            Website = profile.Website,
            ImageUrl = profile.ImageUrl,
        };
    }
}
