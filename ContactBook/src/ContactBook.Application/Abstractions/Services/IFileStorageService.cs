using Microsoft.AspNetCore.Http;

namespace AddressBook.Application.Abstractions.Services;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(IFormFile file, string folder, Guid id);
}
