using AddressBook.Application.Abstractions.Data;
using AddressBook.Application.Abstractions.Messaging;
using AddressBook.Domain.Profiles;
using ContactBook.Application.Profiles.GetProfile;
using ContactBook.Domain.Abstractions;
using Dapper;

namespace AddressBook.Application.Profiles.GetProfile;

internal class GetProfileQueryHandler
     : IQueryHandler<GetProfileQuery, IReadOnlyList<ProfileResponse>>
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public GetProfileQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _connectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<ProfileResponse>>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {

        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT email as Email FROM Profile LIMIT 1
            """;
        var profile = await connection.QueryFirstOrDefaultAsync<ProfileResponse>(sql);

        if (profile == null)
        {
            return Result.Failure<IReadOnlyList<ProfileResponse>>(ProfileErrors.NotFound);
        }

        return Result.Success<IReadOnlyList<ProfileResponse>>(new List<ProfileResponse> { profile });
    }
}
