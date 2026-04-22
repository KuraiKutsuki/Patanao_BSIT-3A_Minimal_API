using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")] // api/Category
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return Ok(categories);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return Ok(category);
        }

        // PUT: api/Category/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await _dbContext.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Category updated successfully" });
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid) // Optional validation
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await _dbContext.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            _dbContext.Categories.Remove(existingCategory);

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
