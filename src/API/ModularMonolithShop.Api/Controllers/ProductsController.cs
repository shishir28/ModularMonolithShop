
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModularMonolithShop.Catalog.Application.Commands.CreateProduct;
using ModularMonolithShop.Catalog.Application.Commands.DeleteProduct;
using ModularMonolithShop.Catalog.Application.Queries.GetProductByCategory;
using ModularMonolithShop.Catalog.Application.Queries.GetProductById;
using ModularMonolithShop.Catalog.Application.Queries.GetProducts;

namespace ModularMonolithShop.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _mediator.Send(new GetProductsQuery());
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{productId}", Name = "GetProductDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductDetail(Guid productId)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery(productId));
                return Ok(product);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("category/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            try
            {

                var products = await _mediator.Send(new GetProductByCategoryQuery(category));
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> AddProduct(CreateProductCommand createProductCommand)
        {
            try
            {
                var id = await _mediator.Send(createProductCommand);
                // 200 OK is not correct response type. it should be 201. Will come to it later
                return Ok(id);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            try
            {
                var result = await _mediator.Send(updateProductCommand);
                // 200 OK is not correct response type. it should be 201. Will come to it later
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{productId}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> DeleteProduct(Guid productId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProductCommand(productId));
                // 200 OK is not correct response type. it should be 201. Will come to it later
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an appropriate error response
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}