using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")] // api/Supplier
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public SupplierController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Supplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = await _dbContext.Suppliers.ToListAsync();
            return Ok(suppliers);
        }

        // POST: api/Supplier
        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();

            return Ok(supplier);
        }

        // PUT: api/Supplier/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSupplier(int id, Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSupplier = await _dbContext.Suppliers.FindAsync(id);

            if (existingSupplier == null)
            {
                return NotFound(new { message = "Supplier not found" });
            }

            existingSupplier.Name = supplier.Name;
            existingSupplier.ContactInfo = supplier.ContactInfo;

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Supplier updated successfully" });
        }

        // DELETE: api/Supplier/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSupplier = await _dbContext.Suppliers.FindAsync(id);

            if (existingSupplier == null)
            {
                return NotFound(new { message = "Supplier not found" });
            }

            _dbContext.Suppliers.Remove(existingSupplier);

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Supplier deleted successfully" });
        }
    }
}