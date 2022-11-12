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

        public CreateSlotFromLocationResponse CreateSlot(string from, string to)
        {
            var vehicleRequest = new CreateSlotRequest
            {
                CurrentLocation = from,
                NewDestination = to
            };

            return _vehicleProtoService.CreateSlotFromLocation(vehicleRequest);
        }

        //public async Task<CreateSlotFromLocationResponse> CreateSlot(string from, string to)
        //{
        //    var vehicleRequest = new CreateSlotRequest
        //    {
        //        CurrentLocation = from,
        //        NewDestination = to
        //    };

        //    CreateSlotFromLocationResponse? temp = _vehicleProtoService.CreateSlotFromLocation(vehicleRequest);

        //    return await _vehicleProtoService.CreateSlotFromLocation(vehicleRequest);
        //}

        //public async Task<SlotModel> Update(string from, string to)
        //{
        //    var vehicleRequest = new CreateSlotRequest
        //    {
        //        CurrentLocation = from,
        //        NewDestination = to
        //    };

        //    var temp = await _vehicleProtoService.Update(new UpdateRequest { });

        //    return temp;
        //}
    }
}
