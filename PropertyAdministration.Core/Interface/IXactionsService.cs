using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Model;
using System.Collections.Generic;

namespace PropertyAdministration.Core.Interface
{
    public interface IXactionsService
    {
        bool Create(XactionViewModel vm);
        IEnumerable<XactionViewModel> ReadByHouseId(int houseId);
        Xaction ReadById(int id);
        bool Update(XactionViewModel vm);
    }
}