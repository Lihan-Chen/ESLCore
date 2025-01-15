using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Core.Repositories
{
    public class FacilityRepository : GenericRepository<Facility>, IFacilityRepository
    {

        public FacilityRepository(
            EslDbContext context,
            ILogger<FacilityRepository> logger
            ) : base(context, logger)
        {
        }

        public virtual async Task<string> GetFacilName(int facilNo)
        {
            string _FacilName = null!;

            if (facilNo != 0)
            {
                _FacilName = await dbSet.Where(f => f.FacilNo == facilNo).Select(s => s.FacilName).FirstOrDefaultAsync();
                _FacilName = _FacilName?.Split(' ').ElementAt(0);
            }

            return _FacilName;
        }

        public virtual async Task<Facility> GetFacility(int facilNo) => await dbSet.FirstOrDefaultAsync(f => f.FacilNo == facilNo);


        public virtual async Task<Facility> GetFacility(string facilName)
        {
            Facility _facility = null;

            if (!String.IsNullOrEmpty(facilName))
            {
                _facility = await dbSet.Where(f => f.FacilName.ToUpper().Contains(facilName.ToUpper())).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facility;
        }

        public virtual async Task<int> GetFacilNo(string facilName)
        {
            int _facilNo = 0;
            if (!String.IsNullOrEmpty(facilName))
            {
                _facilNo = await dbSet.Where(f => f.FacilName.ToUpper().Contains(facilName.ToUpper())).Select(x => x.FacilNo).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facilNo;
        }

        public virtual List<SelectListItem> GetFacilAbbrList()
        {
            var _selectItems = dbSet.Where(f => f.FacilNo <= 13).OrderBy(o => o.FacilNo).Select(f => new SelectListItem { Value = f.FacilNo.ToString(), Text = f.FacilAbbr }).ToList();
            
            return _selectItems;
        }

        public virtual List<SelectListItem> GetFacilTypes() // SelectListItem
        {
            var _facilTypes = dbSet.Where(item => item != null).Select(f => f.FacilType).Distinct();
            var _selectFacilTypes = _facilTypes.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
            SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
            _selectFacilTypes.Insert(0, _emptyString);

            return _selectFacilTypes;
        }        
    }
}
