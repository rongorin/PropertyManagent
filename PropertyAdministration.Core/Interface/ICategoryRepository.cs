using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface ICategoryRepository
    {
       IEnumerable<Category> GetAll { get; }

    }
}
