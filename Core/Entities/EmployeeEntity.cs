﻿using Core.Entities.Base;
using System;

namespace Core.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public EmployeeEntity() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}