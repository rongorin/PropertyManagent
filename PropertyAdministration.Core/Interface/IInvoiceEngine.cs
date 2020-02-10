using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IInvoiceEngine
    {
        decimal GetBalance(int houseId);

    }
}
