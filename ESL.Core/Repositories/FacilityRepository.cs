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

        public virtual async Task<string> GetFacilName(int facilNo)
        {
            string _facilName = null!;

            if (facilNo != 0)
            {
                _facilName = await dbSet.Where(f => f.FacilNo == facilNo).Select(s => s.FacilName).FirstOrDefaultAsync();
                _facilName = _facilName?.Split(' ').ElementAt(0);
            }

            return _facilName;
        }

        public virtual async Task<int> GetFacilNo(string facilName)
        {
            int _facilNo = 0;
            if (!String.IsNullOrEmpty(facilName))
            {
                _facilNo = await dbSet.Where(f => f.FacilName.Contains(facilName)).Select(x => x.FacilNo).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facilNo;
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

        public virtual async Task<Facility> GetFacility(string facilName)
        {
            Facility _facility = null;

            if (!String.IsNullOrEmpty(facilName))
            {
                _facility = await dbSet.Where(f => f.FacilName.Contains(facilName)).FirstOrDefaultAsync(); //.Split(' ').ElementAt(0);
            }
            return _facility;
        }
    }
}
