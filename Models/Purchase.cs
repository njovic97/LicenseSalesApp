public class Purchase
{
    public int PurchaseId { get; set; }
    public int OrderId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Order Order { get; set; }
}
