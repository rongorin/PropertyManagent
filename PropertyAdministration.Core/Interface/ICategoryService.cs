using PropertyAdministration.Application.AppModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface ICategoryService
    {
          IEnumerable<CategoryViewModel> GetAll();
    }
}
