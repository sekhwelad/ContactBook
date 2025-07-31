namespace ContactBook.Application.Profiles.GetProfile;

public sealed class ProfileResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string Cellphone { get; set; }
    public string Website { get; set; }
    public string ImageUrl { get; set; }
}
