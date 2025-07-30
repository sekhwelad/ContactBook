using AddressBook.Application.Profiles.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Api.Controllers.Profiles
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/profiles")]
    public class ProfilesController : ControllerBase
    {
        private readonly ISender _sender;

        public ProfilesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile(int PageSize, int PageNumber, CancellationToken cancellationToken)
        {
            var query = new GetProfileQuery(PageSize,PageNumber);

            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }

    }
}
