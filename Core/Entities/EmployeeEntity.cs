﻿using Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Int16 Role { get; set; }
        public virtual ICollection<FactoryEntity> Factories { get; set; }
    }
}
