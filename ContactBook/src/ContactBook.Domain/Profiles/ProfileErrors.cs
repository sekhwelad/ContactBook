using ContactBook.Domain.Abstractions;

namespace AddressBook.Domain.Profiles;

public static class ProfileErrors
{
    public static Error NotFound = new(
          "Profile.Found",
          "The profile with the specified email was not found"
          );
    public static Error OutOfRange = new(
          "Profile.OutOfRange",
          "There are no more profiles for specified pages"
          );
}
