using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PropertyAdministration.Core;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;

namespace Infrastructure.Repositories
{
   public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDBContext _appDbContext;

        public CategoryRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IEnumerable<Category> GetAll => _appDbContext.Categories;
    }
}
