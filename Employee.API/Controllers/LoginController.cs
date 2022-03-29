using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Employee.API.Helpers;
using Employee.API.GlobalConstants;
using Microsoft.Extensions.Logging;
using Employee.Application.CQRS.Queries;
using Employee.Application.CQRS.Commands;
using Employee.Application.CQRS.Commands.CreateEmployee;
using Employee.Application.CQRS.Commands.UpdateEmployee;
using Employee.Application.CQRS.Commands.DeleteEmployee;
using Employee.Application.CQRS.Commands.LoginEmployee;
using Microsoft.AspNetCore.Authorization;

namespace Employee.API.Controllers
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
        public async Task<CustomApiResponse> Post([FromBody] LoginEmployeeCommand loginEmployeeCommand)
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
