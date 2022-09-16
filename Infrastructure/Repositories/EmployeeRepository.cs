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

        public async Task<EmployeeEntity> GetEmployeeByEmailAndPassword(string email, string password)
        {
            return await _dataContext.Employees.Where(m => m.Email == email && m.Password == password).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployeeByLastName(string lastName)
        {
            return await _dataContext.Employees.Where(m => m.LastName == lastName).ToListAsync();
        }

        public async Task<EmployeeEntity> GetByIdAsync(int id)
        {
            return await _dataContext.Employees.Include(e => e.Factories).AsNoTracking().FirstOrDefaultAsync(s => s.Id.Equals(id));
        }
    }
}
