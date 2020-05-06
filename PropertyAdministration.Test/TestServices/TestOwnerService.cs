using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using PropertyAdministration.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Test.TestServices
{
    [TestClass]

    public class TestOwnerService
    {
        private Mock<IHouseRepository> mockHouseRepository;
        private Mock<IOwnerRepository> mockOwnerRepository;

        private OwnerService service;

        [TestInitialize]
        public void TestInitialize()
        {

            mockHouseRepository = new Mock<IHouseRepository>();
            mockOwnerRepository = new Mock<IOwnerRepository>();

            service = new OwnerService(mockOwnerRepository.Object, mockHouseRepository.Object);

        }
        [TestMethod]
        public void Index_NoRecordsFound_ListShouldBeEmpty()
        {
            //arrange 
            var owners = RepoMocks.RepositoryMocks.FakeOwnersList();// get some data 


                 //mockOwnerRepository.Setup(repo => repo.GetAll).Returns(owners);

            var results = service.GetAll();

            //assert  
            Assert.IsTrue(results.ToList().Count() == 0);  

        }
        [TestMethod]
        public void Index_ReturnsValid_List()
        {
            //arrange 
            var owners = RepoMocks.RepositoryMocks.FakeOwnersList();// get some data 


            mockOwnerRepository.Setup(repo => repo.GetAll).Returns(owners);

            var results = service.GetAll();

            //assert 
              
            CollectionAssert.AllItemsAreNotNull(results.ToList());

            mockOwnerRepository.VerifyAll();

        }
        [TestMethod] 
        public void GetById_ExpectARecord_ReturnsRecordPopulatedView()
        {
            //arrange 
            var owners = RepoMocks.RepositoryMocks.FakeOwnersList();// get some data  

            mockOwnerRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Owner { OwnerId=1, FullName = "fullname test"});

            var results = service.GetById(1);

            //assert  
            Assert.IsInstanceOfType(results, typeof(OwnerViewModel));
            Assert.IsTrue(results.OwnerId == 1);
                
        }
        [TestMethod]
        public void Edit_MethodIsRun_RunsOkVoid()  /// Tests the Edit method is run
        {
            //arrange  
            Owner owner  = new Owner();
            mockOwnerRepository.Setup(repo => repo.Edit(It.IsAny<Owner>())); 

            //act
            OwnerEditViewModel ownerVm = new OwnerEditViewModel( );
            ownerVm.Owner = new OwnerViewModel { OwnerId =1,  EmailAddress = "", PhoneNumber = "", Title = "A", FullName = "RG", PropertiesOwned = 1  }; 

            service.Edit(ownerVm);
             
            //assert 
            mockOwnerRepository.VerifyAll();

        }
        [TestMethod]
        public void Create_MethodIsRun_RunsOkVoid()  /// Tests the Edit method is run
        {
            //arrange     
            Owner owner = new Owner();
            mockOwnerRepository.Setup(repo => repo.Edit(It.IsAny<Owner>()));

            //act
            OwnerEditViewModel ownerVm = new OwnerEditViewModel();
            ownerVm.Owner = new OwnerViewModel { OwnerId = 1, EmailAddress = "", PhoneNumber = "", Title = "A", FullName = "RG", PropertiesOwned = 1 };

            service.Create(ownerVm);

            //assert  

            mockOwnerRepository.VerifyAll();

        }
        
        [TestCleanup]
        public void Teardown()
        {
            service = null;
        }
    }
}
