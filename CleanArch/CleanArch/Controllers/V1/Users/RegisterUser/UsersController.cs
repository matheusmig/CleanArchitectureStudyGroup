using Application.Services;
using Application.UseCases.RegisterUser;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers.V1.Users.RegisterUser
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        void IOutputPort.Ok(User user)
        {
            _viewModel = Ok(new RegisterUserResponse(new UserViewModel(user)));
        }

        void IOutputPort.Invalid(Notification notification)
        {
            var problemDetails = new ValidationProblemDetails(notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterUserResponse))]
        public async Task<IActionResult> RegisterAsync(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RegisterUserRequest request)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(request.Name, request.Birthdate.Value).ConfigureAwait(false);

            return _viewModel;
        }
    }
}
