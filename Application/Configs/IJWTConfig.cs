﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configs
{
    public interface IJWTConfig : IDisposable
    {
        JWTConfig GetJWTConfig();
    }
}
