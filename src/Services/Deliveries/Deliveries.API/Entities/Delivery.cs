namespace Deliveries.API.Entities
{
    public class Delivery
    {
        public string DeliveryId { get; set; } 
        public string From { get; set; }
        public string To { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

        public Delivery()
        {
        }

        public Delivery(string from, string to)
        {
            From = from;
            To = to;
        }

        public decimal TotalQuantity
        {
            get
            {
                return Items.Sum(item => item.Quantity);
            }
        }
    }
}
