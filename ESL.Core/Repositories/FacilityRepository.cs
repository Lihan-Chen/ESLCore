using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ESL.Core.Repositories
{
    public class FacilityRepository : IFacilityRepository //,GenericRepository<Facility>, 
    {
        private readonly EslDbContext _context;
        private readonly ILogger<FacilityRepository> _logger;
        private DbSet<Facility> _dbSet;

        public FacilityRepository(
            EslDbContext context,
            ILogger<FacilityRepository> logger
            ) // : base(context, logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbSet = context.Set<Facility>();
        }

        public virtual async Task<string> GetFacilName(int facilNo)
        {
            string _FacilName = null!;

            if (facilNo != 0)
            {
                _FacilName = await _dbSet.Where(f => f.FacilNo == facilNo).Select(s => s.FacilName).FirstOrDefaultAsync();
                _FacilName = _FacilName?.Split(' ').ElementAt(0);
            }

            return _FacilName;
        }

        public async Task<IEnumerable<Facility>> GetAll() => await _dbSet.AsNoTracking().ToListAsync(); 

        // GetItem(int facilNo)
        public virtual async Task<Facility> GetFacility(int facilNo) => await _dbSet.FirstOrDefaultAsync(f => f.FacilNo == facilNo);

        public virtual async Task<Facility> GetFacility(string facilName)
        {
            Facility _facility = null;

            if (!String.IsNullOrEmpty(facilName))
            {
                _facility = await _dbSet.Where(f => facilName.ToUpper().Contains(f.FacilName.ToUpper())).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facility;
        }

        public virtual async Task<int> GetFacilNo(string facilName)
        {
            int _facilNo = 0;
            if (!String.IsNullOrEmpty(facilName))
            {
                _facilNo = await _dbSet.Where(f => facilName.ToUpper().Contains(f.FacilName.ToUpper())).Select(x => x.FacilNo).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facilNo;
        }

        public async Task<List<Facility>> GetFacilities() => await _dbSet.OrderBy(o => o.FacilNo).ToListAsync();
       
        public virtual async Task<List<Facil>> GetFacilList()
        {
            var plantFacilTypes = new List<string> { "OCC", "DsOCC", "PP", "TP", "FP", "DVL" };

            return await _dbSet.Where(f => plantFacilTypes.Contains(f.FacilType)).OrderBy(o => o.FacilNo).Select(x => new Facil { FacilNo = x.FacilNo, FacilName = x.FacilName, FacilAbbr = x.FacilAbbr }).AsNoTracking().ToListAsync();

            //return await dbSet.Where(f => f.FacilNo <= 13).OrderBy(o => o.FacilNo).Select(x => new Facil { FacilNo = x.FacilNo, FacilName = x.FacilName, FacilAbbr = x.FacilAbbr }).ToListAsync();
        }

        public virtual async Task<List<string>> GetFacilTypeList() => await _dbSet.AsNoTracking().Select(f => f.FacilType).Distinct().ToListAsync();
        
        
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
