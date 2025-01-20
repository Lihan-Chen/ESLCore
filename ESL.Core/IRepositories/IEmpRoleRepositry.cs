using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IRepositories
{
    public interface IEmpRoleRepositry
    {
        public Task<string> GetRole(string userID, int facilNo);

        public Task<bool> IsInRole(string userID, string role, int facilNo);
    }
}
