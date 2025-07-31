using AddressBook.Application.Abstractions.Behaviors;
using AddressBook.Application.Abstractions.Pagination;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddTransient(typeof(PaginationService<>));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        return services;
    }
}
