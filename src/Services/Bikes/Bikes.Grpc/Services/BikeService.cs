using AutoMapper;
using Bikes.Grpc.Entities;
using Bikes.Grpc.Protos;
using Bikes.Grpc.Repositories;
using Grpc.Core;

namespace Bikes.Grpc.Services
{
    public class BikeService : BikeProtoService.BikeProtoServiceBase
    {
        private readonly IBikeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BikeService> _logger;

        public BikeService(
            IBikeRepository repository,
            IMapper mapper,
            ILogger<BikeService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<BikeModel> Get(GetRequest request, ServerCallContext context)
        {
            Bike? bike = await _repository.Get(request.BikeId);
            if (bike == null)
            {
                string errorMessage = $"Bike with BikeId={request.BikeId} is not found.";
                throw new RpcException(new Status(StatusCode.NotFound, errorMessage));
            }
            string logMessage = $"Bike is retrieved for BikeId : {bike.BikeId}.";
            _logger.LogInformation(logMessage);

            BikeModel? SlotModel = _mapper.Map<BikeModel>(bike);
            return SlotModel;
        }

        public override async Task<BikeModel> AllocateBike(BikeModel bikeModel, ServerCallContext context)
        {
            Bike? bike = _mapper.Map<Bike>(bikeModel);
            bool success = await _repository.Update(bike);

            string logMessage = $"Bike is successfully allocated. BikeId : {bike.BikeId}.";

            _logger.LogInformation(logMessage);

            return bikeModel;
        }

        public override async Task<BikeModel> CreateBike(CreateRequest request, ServerCallContext context)
        {
            Bike? bike = _mapper.Map<Bike>(request.Bike);

            await _repository.Create(bike);

            _logger.LogInformation($"Bike is successfully created. BikeId : {bike.BikeId}");

            BikeModel? bikeModel = _mapper.Map<BikeModel>(bike);
            return bikeModel;
        }

        public override async Task<BikeModel> Update(UpdateRequest request, ServerCallContext context)
        {
            Bike? truckSlot = _mapper.Map<Bike>(request.Bike);

            await _repository.Update(truckSlot);
            _logger.LogInformation($"Bike is successfully updated. BikeId : {truckSlot.BikeId}");

            BikeModel? bikeModel = _mapper.Map<BikeModel>(truckSlot);
            return bikeModel;
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            bool deleted = await _repository.Delete(request.BikeId);
            DeleteResponse? response = new DeleteResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}
