using Inventory.API.Entities;
using Inventory.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _repository;
        //private readonly DiscountGrpcService _discountGrpcService;
        //private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IMapper _mapper;

        public InventoryController(
            IInventoryRepository repository
            //DiscountGrpcService discountGrpcService,
            //IPublishEndpoint publishEndpoint,
            //IMapper mapper
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            //_discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            //_publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{name}", Name = "Get")]
        [ProducesResponseType(typeof(Warehouse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Warehouse>> Get(string name)
        {
            Warehouse? warehouse = await _repository.Get(name);
            return Ok(warehouse ?? new Warehouse(name));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Warehouse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Warehouse>> Update([FromBody] Warehouse warehouse)
        {
            foreach (var item in warehouse.Items)
            {
                //var coupon = await _discountGrpcService.GetDiscount(item.Name);
                //item.Quantity -= coupon.Amount;
            }

            return Ok(await _repository.Update(warehouse));
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
        public async Task<IActionResult> AddArrival([FromBody] Arrival arrival)
        {
            Warehouse? warehouse = await _repository.Get(arrival.WarehouseName);
            if (warehouse == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            //var eventMessage = _mapper.Map<BasketCheckoutEvent>(arrival);
            //eventMessage.TotalPrice = warehouse.TotalPrice;
            //await _publishEndpoint.Publish(eventMessage);

            await _repository.Delete(warehouse.Name);

            return Accepted();
        }
    }
}
