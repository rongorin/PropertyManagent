using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Core.Mocking
{
    public class MockHouseRepository : IHouseRepository
    {
        
        private readonly ICategoryRepository _categoryRepo   = new MockCategoryRepository();


        public IEnumerable<House> GetAll =>
            new List<House>
            { 
                  new House { HouseId = 2, StreetName = "Whittle Way", StreetNumber = 3, Description = "Ok house", ERF = "123",
                            Category = _categoryRepo.GetAll.ToList()[0],
                            DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=0 },
                  new House { HouseId = 3, StreetName = "Jan Smuts", StreetNumber = 22, Description = "fine", ERF = "444",
                            Category = _categoryRepo.GetAll.ToList()[1],
                            DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=0 },
                  new House { HouseId = 4, StreetName = "Jan Smuts", StreetNumber= 1, Description = "soso house", ERF = "4421",
                            Category = _categoryRepo.GetAll.ToList()[2],
                            DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=0 },

                 };



        //public IEnumerable<House> GetAll => 
        //      new List<House>
        //    {
        //        new House { HouseId = 1, StreetName = "1 Whittle Way", Description = "Nice house", ERF = "2222",

        //                    Category =  new Category { CategoryId=1, CategoryName="aabbcc"} ,  //  _categoryRepo.GetAll.ToList()[1],

        //                    DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=0
        //        }
        //    }; 

        public House GetById(int houseId)
        {
            return GetAll.FirstOrDefault(p => p.HouseId == houseId);
        }
    }

}
