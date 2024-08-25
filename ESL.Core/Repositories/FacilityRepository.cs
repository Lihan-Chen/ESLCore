using ESL.Core.Data;
using ESL.Core.IRepositories;
using ESL.Core.Models;
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
    internal class FacilityRepository : GenericRepository<Facility>, IFacilityRepository
    {

        public FacilityRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        {
        }

        public virtual async Task<string> GetFacilName(int FacilNo)
        {
            string _FacilName = null!;

            if (FacilNo != 0)
            {
                _FacilName = await dbSet.Where(f => f.FacilNo == FacilNo).Select(s => s.FacilName).FirstOrDefaultAsync();
                _FacilName = _FacilName?.Split(' ').ElementAt(0);
            }

            return _FacilName;
        }

        public virtual async Task<int> GetFacilNo(string FacilName)
        {
            int _FacilNo = 0;
            if (!String.IsNullOrEmpty(FacilName))
            {
                _FacilNo = await dbSet.Where(f => f.FacilName.Contains(FacilName)).Select(x => x.FacilNo).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _FacilNo;
        }

        public virtual List<SelectListItem> GetFacilAbbrList()
        {
            var _selectItems = dbSet.Where(f => f.FacilNo <= 13).Select(f => new SelectListItem { Value = f.FacilNo.ToString(), Text = f.FacilAbbr }).ToList();
            
            return _selectItems;
        }

        public virtual List<SelectListItem> GetFacilTypes() // SelectListItem
        {
            var _facilTypes = dbSet.Where(item => item != null).Select(f => f.FacilType).Distinct().AsEnumerable();
            var _selectFacilTypes = _facilTypes.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }).ToList();
            SelectListItem _emptyString = new SelectListItem() { Value = String.Empty, Text = String.Empty };
            _selectFacilTypes.Insert(0, _emptyString);

            return _selectFacilTypes;
        }

        public virtual async Task<Facility> GetFacility(string FacilName)
        {
            Facility _facility = null;

            if (!String.IsNullOrEmpty(FacilName))
            {
                _facility = await dbSet.Where(f => f.FacilName.Contains(FacilName)).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facility;
        }
    }
}
