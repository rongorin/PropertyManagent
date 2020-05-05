using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Core.Services
{
    public class CategoryService : ICategoryService
    { 

        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var res = _categoryRepository.GetAll
                   .ToList()
                   .Select(a => new CategoryViewModel
                   { 
                        CategoryId = a.CategoryId,
                        CategoryName = a.CategoryName 
                   });

            return res;
        } 
    } 
    
}
