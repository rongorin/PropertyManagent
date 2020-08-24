using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Logging;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Core.Services
{
    public class XactionsService : IXactionsService
    {
        IXactionResository _repo;
        readonly IEmailSender _emailSender;
        readonly ILogger _logger;
        public XactionsService(IXactionResository repo, IEmailSender emailSender, ILoggerFactory loggerFactory)
        {
            _repo = repo;
            _emailSender = emailSender;
            _logger = loggerFactory?.CreateLogger<XactionsService>();
        }

        public Xaction ReadById(int id)
        {
            return _repo.ReadById(id);
            // return new Xaction( 1,"descr 123", 52);
        }

        public IEnumerable<XactionViewModel> ReadByHouseId(int houseId)
        {
            //return _repo.ReadByHouseId(id); 
            var transactionsList = _repo.GetAllByHouseId(houseId).ToList()
                .Select(a => new XactionViewModel {
                    Id = a.Id,
                    Description = a.Description,
                    Amount = a.Amount,
                    HouseId = a.HouseId
                });

            return transactionsList;
        }

        public bool Create(XactionViewModel vm)
        {
            if (vm.Amount > 20000.00M)
            {
                throw new ArgumentOutOfRangeException(nameof(vm.Amount));
            }
            Xaction transaction = new Xaction(vm.Id, vm.HouseId, vm.Description, vm.Amount);

            _repo.Create(transaction);

            _emailSender.SendEmail("jjones@abc.com", "New transaction created", "general message");

            _logger.Log(LogLevel.Information, "test log message");

            return true;
        }

        //public async Task<Xaction> ReadXaction(int id) 
        //{
        //    return await Task.FromResult(new Xaction(1, "descr 123", 52));
        //}
        public bool Update(XactionViewModel vm)
        {
            if (!Validate(vm))
                return false;

            Xaction transaction = new Xaction(vm.Id, vm.HouseId, vm.Description, vm.Amount);
            if (transaction.MaximumAmount())
                return false;

            _repo.Update(transaction);
            _repo.Save();
            return true;
        }
        private bool Validate(XactionViewModel vm)
        {
            return (vm.Id == 0 || vm.HouseId == 0) ? false : true;
        }
    }
}
