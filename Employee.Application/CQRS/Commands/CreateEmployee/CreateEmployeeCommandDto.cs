using System;

namespace Employee.Application.CQRS.Commands.CreateEmployee
{
    internal class CreateEmployeeCommandDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}