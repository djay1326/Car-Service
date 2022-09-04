using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bal
{
    public interface IBillServices
    {
        void MakeBillOfWorkDone(List<ServiceWork> work, int loggedInUser);

        void DeleteRowInBill(int rowId);

    }
}
