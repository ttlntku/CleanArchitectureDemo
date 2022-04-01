using Core.Entities.Base;
using System;

namespace Core.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public EmployeeEntity(string createdBy, string updatedBy) : base(createdBy, updatedBy) { }
        public EmployeeEntity(string updatedBy) : base(updatedBy) { }
        public EmployeeEntity() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Int16 Role { get; set; }
    }
}
