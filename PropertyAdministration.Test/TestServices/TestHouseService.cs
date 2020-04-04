using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using PropertyAdministration.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using PropertyAdministration.Core.Model;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PropertyAdministration.Test.TestServices
{
    public class TestHouseService
    {
        
        private Mock<ICategoryRepository> mockCategoryRepository;
        private Mock<IHouseRepository> mockHouseRepository;

        private HouseService service;

        [TestInitialize]
        public void TestInitialize()
        { 

            mockCategoryRepository = new Mock<ICategoryRepository>();
            mockHouseRepository = new Mock<IHouseRepository>();

            service = new HouseService(mockHouseRepository.Object, mockCategoryRepository.Object);

        }
        //MethodName_StateUnderTest_ExpectedBehavior - ie:admitStudent_MissingMandatoryFields_FailToAdmit
        [TestMethod]
        public void GetById_ReturnsValid_HouseDetails()
        {
            //arrange
            var house = RepoMocks.RepositoryMocks.RepositoryHouseList();

            mockHouseRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(house[0]);
            //act 
            var result = service.GetById(101);

            //assert 
            mockHouseRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);

        }
        [TestMethod]
        public void EditHouse_ReturnsVoid_RecordEditSuccesful()
        {
            //arrange
            var house = RepoMocks.RepositoryMocks.RepositoryHouseList();
            var categories = RepoMocks.RepositoryMocks.RepositoryCategoryList();

            HouseViewModel houseViewModel = new HouseViewModel()
            {
                HouseId = house[0].HouseId,
                OwnerId = house[0].OwnerId,
                StreetName = house[0].StreetName,
                StreetNumber = house[0].StreetNumber,
                Description = house[0].Description,
                DateMoveIn = house[0].DateMoveIn,
                IsPlot = house[0].IsPlot,
                CategoryId = house[0].CategoryId,
                ERF = house[0].ERF
            };

            var houseEditViewModel = new HouseEditViewModel
            {
                House = houseViewModel,
                CategoryId = categories.FirstOrDefault().CategoryId,
                Categories = categories.Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList()
            };
            mockHouseRepository.Setup(repo => repo.Edit(It.IsAny<House>()));

            //act 
             service.Edit(houseViewModel);

            //assert 
            mockHouseRepository.Verify(x => x.Edit(house[0]), Times.Once);
        }
        }
    }
