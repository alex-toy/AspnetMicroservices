using Bikes.API.Entities;
using Bikes.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bikes.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeRepository _repository;

        public BikeController(IBikeRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{bikeId}", Name = "Get")]
        [ProducesResponseType(typeof(Bike), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bike>> Get(string bikeId)
        {
            Bike? bike = await _repository.Get(bikeId);
            return Ok(bike);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Bike), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bike>> Create([FromBody] Bike bike)
        {
            await _repository.Create(bike);
            return CreatedAtRoute("Get", new { BikeId = bike.BikeId }, bike);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Bike), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Bike>> Update([FromBody] Bike bike)
        {
            return Ok(await _repository.Update(bike));
        }

        [HttpDelete("{bikeId}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(string bikeId)
        {
            return Ok(await _repository.Delete(bikeId));
        }
    }
}
