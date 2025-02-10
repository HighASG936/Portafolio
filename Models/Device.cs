namespace Inventory.Models
{
    public class Device
    {
        public int Id { get; set; }
        public required string Part_Number { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public string? Supplier { get; set; }

    }
}
