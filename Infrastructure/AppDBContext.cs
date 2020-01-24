using Microsoft.EntityFrameworkCore;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
         : base(options)
        {
        }

        public DbSet<House> Houses { get; set; } 

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "ÖwnerOccupied", Description = "Full time owner occupied" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Swallow", Description = "Occupied but usually away overseas" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Tenanted", Description = "Tenants staying" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Vacant", Description = "House is empty" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Plot", Description = "Just a plot of land" });

            modelBuilder.Entity<Owner>().HasData(new Owner { OwnerId = 1, FullName = "S D Jone", EmailAddress = "aaa@gmail.com",PhoneNumber= "3342423"}); 
            modelBuilder.Entity<Owner>().HasData(new Owner { OwnerId = 2, FullName = "J Jonaronw", EmailAddress = "SDSSSSaa@gmail.com", PhoneNumber= "3342423"}); 
            modelBuilder.Entity<Owner>().HasData(new Owner { OwnerId = 3, FullName = "E Foeinf", EmailAddress = "sdsA@gmail.com", PhoneNumber= "3342423"});
 

            //seed Houses

            modelBuilder.Entity<House>().HasData(new House
            {
                HouseId = 1,
                DateMoveIn = new DateTime(2019 - 02 - 11),
                StreetNumber = 11,
                StreetName = "Whittle Way",
                ERF = "dd55da",
                //ShortDescription = "Our famous apple Houses!",
                Description =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                 IsPlot = false,
                 OwnersId = 1 
            }) ;

            modelBuilder.Entity<House>().HasData(new House
            {
                HouseId = 2,
                StreetNumber = 121,
                StreetName = "JanSmuts Ave",
                ERF = "6662222",
                //ShortDescription = "Our famous apple Houses!",
                Description =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                IsPlot = false,
                OwnersId = 1
            });

            modelBuilder.Entity<House>().HasData(new House
            {
                HouseId = 3,
                DateMoveIn = new DateTime(2019 - 02 - 11),
                StreetNumber = 3,
                StreetName = "Colebrook Cls",
                ERF = "663333",
                //ShortDescription = "Our famous apple Houses!",
                Description =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                IsPlot = false,
                OwnersId = 2
            });

            modelBuilder.Entity<House>().HasData(new House
            {
                HouseId = 4,
                DateMoveIn = new DateTime(2019 - 02 - 11),
                StreetNumber = 31,
                StreetName = "Whittle Way",
                ERF = "1255a",
                //ShortDescription = "Our famous apple Houses!",
                Description =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                IsPlot = false,
                OwnersId = 3
            });

            modelBuilder.Entity<House>().HasData(new House
            {
                HouseId = 5,
                DateMoveIn = new DateTime(2019 - 02 - 11),
                StreetNumber = 4,
                StreetName = "Whittle Way",
                ERF = "64332",
                //ShortDescription = "Our famous apple Houses!",
                Description =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                IsPlot = false,
                OwnersId =2
            });
              
        }
    }
 
}
