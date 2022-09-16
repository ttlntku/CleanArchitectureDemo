using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FactoryEntity : BaseEntity
    {
        public string FactoryName { get; set; }
        public string FactoryAddress { get; set; }
        public virtual ICollection<EmployeeEntity> Employees { get; set; }
    }
}
