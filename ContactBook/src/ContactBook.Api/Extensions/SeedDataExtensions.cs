using AddressBook.Application.Abstractions.Data;
using Bogus;
using ContactBook.Domain.Persons;
using Dapper;

namespace AddressBook.Api.Extensions;

public static class SeedDataExtensions
{
    public async static void SeedData(this IApplicationBuilder app, int count = 10)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var personFaker = new Faker<Profile>()
      .RuleFor(p => p.Id, f => Guid.NewGuid())
      .RuleFor(p => p.FirstName, f => f.Name.FirstName())
      .RuleFor(p => p.LastName, f => f.Name.LastName())
      .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName))
      .RuleFor(p => p.Cellphone, f => f.Phone.PhoneNumber())
      .RuleFor(p => p.Description, f => f.Lorem.Sentence())
      .RuleFor(p => p.ImageUrl, f => f.Internet.Avatar())
      .RuleFor(p => p.Website, (f, p) => $"{p.FirstName}{p.LastName}.co.za".ToLower())
      .RuleFor(p => p.CreatedDate, f => f.Date.Between(DateTime.UtcNow.Date, DateTime.UtcNow));

        var people = personFaker.Generate(count);

        const string sql = """
            INSERT INTO Profile
            (id, firstname, lastname, description, email, cellphone, website, imageurl, createdDate)
            VALUES(@Id, @FirstName, @LastName, @Description, @Email, @Cellphone, @Website, @ImageUrl, @CreatedDate)
        """;

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();
        await connection.ExecuteAsync(sql, people);
    }
}

