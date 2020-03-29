using Microsoft.VisualStudio.TestTools.UnitTesting; 
using PropertyAdministration.Core.Services;
using PropertyAdministration.Core.Model;
using System.Collections.Generic;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Test.RepoMocks;
using Moq;
using PropertyAdministration.Controllers;
using System;

namespace PropertyAdministration.Test.TestControllers

{
    [TestClass]
    public class TestInvoiceService
    {
         //private IInvoiceRepository InvoiceRepo = new InvoiceRepoTest();
         //private ICategoryRepository CategoryRepo = new CategoryRepoTest();
         //private IHouseRepository HouseRepo = new HouseRepoTest();

        private Mock<IInvoiceRepository> mockInvoiceRepository;
        private Mock<ICategoryRepository> mockCategoryRepository;
        private Mock<IHouseRepository> mockHouseRepository ;
          
        private InvoiceService invoiceService;

        [TestInitialize]
        public void TestInitialize()
        {
            var invoices = RepoMocks.RepositoryMocks.RepositoryInvoiceList();

              mockInvoiceRepository = new Mock<IInvoiceRepository>();
              mockCategoryRepository = new Mock<ICategoryRepository>();
              mockHouseRepository = new Mock<IHouseRepository>();

              invoiceService = new InvoiceService(mockInvoiceRepository.Object,
                                mockHouseRepository.Object,
                                mockCategoryRepository.Object);
             
        } 

        [TestMethod]
        public void GetAIvoicesForHouse_ReturnsValid_invoicesList()
        {
            //arrange
            IEnumerable<Invoice> invoices = RepoMocks.RepositoryMocks.RepositoryInvoiceList(); 
            mockInvoiceRepository.Setup(repo => repo.GetAllForHouse(It.IsAny<int>())).Returns(invoices); 
            //act 
            var result = invoiceService.GetAllForHouse(101);
         
            //assert 
            mockInvoiceRepository.Verify(x => x.GetAllForHouse(It.IsAny<int>()) , Times.Once); 
         
        } 
        [TestMethod]
        public void GetAIvoicesForHouse_ReturnsValid_InvoiceItem()
        {
            //arrange 
            var invoices = RepoMocks.RepositoryMocks.RepositoryInvoiceList(); 
            mockInvoiceRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .Returns(invoices[0]);  
            var test = mockInvoiceRepository.Object.GetById(1);  
            //act 
            var result = invoiceService.GetById(202);    
            //assert  
            mockInvoiceRepository.Verify(x => x.GetById(202), Times.Once);
        }
        [TestMethod]
        public void GetInvoice_ReturnsInValid_InvoiceItem()
        {
            //arrange 
            var invoices = RepoMocks.RepositoryMocks.RepositoryInvoiceList();

            mockInvoiceRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                             .Returns((Invoice)null); 
            var test = mockInvoiceRepository.Object.GetById(1); 
            //act 
            var result = invoiceService.GetById(99999); 
            //assert   
            Assert.IsNull(result);
        }
        [TestMethod]
        public void Edit_ChangeInvoice_ReturnsVoid()
        {
            //arrange
            var invoices = RepoMocks.RepositoryMocks.RepositoryInvoiceList();
            mockInvoiceRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                                    .Returns(invoices[0]);
             
            var newInv = mockInvoiceRepository.Object.GetById(1);
            newInv.Amount = 100M; 

            //act
            invoiceService.Edit(newInv.InvoiceId, newInv.HouseId, newInv.InvoiceDate, newInv.Description, newInv.IsPaid,newInv.DatePaid);
             var resultInv = invoiceService.GetById(newInv.InvoiceId);

            //assert
            Assert.IsTrue(resultInv.Equals(newInv));
            // CollectionAssert()
        }
    }
     

}
