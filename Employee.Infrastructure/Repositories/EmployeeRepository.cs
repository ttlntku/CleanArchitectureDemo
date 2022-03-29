﻿using Employee.Core.Repositories;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee.Core.Entities.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext employeeContext) : base(employeeContext) { }

        public async Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastName)
        {
            return await _employeeContext.Employees.Where(m => m.LastName == lastName).ToListAsync();
        }
    }
}
