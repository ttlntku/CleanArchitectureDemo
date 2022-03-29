using Employee.Application.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Persistence
{
    public interface IPersistenceFactory
    {
        IJWTConfig GetJWTConfig();
    }
}
