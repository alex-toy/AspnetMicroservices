namespace Inventory.API.Entities
{
    public class Warehouse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

        public Warehouse(string name)
        {
            Name = name;
        }

        public int NumberItems
        {
            get
            {
                int numberItems = Items.Select(item => item.Quantity).Sum();
                return numberItems;
            }
        }
    }
}
