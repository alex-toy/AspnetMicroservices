namespace Bikes.API.Entities
{
    public class Bike
    {
        public int Id { get; set; }
        public string? BikeId { get; set; }
        public string? CurrentLocation { get; set; }
        public string? Destination { get; set; }
        public int? Capacity { get; set; }
    }
}
