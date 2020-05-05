using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using PropertyAdministration.Core.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PropertyAdministration.Test.TestServices
{
    [TestClass]
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
            var houses = RepoMocks.RepositoryMocks.RepositoryHouseList().ToList();// get some data 

            mockHouseRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(houses[0]) ;

            //act 
            HouseViewModel result = service.GetById(2);

            //assert 
            mockHouseRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(2, result.HouseId);

        }
        [TestMethod]
        public void EditHouse_ReturnsVoid_RecordEditSuccesful()
        {
            //arrange
            var house  = RepoMocks.RepositoryMocks.RepositoryHouseList();// get some data

            var categories = RepoMocks.RepositoryMocks.RepositoryCategoryList();

            HouseViewModel houseViewModel = new HouseViewModel()
            {
                HouseId = house[0].HouseId,
                OwnerId = house[0].OwnerId,
                StreetName = "New Street Name",
                StreetNumber = house[0].StreetNumber,
                Description = house[0].Description,
                DateMoveIn = house[0].DateMoveIn,
                IsPlot = house[0].IsPlot,
                CategoryId = house[0].CategoryId,
                ERF = house[0].ERF
            }; 
       
            mockHouseRepository.Setup(repo => repo.Edit(It.IsAny<House>())); 

            //act 
            service.Edit(houseViewModel);

            //assert 
            mockHouseRepository.VerifyAll();

            //Assert.AreEqual("hello_test", houseViewModel.HouseId);

            //mockHouseRepository.Verify(x => x.Edit(house[0]));
        }

        [TestCleanup]
        public void Teardown()
        {
            service = null;
        }
    }
}
