using ESL.Core.Models.BusinessEntities;

namespace ESL.Core.IRepositories
{
    public interface IFacilityRepository : IGenericRepository<Facility>
    {
        public Task<Facility> GetFacility(int FacilNo);

        public Task<Facility> GetFacility(string FacilName);

        public Task<string> GetFacilName(int FacilNo);

        public Task<int> GetFacilNo(string FacilName);

        public Task<List<Facility>> GetFacilities();

        public Task<List<Facil>> GetFacilList();   

        public Task<List<string>> GetFacilTypeList();
    }

}