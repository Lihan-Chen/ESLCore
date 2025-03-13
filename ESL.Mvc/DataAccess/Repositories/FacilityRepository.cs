using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using ESL.Mvc.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ESL.Mvc.DataAccess.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly EslDbContext _context;
        private readonly ILogger<FacilityRepository> _logger;

        public FacilityRepository(
            EslDbContext context,
            ILogger<FacilityRepository> logger
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

        public IOrderedQueryable<Facility> GetAll()
        {
            var query = _context.Facilities.AsNoTracking().Where(d => d.Disable == null || d.Disable != "Y");

            return query.OrderBy(f => f.FacilNo);
        }

        // GetItem(int facilNo)
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

        //{
        //    return await dbSet.Where(item => item != null).OrderBy(o => o.FacilNo).Select(f => f.FacilType).Distinct().ToListAsync();

        //var _facilTypes = dbSet.Where(item => item != null).Select(f => f.FacilType).Distinct();
        //var _selectFacilTypes = _facilTypes.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
        //SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
        //_selectFacilTypes.Insert(0, _emptyString);

        //return _selectFacilTypes;

        //var _facilTypes =  await dbSet.Where(item => item != null).Distinct().ToListAsync();

        //var _selectFacilTypes = new SelectList(_facilTypes, "FacilType", "FacilType");

        //SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
        //_selectFacilTypes.Prepend(_emptyString);

        //return _selectFacilTypes;
        //}
    }
}
