using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using API.GlobalConstants;
using API.Helpers.ApiResponse;
using Application.CQRS.Queries;
using Application.CQRS.Commands.Employee.CreateEmployee;
using Application.CQRS.Commands.Employee.UpdateEmployee;
using Application.CQRS.Commands.Employee.DeleteEmployee;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using Application.Delegates;
using Core.Entities;
using Application.CQRS.Responses;
using System.Linq;
using Application.CQRS.Commands.Employee.ExportEmployee;
using System;
using Application.Constants;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IHostingEnvironment _hostingEnvironment;
        public EmployeeController(IMediator mediator, IHostingEnvironment hostingEnvironment)
        {
            _mediator = mediator;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        //[Authorize(Roles = EmployeeRole.ROLE_ADMIN_NAME)]
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
                var userName = HttpContext.User.Identity.Name;
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

        [HttpGet("export")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Export(Constant.EnumPrint printType)
        {
            var memoryStream = await _mediator.Send(new ExportEmployeeCommand(printType));

            return File(
                fileContents: memoryStream.ToArray(),
                contentType: Constant.GetEnumDescription(printType),
                fileDownloadName: DateTime.Now.ToString());
        }

        [HttpGet]
        [Route("export3")]
        public async Task<ActionResult> DownloadFile()
        {
            string Files = "Files/Danh sách Xe 2 - Ecopark 04June.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Files);
            await System.IO.File.WriteAllBytesAsync(Files, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "employee.xlsx");
        }

        [HttpGet("export4")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Export()
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                // Set author for excel file
                package.Workbook.Properties.Author = "Aspodel";
                // Set title for excel file
                package.Workbook.Properties.Title = "Employee List";
                // Add comment to excel file
                package.Workbook.Properties.Comments = "Hello (^_^)";
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                worksheet.Cells[1, 1].Value = "No";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Last Name";
                //worksheet.Cells[1, 4].Value = "Salary";

                // Style for Excel 
                worksheet.DefaultColWidth = 16;
                worksheet.Cells.Style.Font.Size = 16;


                //Export Data from Table employees
                worksheet.Cells[1 + 2, 1].Value = 1 + 1;
                worksheet.Cells[1 + 2, 2].Value = "item.FirstName";
                worksheet.Cells[1 + 2, 3].Value = "item.LastName";
                //worksheet.Cells[i + 2, 4].Value = item.Salary;

                fileContents = package.GetAsByteArray();
            }

            if (fileContents == null || fileContents.Length == 0)
            {
                return NoContent();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Employees.xlsx");
        }
    }
}
