using ContactBook.Domain.Abstractions;
using MediatR;

namespace AddressBook.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
       where TQuery : IQuery<TResponse>
{
}