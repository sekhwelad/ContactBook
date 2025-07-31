using AddressBook.Application.Profiles.AddProfile;
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
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateProfile(CreateProfileRequest request, CancellationToken cancellationToken)
        {
            var command = new AddProfileCommand(
                request.FirstName,
                request.LastName,
                request.Description,
                request.Email,
                request.Cellphone,
                request.Website);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }





    }
}
