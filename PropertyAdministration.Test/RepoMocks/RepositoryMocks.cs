using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Test.RepoMocks
{
    public class RepositoryMocks
    {
        public static List<Invoice> RepositoryInvoiceList()
        {
            var invoices = new List<Invoice>
            {
                new Invoice()
                {    Amount = 1M,
                     Description ="my test invoicek",
                     HouseId = 101,
                     InvoiceDate = new DateTime(2020, 01, 01),
                     InvoiceId = 1,
                     IsPaid = false,
                     DatePaid = null,
                      

                },
                new Invoice()
                {    Amount = 1M,
                     Description ="my test invoice2",
                     HouseId = 202,
                     InvoiceDate = new DateTime(2020, 02, 02),
                     InvoiceId = 2,
                     IsPaid = false,
                     DatePaid = null,

                },
                new Invoice()
                {    Amount = 1M,
                     Description ="my test invoice3",
                     HouseId = 202,
                     InvoiceDate = new DateTime(2020, 03, 03),
                     InvoiceId = 3,
                     IsPaid = false,
                     DatePaid = null,

                },
                  new Invoice()
                {    Amount = 12M,
                     Description ="my test invoice4",
                     HouseId = 303,
                     InvoiceDate = new DateTime(2020, 03, 03),
                     InvoiceId = 4,
                     IsPaid = false,
                     DatePaid = null,

                }
             } ;
            return invoices  ;
        }
        public static List<Category> RepositoryCategoryList()
        {
            var categories = new List<Category>

           {
                new Category{CategoryId=1, CategoryName="ÖwnerOccupied", Description="Full time owner occupied"},
                new Category{CategoryId=2, CategoryName="Swallow", Description="Occupied but usually away overseas"},
                new Category{CategoryId=3, CategoryName="Tenanted", Description="Tenants staying"},
                new Category{CategoryId=4, CategoryName="Vacant", Description="House is empty"},
                new Category{CategoryId=3, CategoryName="Plot", Description="Just a plot of land"}
           };
            return categories;
        }
        public static Owner CreateOwnerRec()
        {
            return
                new Owner
                {
                    EmailAddress = "aaaa",
                    FullName = "A R Abe",
                    OwnerId = 1,
                    PhoneNumber = "22223",
                    Title = "MR",
                    PropertiesOwned = 2
                };

        }
        public static IList<House> RepositoryHouseList()
        {
            var house = new List<House>

           {
               new House { HouseId = 2, StreetName = "Whittle Way", StreetNumber = 3, Description = "Ok house", ERF = "123",
                            Category = RepositoryCategoryList().Find(x => x.CategoryId==1),
                            DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=1, CategoryId=1 ,Owner = CreateOwnerRec() },
                  new House { HouseId = 3, StreetName = "Jan Smuts", StreetNumber = 22, Description = "fine", ERF = "444",
                            Category = RepositoryCategoryList().Find(x => x.CategoryId==2),
                            DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=2, CategoryId=1 ,Owner = CreateOwnerRec()},
                  new House { HouseId = 4, StreetName = "Jan Smuts", StreetNumber= 1, Description = "soso house", ERF = "4421",
                            Category =  RepositoryCategoryList().Find(x => x.CategoryId==1),
                            DateMoveIn = DateTime.Now, IsPlot=false ,OwnerId=3 , CategoryId=1,Owner = CreateOwnerRec()},
           };
            return house;
        }
        public static List<Owner> FakeOwnersList()
        {
            var owner = new List<Owner>

           {
               new Owner { OwnerId = 1, EmailAddress="aaa@d.com", FullName="Abe Jonstone", PhoneNumber = "2233423", PropertiesOwned = 1,
                           Title = "Prof", Houses  =  RepositoryHouseList().ToList()  
               },
                  new Owner { OwnerId = 2, EmailAddress="xxxx@d.com", FullName="John Abrahamson", PhoneNumber = "555", PropertiesOwned = 1,
                           Title = "Prof", Houses  =  RepositoryHouseList().ToList()
               } 
                  
           };
            return owner.ToList(); 
        }
    }
}
