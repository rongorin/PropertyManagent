using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using PropertyAdministration.Core.Model;
using System.Linq;
using Moq;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Services;
using PropertyAdministration.Test.TDD.TestingRepo;
using PropertyAdministration.Application.AppModels;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;

namespace PropertyAdministration.Test.TDD
{
   
    [TestClass]
    public class XactionsServiceTests
    {
        readonly Mock<IXactionResository> _dbAdaptorMock = new Mock<IXactionResository>();
        readonly Mock<IEmailSender> _emailSenderMock = new Mock<IEmailSender>();
        readonly Mock<ILogger> _loggerMock = new Mock<ILogger>();
        readonly Mock<ILoggerFactory> _loggerFactoryMock = new Mock<ILoggerFactory>();

        public XactionsService Service => new XactionsService(_dbAdaptorMock.Object, _emailSenderMock.Object,
                                                            _loggerFactoryMock.Object);

        public XactionsServiceTests()
        {
            _loggerFactoryMock.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(_loggerMock.Object);

        }

        //public XactionsService Service => new XactionsService(new XactionsTestDatabase()); 

        [TestMethod]    
        public void ReadById_ShouldReturnRecord()
        {
            //arrange
            int transId = 100;
             Xaction transaction = new Xaction(transId, 1, "Payment made for levy", 2200);  
            _dbAdaptorMock.Setup(x => x.ReadById(It.IsAny<int>())).Returns(transaction);  

            //act
            var result = Service.ReadById(transId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 100);
        }

        [TestMethod]
        public void List_VerifyShouldCallMethod()
        {
            //arrange
            int houseId = 100; 
             
            _dbAdaptorMock.Setup(x => x.GetAllByHouseId(It.IsAny<int>()))
                                                        .Returns(new List<Xaction>());

            //act
            var result = Service.ReadByHouseId(houseId);

            //Assert
            _dbAdaptorMock.Verify(x => x.GetAllByHouseId(It.IsAny<int>()), Times.Once);
             
        }

        [TestMethod]
        public void List_ShouldReturnList()
        {
            //arrange
            int houseId = 100;
            var listing = new List<Xaction>
            {
               new Xaction(1,houseId,"",900.00M) ,
               new Xaction(2,houseId,"",900.00M) ,
               new Xaction(3,houseId,"",150.00M)
            }; 
             
            _dbAdaptorMock.Setup(x => x.GetAllByHouseId(It.IsAny<int>()))
                                                        .Returns(listing);

            //act
            var result = Service.ReadByHouseId(houseId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 3);

        }

        [TestMethod]
        public void ReadById_PassNonExistantId_ShouldReturnNoRecord()
        {
            //arrange
            int transId = 100;
            Xaction transaction = new Xaction(transId, 1, "Payment made for levy", 2200);
            _dbAdaptorMock.Setup(x => x.ReadById(It.IsAny<int>())).Returns(transaction); 

            //act
            var result = Service.ReadById(999);

            //Assert
            Assert.AreNotEqual(result.Id, 999); 
        }
        [TestMethod]
        public void Create_ShouldReturnTrue()
        {
            //arrange   
            XactionViewModel xact = new XactionViewModel(); // xactList.Add(new Xaction(2, "Test Transaction2", 1200)); 
            _dbAdaptorMock.Setup(x => x.Create(It.IsAny<Xaction>())) ;

            //act
            var result = Service.Create(xact);

            //Assert
            Assert.IsTrue(result); 
        }
        [TestMethod]
        public void Update_NoDataSupplied_VerifyDoesNotCallToRepository()
        {
            //arrange   
            var vm = new XactionViewModel();

            //act
            var result = Service.Update(vm);

            //Assert 
            Assert.IsFalse(result);
            _dbAdaptorMock.Verify(x => x.Update(It.IsAny<Xaction>()),Times.Never);
             
        }
        [TestMethod]
        public void Update__VerifyCallsToRepository()
        {
            //arrange   
            //Xaction xact = new Xaction(transId, 2, "Test Transaction2", 1200); // xactList.Add(new Xaction(2, "Test Transaction2", 1200));  
            var vm = new XactionViewModel { Id=1,HouseId=111,Description="A",Amount=1000};

            //act
            var result = Service.Update(vm);

            //Assert 
            Assert.IsTrue(result);
            _dbAdaptorMock.Verify(x => x.Update(It.IsAny<Xaction>()), Times.Once);

            // Assert.IsTrue(result);
        }
        [TestMethod]
        public void Create_WhenTransactionAmountTooLarge_ThrowException()
        {
            //arrange   
            var vm = new XactionViewModel();
            vm.Amount = 21000.00M;
            vm.HouseId = 1;
            vm.Id = 1;
            vm.Description = "ddd"; 

            //act & Assert 
            var res =  Assert.ThrowsException <ArgumentOutOfRangeException>(() => Service.Create(vm)); 
             
        }
        [TestMethod]
        public void Create_ShouldSendEmail()
        {
            //arrange   
            XactionViewModel xact = new XactionViewModel();   
            _dbAdaptorMock.Setup(x => x.Create(It.IsAny<Xaction>()));

            //act
            var result = Service.Create(xact);

            //assert
            _emailSenderMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),Times.Once);
        }
        [TestMethod]
        public void Create_ShouldLogMessage()
        {
            //arrange   
            XactionViewModel xact = new XactionViewModel();
            _dbAdaptorMock.Setup(x => x.Create(It.IsAny<Xaction>()));

            //act
            var result = Service.Create(xact);

            //assert 
            // Verify mock doesnt work with extension methods :
            // _loggerMock.Verify(x => x.Log(It.IsAny< LogLevel>() , It.IsAny<string>()), Times.Once);
             var x =_loggerMock.Invocations[0].Arguments[2] as IReadOnlyList<KeyValuePair<string, object>>;
             Assert.IsTrue(_loggerMock.Invocations.Any(x => ((string)(x.Arguments[2] as IReadOnlyList<KeyValuePair<string, object>>)[0].Value).Contains("test log message")));

        }
    }


}