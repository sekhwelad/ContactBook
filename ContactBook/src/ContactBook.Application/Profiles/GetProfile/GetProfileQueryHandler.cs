using AddressBook.Application.Abstractions.Data;
using AddressBook.Application.Abstractions.Messaging;
using AddressBook.Application.Abstractions.Pagination;
using AddressBook.Domain.Profiles;
using ContactBook.Application.Profiles.GetProfile;
using ContactBook.Domain.Abstractions;
using ContactBook.Domain.Persons;

namespace AddressBook.Application.Profiles.GetProfile;

internal class GetProfileQueryHandler
    : IQueryHandler<GetProfileQuery, PagedResult<ProfileResponse>>
{
    private readonly ISqlConnectionFactory _connectionFactory;
    private readonly IProfileRepository _profileRepository;
    private readonly PaginationService<ProfileResponse> _paginationService;

    public GetProfileQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IProfileRepository profileRepository,
        PaginationService<ProfileResponse> paginationService)
    {
        _connectionFactory = sqlConnectionFactory;
        _profileRepository = profileRepository;
        _paginationService = paginationService;
    }

    public async Task<Result<PagedResult<ProfileResponse>>> Handle(
        GetProfileQuery request,
        CancellationToken cancellationToken)
    {
        var pagedResult = await _paginationService.GetPageAsync(
            tableName: nameof(Profile),
            orderBy: "FirstName DESC",
            pageSize: request.PageSize,
            pageNumber: request.PageNumber);

        if (!pagedResult.Items.Any())
        {
            return Result.Failure<PagedResult<ProfileResponse>>(ProfileErrors.NotFound);
        }

        return Result.Success(pagedResult);
    }
}
