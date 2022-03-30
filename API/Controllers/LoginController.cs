using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using API.GlobalConstants;
using API.Helpers.ApiResponse;
using Application.CQRS.Commands.Login;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CustomApiResponse> Post([FromBody] LoginCommand loginEmployeeCommand)
        {
            try
            {
                var result = await _mediator.Send(loginEmployeeCommand);

                if (result is null)
                {
                    return new CustomApiResponse(ConstantResponseMessage.FAIL, result, StatusCodes.Status404NotFound);
                }
                return new CustomApiResponse(ConstantResponseMessage.SUCCESS, result);
            }
            catch (System.Exception ex)
            {
                throw new ApiException(ex.ToString(), StatusCodes.Status500InternalServerError);
            }
        }
    }
}
