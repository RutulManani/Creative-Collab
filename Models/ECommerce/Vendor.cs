// Models/ECommerce/Vendor.cs
using System.Collections.Generic;

namespace EduFitMart.Models.ECommerce
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }

        // 1:M with Product
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}