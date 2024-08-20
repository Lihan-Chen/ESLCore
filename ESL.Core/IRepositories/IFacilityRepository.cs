using ESL.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESL.Core.IRepositories
{
    public interface IFacilityRepository : IGenericRepository<Facility>
    {
        public Task<string> GetFacilName(int facilNo);

        public Task<Facility> GetFacility(string facilName);

        public Task<int> GetFacilNo(string facilName);

        public List<SelectListItem> GetFacilAbbrList();

        public List<SelectListItem> GetFacilTypes(); // SelectListItem
    }

}