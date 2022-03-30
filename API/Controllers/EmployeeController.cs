using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using API.GlobalConstants;
using API.Helpers.ApiResponse;
using Application.CQRS.Queries;
using Application.CQRS.Commands.Employee.CreateEmployee;
using Application.CQRS.Commands.Employee.UpdateEmployee;
using Application.CQRS.Commands.Employee.DeleteEmployee;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
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
                    return new CustomApiResponse(ConstantResponseMessage.EMPTY_LIST, result, StatusCodes.Status404NotFound);
                }

                return new CustomApiResponse(ConstantResponseMessage.SUCCESS, result);
            }
            catch (System.Exception ex)
            {
                throw new ApiException(ex.ToString(), StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CustomApiResponse> Post([FromBody] CreateEmployeeCommand createEmployeeCommand)
        {
            try
            {
                var result = await _mediator.Send(createEmployeeCommand);

                if (result is null)
                {
                    return new CustomApiResponse(ConstantResponseMessage.FAIL, result, StatusCodes.Status400BadRequest);
                }
                return new CustomApiResponse(ConstantResponseMessage.SUCCESS, result);
            }
            catch (System.Exception ex)
            {
                throw new ApiException(ex.ToString(), StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CustomApiResponse> Put(int id, [FromBody] UpdateEmployeeCommand updateEmployeeCommand)
        {
            try
            {
                updateEmployeeCommand.Id = id;

                var result = await _mediator.Send(updateEmployeeCommand);

                if (result is null)
                {
                    return new CustomApiResponse(ConstantResponseMessage.FAIL, result, StatusCodes.Status400BadRequest);
                }
                return new CustomApiResponse(ConstantResponseMessage.SUCCESS, result);
            }
            catch (System.Exception ex)
            {
                throw new ApiException(ex.ToString(), StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CustomApiResponse> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteEmployeeCommand(id));

                if (!result)
                {
                    return new CustomApiResponse(ConstantResponseMessage.FAIL, result, StatusCodes.Status400BadRequest);
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
