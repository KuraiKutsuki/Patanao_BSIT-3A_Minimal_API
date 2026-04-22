using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIDemo.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; } // Primary key
        public string Name { get; set; } // Supplier name
        public string ContactInfo { get; set; } // Supplier contact information

        // Navigation property: One Supplier can have many Products
        public ICollection<Product> Products { get; set; }
    }
}
