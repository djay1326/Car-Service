using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bal
{
    public interface IInvoiceServices
    {
        void getDetailsForInvoice(int userId, int garageId, int carserviceId);
    }
}
