using AddressBook.Application.Profiles.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Api.Controllers.Profiles
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly ISender _sender;

        public ProfilesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile(string Email, CancellationToken cancellationToken)
        {
            var query = new GetProfileQuery(Email);

            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }

    }
}
