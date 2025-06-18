using ESL.Core.Models.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Application.Interfaces.IServices
{
    public interface ISearchService
    {
        public Task<SearchDTO?> GetSearchDTO(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);

        public Task<List<SearchDTO>> GetSearchDTOList(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues);
    }
}
