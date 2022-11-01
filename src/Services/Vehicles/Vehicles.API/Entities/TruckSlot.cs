namespace Vehicles.API.Entities
{
    public class TruckSlot
    {
        public int Id { get; set; }
        public string TruckId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
