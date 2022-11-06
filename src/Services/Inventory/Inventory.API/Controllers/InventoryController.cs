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
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(
            IInventoryRepository repository, 
            ILogger<InventoryController> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

            warehouse.Items = arrival.Items;

            await _repository.Update(warehouse);

            return Accepted();
        }
    }
}
