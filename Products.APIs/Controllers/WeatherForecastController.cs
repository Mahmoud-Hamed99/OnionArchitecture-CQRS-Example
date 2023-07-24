using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Service;

namespace Products.APIs.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        //  private readonly IProductQueryService _productQueryService;
        
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var res = await _mediator.Send(new GetProductsQuery());

           return Ok(res);
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var res = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(res);
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<ActionResult> AddNewProduct(ProductViewModel model)
        {
            var res = await _mediator.Send(new AddProductCommand(model));
            return Ok(res);

        } 
        
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(ProductViewModel model)
        {
            var res = await _mediator.Send(new UpdateProductCommand(model));
            return Ok(res);

        }
    }
}