using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESL.Core.Data;
using ESL.Core.Models.BusinessEntities;

namespace ESL.Mvc.Areas.HotLineOrder.Controllers
{
    [Area("HotLineOrder")]
    public class FacilityController : Controller
    {
        private readonly EslDbContext _context;

        public FacilityController(EslDbContext context)
        {
            _context = context;
        }

        // GET: HotLineOrder/Facility
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facilities.ToListAsync());
        }

        // GET: HotLineOrder/Facility/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .FirstOrDefaultAsync(m => m.FacilNo == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // GET: HotLineOrder/Facility/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotLineOrder/Facility/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilNo,FacilName,FacilAbbr,FacilType,SortNo,Notes,UpdatedBy,UpdateDate,Disable,VisibleTo,FacilFullName")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facility);
        }

        // GET: HotLineOrder/Facility/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }
            return View(facility);
        }

        // POST: HotLineOrder/Facility/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacilNo,FacilName,FacilAbbr,FacilType,SortNo,Notes,UpdatedBy,UpdateDate,Disable,VisibleTo,FacilFullName")] Facility facility)
        {
            if (id != facility.FacilNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(facility.FacilNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(facility);
        }

        // GET: HotLineOrder/Facility/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await _context.Facilities
                .FirstOrDefaultAsync(m => m.FacilNo == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST: HotLineOrder/Facility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility != null)
            {
                _context.Facilities.Remove(facility);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return _context.Facilities.Any(e => e.FacilNo == id);
        }
    }
}
