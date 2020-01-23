using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Mocking
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAll =>
                     new List <Category>

           {
                new Category{CategoryId=1, CategoryName="ÖwnerOccupied", Description="Full time owner occupied"},
                new Category{CategoryId=2, CategoryName="Swallow", Description="Occupied but usually away overseas"},
                new Category{CategoryId=3, CategoryName="Tenanted", Description="Tenants staying"},
                new Category{CategoryId=4, CategoryName="Vacant", Description="House is empty"},
                new Category{CategoryId=3, CategoryName="Plot", Description="Just a plot of land"}
           }; 
    }
         
 } 
