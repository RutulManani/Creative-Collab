// Models/ECommerce/Order.cs
using System.Collections.Generic;
using EduFitMart.Models.School;

namespace EduFitMart.Models.ECommerce
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }

        // Link to Student (1:M)
        public int? StudentId { get; set; }
        public Student Student { get; set; }

        // M:M with Product (via OrderItem)
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}