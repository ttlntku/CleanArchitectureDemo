using Employee.Application.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Persistence
{
    public class PersistenceFactory : IPersistenceFactory
    {
        public JWTConfig JWTConfig { get; set; }

        public PersistenceFactory(JWTConfig jwtConfig)
        {
            JWTConfig = jwtConfig;
        }

        public IJWTConfig GetJWTConfig()
        {
            return JWTConfig;
        }
    }
}
