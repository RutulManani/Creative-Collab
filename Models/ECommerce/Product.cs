// Models/ECommerce/Product.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduFitMart.Models.ECommerce
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // 1:M with Vendor
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        // M:M with Order (via OrderItem)
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}