public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int CodeId { get; set; }
    public string OrderStatus { get; set; } = "Pending";
    public DateTime OrderDate { get; set; }
    public User User { get; set; }
    public Code Code { get; set; }
    public List<Purchase> Purchases { get; set; }
}
