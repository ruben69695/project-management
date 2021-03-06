﻿using System.Collections.Generic;
using Models;
using Services.Helpers.Interfaces;

namespace Services.Interfaces
{
    public interface ICompanyService : IMainService<Company>
    {
        Company GetByCif(string cif);
        IEnumerable<Company> GetByName(string name);
    }
}
