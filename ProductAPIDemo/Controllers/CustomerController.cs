using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")] // api/Customer
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        // PUT: api/Customer/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCustomer = await _dbContext.Customers.FindAsync(id);

            if (existingCustomer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Customer updated successfully" });
        }

        // DELETE: api/Customer/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCustomer = await _dbContext.Customers.FindAsync(id);

            if (existingCustomer == null)
            {
                return NotFound(new { message = "Customer not found" });
            }

            _dbContext.Customers.Remove(existingCustomer);

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Customer deleted successfully" });
        }
    }
}
