namespace Vehicles.API.Entities
{
    public class TruckSlot
    {
        public int Id { get; set; }
        public string TruckId { get; set; }
        public string CurrentLocation { get; set; }
        public string CurrentDestination { get; set; }
        public int Capacity { get; set; }
    }
}
