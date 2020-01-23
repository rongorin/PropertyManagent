﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PropertyAdministration.Core.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Fruit Houses"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Cheese cakes"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Seasonal Houses"
                        });
                });

            modelBuilder.Entity("PropertyAdministration.Core.Model.House", b =>
                {
                    b.Property<int>("HouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMoveIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ERF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPlot")
                        .HasColumnType("bit");

                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("HouseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            HouseId = 1,
                            CategoryId = 1,
                            DateMoveIn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006),
                            Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                            ERF = "dd55da",
                            IsPlot = false,
                            OwnersId = 1,
                            StreetName = "Whittle Way",
                            StreetNumber = 11
                        },
                        new
                        {
                            HouseId = 2,
                            CategoryId = 1,
                            DateMoveIn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                            ERF = "6662222",
                            IsPlot = false,
                            OwnersId = 1,
                            StreetName = "JanSmuts Ave",
                            StreetNumber = 121
                        },
                        new
                        {
                            HouseId = 3,
                            CategoryId = 2,
                            DateMoveIn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006),
                            Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                            ERF = "663333",
                            IsPlot = false,
                            OwnersId = 2,
                            StreetName = "Colebrook Cls",
                            StreetNumber = 3
                        },
                        new
                        {
                            HouseId = 4,
                            CategoryId = 2,
                            DateMoveIn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006),
                            Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                            ERF = "1255a",
                            IsPlot = false,
                            OwnersId = 3,
                            StreetName = "Whittle Way",
                            StreetNumber = 31
                        },
                        new
                        {
                            HouseId = 5,
                            CategoryId = 1,
                            DateMoveIn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2006),
                            Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake House chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon House muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart House cake danish lemon drops. Brownie cupcake dragée gummies.",
                            ERF = "64332",
                            IsPlot = false,
                            OwnersId = 2,
                            StreetName = "Whittle Way",
                            StreetNumber = 4
                        });
                });

            modelBuilder.Entity("PropertyAdministration.Core.Model.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DatePaid")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("PropertyAdministration.Core.Model.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            OwnerId = 1,
                            EmailAddress = "aaa@gmail.com",
                            FullName = "S D Jone",
                            PhoneNumber = "3342423"
                        },
                        new
                        {
                            OwnerId = 2,
                            EmailAddress = "SDSSSSaa@gmail.com",
                            FullName = "J Jonaronw",
                            PhoneNumber = "3342423"
                        },
                        new
                        {
                            OwnerId = 3,
                            EmailAddress = "sdsA@gmail.com",
                            FullName = "E Foeinf",
                            PhoneNumber = "3342423"
                        });
                });

            modelBuilder.Entity("PropertyAdministration.Core.Model.House", b =>
                {
                    b.HasOne("PropertyAdministration.Core.Model.Category", "Category")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
