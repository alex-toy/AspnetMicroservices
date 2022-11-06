using AutoMapper;
using Grpc.Core;
using Vehicles.Grpc.Entities;
using Vehicles.Grpc.Protos;

namespace Vehicles.Grpc.Services
{
    public class VehicleService : VehicleProtoService.VehicleProtoServiceBase
    {
        private readonly ISlotRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<VehicleService> _logger;

        public VehicleService(
            ISlotRepository repository,
            IMapper mapper,
            ILogger<VehicleService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<SlotModel> Get(GetRequest request, ServerCallContext context)
        {
            TruckSlot? Slot = await _repository.Get(request.TruckId);
            if (Slot == null)
            {
                string errorMessage = $"Truck Slot with TruckId={request.TruckId} is not found.";
                throw new RpcException(new Status(StatusCode.NotFound, errorMessage));
            }
            string logMessage = $"Slot is retrieved for TruckId : {Slot.TruckId}.";
            _logger.LogInformation(logMessage);

            SlotModel? SlotModel = _mapper.Map<SlotModel>(Slot);
            return SlotModel;
        }

        public override async Task<SlotModel> CreateSlotFromLocation(CreateSlotRequest request, ServerCallContext context)
        {
            TruckSlot? Slot = _mapper.Map<TruckSlot>(request.CurrentLocation);

            await _repository.Create(Slot);

            _logger.LogInformation($"Truck Slot is successfully allocated. TruckId : {Slot.TruckId}");

            SlotModel? SlotModel = _mapper.Map<SlotModel>(Slot);
            return SlotModel;
        }

        public override async Task<SlotModel> CreateSlot(CreateRequest request, ServerCallContext context)
        {
            TruckSlot? Slot = _mapper.Map<TruckSlot>(request.slot);

            await _repository.Create(Slot);

            _logger.LogInformation($"Truck Slot is successfully allocated. TruckId : {Slot.TruckId}");

            SlotModel? SlotModel = _mapper.Map<SlotModel>(Slot);
            return SlotModel;
        }

        public override async Task<SlotModel> Update(UpdateRequest request, ServerCallContext context)
        {
            TruckSlot? truckSlot = _mapper.Map<TruckSlot>(request.Slot);

            await _repository.Update(truckSlot);
            _logger.LogInformation($"Truck Slot is successfully updated. TruckId : {truckSlot.TruckId}");

            SlotModel? SlotModel = _mapper.Map<SlotModel>(truckSlot);
            return SlotModel;
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            bool deleted = await _repository.Delete(request.TruckId);
            DeleteResponse? response = new DeleteResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}
