namespace Transport.API.Entities
{
    public class TransportPlanning
    {
        public string UserName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();

        public TransportPlanning()
        {
        }

        public TransportPlanning(string userName)
        {
            From = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = Items.Select(item => item.Price).Sum();
                return totalPrice;
            }
        }

        public decimal NumberItems
        {
            get
            {
                decimal numberItems = Items.Select(item => item.Quantity).Sum();
                return numberItems;
            }
        }
    }
}
