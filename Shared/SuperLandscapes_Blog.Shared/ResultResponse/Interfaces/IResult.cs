﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLandscapes_Blog.Shared.ResultResponse.Interfaces
{
    public interface IResult<TEntity>
    {
        TEntity Entity { get; set; }

        string Message { get; set; }
        
        bool Succeeded { get; set; }

        int StatusCode { get; set; }
    }
}
