﻿using System;

namespace Application.CQRS.Commands.Employee.CreateEmployee
{
    internal class CreateEmployeeCommandDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Int16 Role { get; set; }
    }
}