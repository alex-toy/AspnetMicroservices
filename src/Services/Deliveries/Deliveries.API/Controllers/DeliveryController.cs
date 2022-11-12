using Deliveries.API.Entities;
using Deliveries.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deliveries.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryRepository _repository;
        //private readonly DiscountGrpcService _discountGrpcService;
        //private readonly IPublishEndpoint _publishEndpoint;
        //private readonly IMapper _mapper;

        public DeliveryController(
            IDeliveryRepository repository
            //DiscountGrpcService discountGrpcService
            //IPublishEndpoint publishEndpoint, 
            //IMapper mapper
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            //_discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
            //_publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{deliveryId}", Name = "Get")]
        [ProducesResponseType(typeof(Delivery), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Delivery>> Get(string deliveryId)
        {
            Delivery? delivery = await _repository.Get(deliveryId);
            return Ok(delivery ?? new Delivery("", ""));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Delivery), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Delivery>> Create([FromBody] Delivery delivery)
        {
            //await _vehicleGrpcService.CreateSlot(transportPlanning.From, transportPlanning.To);
            //_vehicleGrpcService.CreateSlot(transportPlanning.From, transportPlanning.To);

            return Ok(await _repository.Create(delivery));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Delivery), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Delivery>> Update([FromBody] Delivery delivery)
        {
            // Communicate with Discount.Grpc and calculate lastest prices of products into sc
            //foreach (var item in basket.Items)
            //{
            //    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
            //    item.Price -= coupon.Amount;
            //}

            return Ok(await _repository.Update(delivery));
        }

        [HttpDelete("{deliveryId}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string deliveryId)
        {
            await _repository.Delete(deliveryId);
            return Ok();
        }

        //[Route("[action]")]
        //[HttpPost]
        //[ProducesResponseType((int)HttpStatusCode.Accepted)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        //{
        //    // get existing basket with total price            
        //    // Set TotalPrice on basketCheckout eventMessage
        //    // send checkout event to rabbitmq
        //    // remove the basket

        //    // get existing basket with total price
        //    var basket = await _repository.GetBasket(basketCheckout.UserName);
        //    if (basket == null)
        //    {
        //        return BadRequest();
        //    }

        //    // send checkout event to rabbitmq
        //    var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
        //    eventMessage.TotalPrice = basket.TotalPrice;
        //    await _publishEndpoint.Publish<BasketCheckoutEvent>(eventMessage);

        //    // remove the basket
        //    await _repository.DeleteBasket(basket.UserName);

        //    return Accepted();
        //}
    }
}
