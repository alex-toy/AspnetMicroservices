namespace Transport.API.Entities
{
    public class Checkout
    {
        public string UserName { get; set; }
        public List<TransportPlanning> Transports { get; set; }

        // BillingAddress
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        // Payment
        public string CardNumber { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = Transports.Select(item => item.TotalPrice).Sum();
                return totalPrice;
            }
        }

        public decimal NumberItems
        {
            get
            {
                decimal numberItems = Transports.Select(item => item.NumberItems).Sum();
                return numberItems;
            }
        }
    }
}
