public class OrderDTO
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public required string CustomerName { get; set; }
}
