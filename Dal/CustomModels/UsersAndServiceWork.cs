using Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.CustomModels
{
    public class UsersAndServiceWork
    {
        public Users Users { get; set; }

        public IEnumerable<ServiceWork> ServiceWork { get; set; }
    }
}
