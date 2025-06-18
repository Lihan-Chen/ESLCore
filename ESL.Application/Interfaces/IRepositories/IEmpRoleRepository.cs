using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Interfaces.IRepositories
{
    public interface IEmpRoleRepository
    {
        public Task<string> GetRole(string userID, int? facilNo);

        public bool IsInRole(string userID, string role, int? facilNo);
    }
}
