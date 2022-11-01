namespace Inventory.API.Entities
{
    public class Arrival
    {
        public string WarehouseName { get; set; }
        public List<Item> Items { get; set; }
    }
}
