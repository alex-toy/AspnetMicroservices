using Vehicles.Grpc.Protos;

namespace Transport.API.GrpcServices
{
    public class VehicleGrpcService
    {
        private readonly VehicleProtoService.VehicleProtoServiceClient _vehicleProtoService;

        public VehicleGrpcService(VehicleProtoService.VehicleProtoServiceClient vehicleProtoService)
        {
            _vehicleProtoService = vehicleProtoService ?? throw new ArgumentNullException(nameof(vehicleProtoService));
        }

        public async Task<SlotModel> CreateSlot(string from)
        {
            var vehicleRequest = new CreateSlotRequest { CurrentLocation = from };

            return await _vehicleProtoService.CreateSlotAsync(vehicleRequest);
        }
    }
}
