public class Code
{
    public int CodeId { get; set; }
    public int VendorId { get; set; }
    public string CodeValue { get; set; }
    public string Category { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public bool IsSublicensed { get; set; }
    public bool IsGroupCode { get; set; }
    public Vendor Vendor { get; set; }
}
