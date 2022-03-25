using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.CQRS.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandDto
    {
        public int Id { get; set; }
    }
}
