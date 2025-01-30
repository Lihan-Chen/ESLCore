using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESL.Core.IRepositories
{
    public interface IFacilityRepository : IGenericRepository<Facility>
    {
        public Task<Facility> GetFacility(int FacilNo);

        public Task<Facility> GetFacility(string FacilName);

        public Task<string> GetFacilName(int FacilNo);

        public Task<int> GetFacilNo(string FacilName);

        public SelectList GetFacilAbbrList();   

        public SelectList GetFacilTypes(); // SelectListItem
    }

}