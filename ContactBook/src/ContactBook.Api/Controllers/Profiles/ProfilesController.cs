using AddressBook.Application.Profiles.AddProfile;
using AddressBook.Application.Profiles.GetProfile;
using AddressBook.Application.Profiles.UploadProfilePicture;
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
            var query = new GetProfileQuery(PageSize, PageNumber);

            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProfile(CreateProfileRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateProfileCommand(
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

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] UploadProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var command = new UploadProfilePictureCommand(
                    request.file,
                    request.Email
                );

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);

        }
    }
}
