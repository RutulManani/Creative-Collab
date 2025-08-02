using Microsoft.AspNetCore.Mvc;

namespace GiftelleCMSbackend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }

        // Navigation
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
