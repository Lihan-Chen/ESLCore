using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESL.Core.Models.BusinessEntities;
using ESL.Infrastructure.DataAccess;

namespace ESL.Web.Controllers
{
    public class ConstantsController : Controller
    {
        private readonly EslDbContext _context;

        public ConstantsController(EslDbContext context)
        {
            _context = context;
        }

        // GET: Constants
        public async Task<IActionResult> Index()
        {
            return View(await _context.EslContants.ToListAsync());
        }

        // GET: Constants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constant = await _context.EslContants
                .FirstOrDefaultAsync(m => m.FacilNo == id);
            if (constant == null)
            {
                return NotFound();
            }

            return View(constant);
        }

        // GET: Constants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Constants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacilNo,StartDate,ConstantName,Value,EndDate,Notes,UpdatedBy,UpdateDate")] Constant constant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constant);
        }

        // GET: Constants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constant = await _context.EslContants.FindAsync(id);
            if (constant == null)
            {
                return NotFound();
            }
            return View(constant);
        }

        // POST: Constants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacilNo,StartDate,ConstantName,Value,EndDate,Notes,UpdatedBy,UpdateDate")] EslConstant eslConstant)
        {
            if (id != eslConstant.FacilNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eslConstant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstantExists(eslConstant.FacilNo))
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
            return View(eslConstant);
        }

        // GET: Constants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constant = await _context.EslContants
                .FirstOrDefaultAsync(m => m.FacilNo == id);
            if (constant == null)
            {
                return NotFound();
            }

            return View(constant);
        }

        // POST: Constants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constant = await _context.EslContants.FindAsync(id);
            if (constant != null)
            {
                _context.EslContants.Remove(constant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstantExists(int id)
        {
            return _context.EslContants.Any(e => e.FacilNo == id);
        }
    }
}
