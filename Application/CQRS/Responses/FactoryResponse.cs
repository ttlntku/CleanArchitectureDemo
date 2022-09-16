using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.CQRS.Responses
{
    public class FactoryResponse
    {
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
        public List<EmployeeParam> Employees { get; set; }
    }

    public class EmployeeParam
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Int16 Role { get; set; }
    }
}
