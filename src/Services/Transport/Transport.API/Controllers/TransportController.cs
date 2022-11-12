using Microsoft.AspNetCore.Mvc;
using System.Net;
using Transport.API.Entities;
using Transport.API.GrpcServices;
using Transport.API.Repositories;

namespace Transport.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly ITransportRepository _repository;
        private readonly VehicleGrpcService _vehicleGrpcService;
        //private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IMapper _mapper;

        public TransportController(
            ITransportRepository repository,
            VehicleGrpcService vehicleGrpcService
        //IPublishEndpoint publishEndpoint,
        //IMapper mapper
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _vehicleGrpcService = vehicleGrpcService ?? throw new ArgumentNullException(nameof(vehicleGrpcService));
            //_publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{name}", Name = "Get")]
        [ProducesResponseType(typeof(TransportPlanning), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransportPlanning>> Get(string name)
        {
            TransportPlanning? TransportPlanning = await _repository.Get(name);
            return Ok(TransportPlanning ?? new TransportPlanning(name));
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(TransportPlanning), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransportPlanning>> Create([FromBody] TransportPlanning transportPlanning)
        {
            //await _vehicleGrpcService.CreateSlot(transportPlanning.From, transportPlanning.To);
            _vehicleGrpcService.CreateSlot(transportPlanning.From, transportPlanning.To);

            return Ok(await _repository.Update(transportPlanning));
        }

        [HttpPost("Update")]
        [ProducesResponseType(typeof(TransportPlanning), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TransportPlanning>> Update([FromBody] TransportPlanning TransportPlanning)
        {
            foreach (var item in TransportPlanning.Items)
            {
                //var coupon = await _vehicleGrpcService.GetDiscount(item.Name);
                //item.Quantity -= coupon.Amount;
            }

            return Ok(await _repository.Update(TransportPlanning));
        }

        [HttpDelete("{name}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string name)
        {
            await _repository.Delete(name);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddCheckout([FromBody] Checkout checkout)
        {
            TransportPlanning? TransportPlanning = await _repository.Get(checkout.UserName);
            if (TransportPlanning == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            //var eventMessage = _mapper.Map<BasketCheckoutEvent>(arrival);
            //eventMessage.TotalPrice = TransportPlanning.TotalPrice;
            //await _publishEndpoint.Publish(eventMessage);

            await _repository.Delete(TransportPlanning.UserName);

            return Accepted();
        }
    }
}
