﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.CQRS.Responses
{
    public class EmployeeResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Int16 Role { get; set; }
        public List<FactoryParam> Factories { get; set; }
    }

    public class FactoryParam
    {
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
    }
}
