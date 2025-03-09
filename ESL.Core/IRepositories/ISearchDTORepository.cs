using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.IRepositories
{
    public interface ISearchDTORepository
    {
        public Task<List<SearchDTO>> GetSearchDTOList(int facilNo, int logTypeNo, string startDate, string endDate, string operatorType, string optionAll, string searchValues);

        public Task<SearchDTO> GetSearchDTO(int facilNo, int logTypeNo, string eventID, int eventID_RevNo);       
    }
}
