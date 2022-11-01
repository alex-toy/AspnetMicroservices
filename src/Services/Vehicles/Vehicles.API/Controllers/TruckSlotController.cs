using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vehicles.API.Entities;

namespace Vehicles.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TruckSlotController : ControllerBase
    {
        private readonly ISlotRepository _repository;

        public TruckSlotController(ISlotRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{truckId}", Name = "Get")]
        [ProducesResponseType(typeof(TruckSlot), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TruckSlot>> Get(string truckId)
        {
            TruckSlot? truckSlot = await _repository.Get(truckId);
            return Ok(truckSlot);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TruckSlot), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TruckSlot>> Create([FromBody] TruckSlot truckSlot)
        {
            await _repository.Create(truckSlot);
            return CreatedAtRoute("Get", new { TruckId = truckSlot.TruckId }, truckSlot);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TruckSlot), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TruckSlot>> Update([FromBody] TruckSlot truckSlot)
        {
            return Ok(await _repository.Update(truckSlot));
        }

        [HttpDelete("{truckId}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(string truckId)
        {
            return Ok(await _repository.Delete(truckId));
        }
    }
}
