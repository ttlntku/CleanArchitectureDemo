using Core.Entities;
using Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IEmployeeRepository: IRepository<EmployeeEntity>
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployeeByLastName(string lastName);
    }
}
