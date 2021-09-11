﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServiceManager
    {
        IPeopleService PeopleService { get; }

        ICategoryService CategoryService { get; }

        IProductService ProductService { get; }
    }
}
