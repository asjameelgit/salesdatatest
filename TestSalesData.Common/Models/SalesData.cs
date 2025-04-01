namespace TestSalesData.Common.Models
{
    public record SalesData
    {
        public string Segment { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        public decimal UnitsSold { get; set; } = decimal.Zero;
        public decimal MfgPrice { get; set; } = decimal.Zero;
        public decimal SalesPrice { get; set; } = decimal.Zero;
        public DateTime? SalesDate { get; set; }

    }
}
