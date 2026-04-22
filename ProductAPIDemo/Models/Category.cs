using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIDemo.Models
{
    public class Category
    {
        public int CategoryID { get; set; } // Primary key
        public string Name { get; set; } // Category name
        public string Description { get; set; } // Category description

        // Navigation property: One Category can have many Products
        public ICollection<Product> Products { get; set; }
    }
}
