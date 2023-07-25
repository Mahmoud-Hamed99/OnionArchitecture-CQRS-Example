using FluentValidation;
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
        private readonly IValidator<ProductViewModel> _productValidator;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IValidator<ProductViewModel> productValidator, IMediator mediator)
        {
            _logger = logger;
            _productValidator = productValidator;
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
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            var res = await _mediator.Send(new AddProductCommand(model));
            return StatusCode(StatusCodes.Status201Created , "User Created Successfully");
        } 
        
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(ProductViewModel model)
        {
            var validationRes = _productValidator.Validate(model);

            if (!validationRes.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validationRes.Errors);
            }

            var res = await _mediator.Send(new UpdateProductCommand(model));
            return Ok(res);

        }
    }
}