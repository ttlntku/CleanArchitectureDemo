using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext _dataContext) : base(_dataContext) { }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployeeByLastName(string lastName)
        {
            return await _dataContext.Employees.Where(m => m.LastName == lastName).ToListAsync();
        }
    }
}
