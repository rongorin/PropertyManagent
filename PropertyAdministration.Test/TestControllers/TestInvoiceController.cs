
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Controllers;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using PropertyAdministration.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Test.TestControllers
{
    [TestClass]
    public class TestInvoiceController
    {

        private Mock<IMemoryCache> mockMemoryCache;
        private Mock<ILogger<InvoiceController>> mockLogger;
        private Mock<IConfiguration> mockConfig;
        private Mock<IHouseService> mockHouseService;
        private Mock<IInvoiceService> mockInvoiceService;
        InvoiceController _controller;
        [TestInitialize]
        public void TestInitialize()
        {
            mockHouseService = new Mock<IHouseService>();
            mockInvoiceService = new Mock<IInvoiceService>();
            mockConfig = new Mock<IConfiguration>();
            mockMemoryCache = new Mock<IMemoryCache>();
            mockLogger = new Mock<ILogger<InvoiceController>>();

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["setupTempData"] = "admin";

            _controller = new InvoiceController(mockInvoiceService.Object,
                                                            mockHouseService.Object,
                                                            mockLogger.Object,
                                                            mockConfig.Object)
                {
                    TempData = tempData  //pass in temp data
                };
        }

        [TestMethod]
        public void Index_InvoiceListing_ReturnsViewResult()
        {
            //arrange
            mockInvoiceService.Setup(s => s.GetAll()).Returns(new List<Invoice>() );

            //act
           var res = _controller.Index(null);

            //ass
            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }
        [TestMethod]
        public void Index_InvoiceListingForSpecifiHouse_ReturnsViewResultAndModel()
        {
            //arrange

            List<Invoice> invoices = new List<Invoice>();
            invoices.Add(new Invoice() { Amount=1, Description="test",HouseId=1, InvoiceId=1});

            mockInvoiceService.Setup(s => s.GetAll()).Returns(invoices);
            mockHouseService.Setup(s => s.GetById(It.IsAny<int>())).Returns(new HouseViewModel());
            
            //act
            var res = _controller.Index(1);

            //ass
            Assert.IsInstanceOfType(res, typeof(ViewResult));
            var resultView =  (ViewResult) res;
            var invoiceViewModel = resultView.ViewData.Model;
            Assert.IsNotNull(invoiceViewModel);
        }
        [TestMethod]
        public void BulkCreate_PostedInvoicesToSave_SuccessfulRedirectToRoute()
        {
            //arrange
            var invoices = new List<CreateBulkInvoiceViewModel>();

            mockInvoiceService.Setup(s => s.BulkCreate(It.IsAny<List<CreateBulkInvoiceViewModel>>())).Returns(1);

            //act
            var result = (RedirectToActionResult)  _controller.BulkCreate(invoices); 

            //ass
            Assert.AreEqual("BulkMain", result.ActionName);  //ensure redirect successfully to this route
             
        }
    } 

} 
