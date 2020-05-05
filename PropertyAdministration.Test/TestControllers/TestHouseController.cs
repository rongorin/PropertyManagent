using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using PropertyAdministration.Test.RepoMocks;
using PropertyAdministration.Core.Model;
using PropertyAdministration.Application.AppModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

namespace PropertyAdministration.Test.TestControllers
{
    [TestClass] 
    public class TestHouseController 
    {
        private Mock<ICategoryService> mockCategoryService;   
        private Mock<IHouseService> mockHouseService;
        private Mock<IMemoryCache> mockMemoryCache; 
        private Mock<IOwnerService> mockOwnerService;

        HouseController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            List<Category> categories = RepoMocks.RepositoryMocks.RepositoryCategoryList(); 

            mockCategoryService = new Mock<ICategoryService>();
    
            mockCategoryService.Setup(x => x.GetAll()).Returns(  new List<CategoryViewModel>() );
        
            mockHouseService = new Mock<IHouseService>();
            mockOwnerService = new Mock<IOwnerService>();
            mockMemoryCache = new Mock<IMemoryCache>() ;

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>()); 
            tempData["setupTempData"] = "admin"; 

            _controller  = new HouseController(mockHouseService.Object,
                                                            mockOwnerService.Object,
                                                            mockCategoryService.Object,
                                                            mockMemoryCache.Object)
                 { 
                    TempData = tempData  //pass in temp data
                };

            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.HttpContext.Request.Headers["x-requested-with"] = "AddInHeaderThisForTesting"; 

        }
        [TestMethod]
        public void Details_ListOfHouses_ReturnsList()
        {
            //arrange some data
            var fakeData = RepositoryMocks.GetFakeHomeIndexViewModel();
            mockHouseService.Setup(x => x.GetAll(It.IsAny<string>())).Returns(fakeData);

            //act
            var result = _controller.Index( );

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult)); 

        }

        [TestMethod]
        public void Details_ReturnsValidObject_Ok()
        {
            //act
            var result = _controller.Details(It.IsAny<int>() );

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_NoRecordExistsForGivenId_ReturnsNotFound()
        {
            //act
            var result = _controller.Details(-1);
            
            //assert 
            Assert.IsNotNull(result); 
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));

            var httpResult = (StatusCodeResult)result;
            Assert.AreEqual(404, httpResult.StatusCode);
        }
        [TestMethod]
        public void Details_RecordForId_ReturnsViewModel()
        {
            //arrange 
            var houseVM = RepositoryMocks.GetFakeHouseViewModel(); 
            mockHouseService.Setup(x => x.GetById(It.IsAny<int>())).Returns(houseVM) ;

            //act
            var result = _controller.Details(It.IsAny<int>());

            //assert 
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult)); 
   
            var resultView = (ViewResult)result; 
            var houseViewModel = (HouseViewModel)resultView.ViewData.Model;

            Assert.AreEqual(123, houseViewModel.OwnerId) ; 
        }
        [TestMethod]
        public void Edit_ReturnsValidObject_ReturnsAnObject()
        {
            //act
            var result = _controller.Edit(It.IsAny<HouseEditViewModel>());

            //assert
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void Edit_NoRecordExist_ReturnsNotFound()
        {
            //act
            var response = _controller.Edit(It.IsAny<HouseEditViewModel>());

            //assert 
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));

            //Assert.IsInstanceOfType(response, typeof(StatusCodeResult)); 
            //var httpResult = response as StatusCodeResult; 
            //Assert.AreEqual(404, httpResult.StatusCode); //NotFound
              
        }
      
        [TestMethod]
        public void Edit_SuccessfullEdit_ReturnsToDetailsPage()
        {
            //arrange
            var houseEditVM = RepositoryMocks.GetFakeHouseEditViewModel();
            
            //mockHouseService.Setup(x => x.GetById(It.IsAny<int>())).Returns(viewmodel) ;

           
            //act  
            var result = (RedirectToActionResult)_controller.Edit(houseEditVM);

            //assert
            Assert.AreEqual("Details", result.ActionName);
           

        }

    }
}
