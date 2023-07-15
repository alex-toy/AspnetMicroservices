using Grpc.Net.Client;
using Vehicles.Grpc.Protos;

namespace Transport.API.GrpcServices
{
    public class VehicleGrpcService
    {
        private readonly VehicleProtoService.VehicleProtoServiceClient _vehicleProtoService;

        public VehicleGrpcService(VehicleProtoService.VehicleProtoServiceClient vehicleProtoService)
        {
            //_vehicleProtoService = vehicleProtoService ?? throw new ArgumentNullException(nameof(vehicleProtoService));

            var channel = GrpcChannel.ForAddress("http://localhost:10000");
            _vehicleProtoService = new VehicleProtoService.VehicleProtoServiceClient(channel);
        }

        public async Task<SlotModel> Get(GetRequest request)
        {
            return await _vehicleProtoService.GetAsync(request);
        }

        public async Task<CreateSlotFromLocationResponse> CreateSlotFromLocation(string from, string to)
        {
            var vehicleRequest = new CreateSlotRequest
            {
                CurrentLocation = from,
                NewDestination = to
            };

            CreateSlotFromLocationResponse? slotResponse = await _vehicleProtoService.CreateSlotFromLocationAsync(vehicleRequest);


            return slotResponse;
        }

        public async Task<SlotModel> Update(string from, string to)
        {
            var vehicleRequest = new CreateSlotRequest
            {
                CurrentLocation = from,
                NewDestination = to
            };

            SlotModel? slotModel = await _vehicleProtoService.UpdateAsync(new UpdateRequest { });

            return slotModel;
        }
    }
}
