namespace GiftelleCMSbackend.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
