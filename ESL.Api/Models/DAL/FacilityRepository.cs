using ESL.Api.Models.BusinessEntities;
using ESL.Api.Models.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Extensions;
using Facil = ESL.Api.Models.BusinessEntities.Facil;
using Facility = ESL.Api.Models.BusinessEntities.Facility;

namespace ESL.Api.Models.DAL
{
    public class FacilityRepository : IFacilityRepository
    {
        private ApplicationDbContext _context;

        private ILogger<FacilityRepository> _logger;

        public FacilityRepository(
            ApplicationDbContext context,
            ILogger<FacilityRepository> logger
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IOrderedQueryable<Facility> GetAll()
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            return query.OrderBy(f => f.FacilNo);
        }

        public IQueryable<Facility> GetFacility(int? facilNo)
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            if (facilNo != null)
            {
                query = query.Where(e => e.FacilNo == facilNo);
            }
            return query;
        }

        public IQueryable<Facility> GetFacility(string facilName)
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            if (!string.IsNullOrEmpty(facilName))
            {
                query = query.Where(f => facilName.ToUpper().Contains(f.FacilName.ToUpper()));
                // query = query.Where(f => facilName.Contains(f.FacilName, StringComparison.CurrentCultureIgnoreCase));
            }
            return query;
        }

        public async Task<string> GetFacilName(int facilNo)
        {
            string _facilName = null!;

            if (facilNo != 0)
            {
                _facilName = await this.GetFacility(facilNo).Select(s => s.FacilName).FirstOrDefaultAsync();
                _facilName = _facilName!.Split(' ').ElementAt(0);
            }

            return _facilName;
        }

        public async Task<int> GetFacilNo(string facilName)
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            int _facilNo = 0;

            if (!string.IsNullOrEmpty(facilName))
            {
                _facilNo = await this.GetFacility(facilName).Select(x => x.FacilNo).FirstOrDefaultAsync();
            }
            return _facilNo;
        }

        public IOrderedQueryable<Facility> GetFacilities()
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            return query.OrderBy(f => f.FacilNo);
        }

        public IOrderedQueryable<Facil> GetFacilList()
        {
            var plantFacilTypes = new List<string> { "OCC", "DsOCC", "PP", "TP", "FP", "DVL" };

            return this.GetFacilities().Where(f => plantFacilTypes.Contains(f.FacilType)).Select(x => new Facil { FacilNo = x.FacilNo, FacilName = x.FacilName, FacilAbbr = x.FacilAbbr }).OrderBy(o => o.FacilNo);
        }

        public IQueryable<string> GetFacilTypeList()
        {
            return this.GetFacilities().Select(x => x.FacilType).Distinct();
        }
    }
}
