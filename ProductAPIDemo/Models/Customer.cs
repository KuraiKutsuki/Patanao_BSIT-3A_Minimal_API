namespace ProductAPIDemo.Models
{
    public class Customer
    {
        public int CustomerID { get; set; } // Primary key
        public string Name { get; set; } // Customer name
        public string Email { get; set; } // Customer email
        public string Phone { get; set; } // Customer phone number
    }
}
