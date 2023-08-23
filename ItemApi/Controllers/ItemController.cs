using AppLibrary;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ItemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        readonly IBus _bus;

        public ItemController(ILogger<ItemController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet]
        public IActionResult GetListOfItems()
        {
            var listOfItems = Enumerable.Range(0, 10)
                .Select(_ => new ItemCreated())
                .ToList();

            return Ok(listOfItems);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem()
        {
            var itemCreated = new ItemCreated();
            Console.WriteLine($"Item Api: Published item with Id {itemCreated.Id.ToString()}.");
            await _bus.Publish(itemCreated);

            return Created("", itemCreated);
        }
    }
}