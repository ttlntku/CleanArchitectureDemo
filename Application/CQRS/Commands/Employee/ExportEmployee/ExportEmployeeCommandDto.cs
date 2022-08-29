using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Employee.ExportEmployee
{
    internal class ExportEmployeeCommandDto
    {
        public Int16 PrintType { get; set; }
    }
}
