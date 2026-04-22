using System.ComponentModel.DataAnnotations;

namespace ProductAPIDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; } // Primary key
        public string Name { get; set; } // Product name
        public string Description { get; set; } // Product description

        [Range(1,1000000)]
        public decimal Price { get; set; } // Product price
        [Range(0, 10000)]
        public int Stock { get; set; } // Available stock quantity

        // Foreign keys and Navigation properties
        public int CategoryID { get; set; } // Foreign key for Category
        public Category? Category { get; set; } // Navigation property

        public int SupplierID { get; set; } // Foreign key for Supplier
        public Supplier? Supplier { get; set; } // Navigation property
    }
}
