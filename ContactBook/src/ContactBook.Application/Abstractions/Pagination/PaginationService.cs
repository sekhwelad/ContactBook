using AddressBook.Application.Abstractions.Data;
using Dapper;
namespace AddressBook.Application.Abstractions.Pagination;

public class PaginationService<T>
{
    private readonly ISqlConnectionFactory _connectionFactory;
    private readonly string _table;
    private readonly string _orderBy;

    public int PageSize { get; }
    public int CurrentPage { get; private set; } = 1;
    public int TotalCount { get; private set; }

    public PaginationService(ISqlConnectionFactory sqlConnectionFactory)
    {
        _connectionFactory = sqlConnectionFactory;
    }

    public async Task<int> GetTotalCountAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        var sql = $"SELECT COUNT(*) FROM {_table}";
        await connection.ExecuteScalarAsync<int>(sql);
        return await connection.ExecuteScalarAsync<int>(sql);
    }

    public async Task<PagedResult<T>> GetPageAsync(
       string tableName,
       string orderBy,
       int pageSize,
       int pageNumber)
    {
        var offset = (pageNumber - 1) * pageSize;

        var sqlData = $@"
        SELECT * FROM {tableName}
        ORDER BY {orderBy}
        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

        var sqlCount = $"SELECT COUNT(*) FROM {tableName}";

        using var connection = _connectionFactory.CreateConnection();

        var items = await connection.QueryAsync<T>(sqlData, new { Offset = offset, PageSize = pageSize });
        var count = await connection.ExecuteScalarAsync<int>(sqlCount);

        return new PagedResult<T>
        {
            Items = items.ToList(),
            TotalCount = count,
            PageSize = pageSize,
            PageNumber = pageNumber
        };
    }
}
