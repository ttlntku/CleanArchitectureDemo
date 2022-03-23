using Employee.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Employee.API.Helpers;
using Employee.Application.Commands;
using Employee.API.GlobalConstants;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CustomApiResponse> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetAllEmployeeQuery());

                if (result.Count <= 0)
                {
                    throw new ApiException(ConstantResponseMessage.EMPTY_LIST, StatusCodes.Status404NotFound);
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
