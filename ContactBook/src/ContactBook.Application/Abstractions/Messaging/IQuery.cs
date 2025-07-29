using ContactBook.Domain.Abstractions;
using MediatR;

namespace AddressBook.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}