using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.IRepositories
{
    public interface ISearchDTORepository
    {
        public Task<List<SearchDTO>> GetSearchDTOList(int facilNo, int logTypeNo, string startDate, string endDate, string operatorType, string optionAll, string searchValues);

        public Task<SearchDTO> GetSearchDTO(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);       
    }
}
