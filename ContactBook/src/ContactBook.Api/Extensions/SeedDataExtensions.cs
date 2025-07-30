using AddressBook.Application.Abstractions.Data;
using Bogus;
using Dapper;

namespace AddressBook.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> profiles = new();

        for (int x= 0; x<10; x++)
        {
            profiles.Add(
                new
                {
                    Id = Guid.NewGuid(),
                    FirstName = faker.Person.FirstName,
                    LastName = faker.Person.LastName,
                    Description = "I am just another person",
                    Email = faker.Person.Email,
                    Cellphone = faker.Person.Phone,
                    Website = $"{faker.Person.FullName}.co.za",
                    ImageUrl = faker.Internet.Avatar()
                });
        }

        const string sql = """
            INSERT INTO Profile
            (id,firstname,lastname,description,email,cellphone,website,imageurl)
            VALUES(@Id,@FirstName,@LastName,@Description,@Email,@Cellphone ,@Website, @ImageUrl)
            """;

        connection.Execute(sql, profiles);
    }
}

