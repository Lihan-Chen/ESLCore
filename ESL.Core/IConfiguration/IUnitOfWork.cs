using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IConfiguration
{
    internal interface IUnitOfWork
    {
        public interface IUnitOfWork
        {

            // Add all IRepositories here
            IUserRepository Users { get; }

            IEmployeeRepository Employees { get; }

            IMeterRepository Meters { get; }

            IAllEventRepository AllEvents { get; }



            Task CompleteAsync();
        }
    }
}
}
