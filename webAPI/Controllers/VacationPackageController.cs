using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacationPackageController : ControllerBase
    {
        private readonly DataContext _context;

        public VacationPackageController(DataContext context)
        {
            _context = context;
        }

        // GET: api/VacationPackage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacationPackage>>> GetVacationPackages()
        {
            return await _context.VacationPackages.ToListAsync();
        }

        // GET: api/VacationPackage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacationPackage>> GetVacationPackage(int id)
        {
            var vacationPackage = await _context.VacationPackages.FindAsync(id);

            if (vacationPackage == null)
                return NotFound();

            return vacationPackage;
        }

        // PUT: api/VacationPackage/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacationPackage(int id, VacationPackage vacationPackage)
        {
            if (id != vacationPackage.Id)
                return BadRequest();

            _context.Entry(vacationPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationPackageExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // POST: api/VacationPackage
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VacationPackage>> PostVacationPackage(VacationPackage vacationPackage)
        {
            _context.VacationPackages.Add(vacationPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacationPackage", new { id = vacationPackage.Id }, vacationPackage);
        }

        // DELETE: api/VacationPackage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VacationPackage>> DeleteVacationPackage(int id)
        {
            var vacationPackage = await _context.VacationPackages.FindAsync(id);
            if (vacationPackage == null)
                return NotFound();

            _context.VacationPackages.Remove(vacationPackage);
            await _context.SaveChangesAsync();

            return vacationPackage;
        }

        private bool VacationPackageExists(int id)
        {
            return _context.VacationPackages.Any(e => e.Id == id);
        }
    }
}
