using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TestApiMovie.Contract.Request;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Service;
using TestApiMovie.Service.Commands;
using TestApiMovie.Service.Commands.Delete;
using TestApiMovie.Service.Commands.Put;
namespace TestApiMovie.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductAsync([FromServices]IRequestHandler<IList<ProductResponse>> getProduct)
        {
            return Ok(await getProduct.Handle());
        }
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProductByIdAsync(int ProductId, IRequestHandler<int,ProductResponse> getProductById)
        {
            return Ok(await getProductById.Handle(ProductId));
        }
        [HttpPost]
        public async Task<IActionResult> UpsertProduct([FromServices] IRequestHandler<UpsertProductCommand, ProductResponse> upsertProduct, [FromBody]UpsertProductRequest request)
        {
            var product = await upsertProduct.Handle(new UpsertProductCommand
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                Price = request.Price,
                ProductCreated = request.ProductCreated,
            });
            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductById(int productId, [FromServices] IRequestHandler<DeleteProductCommand, bool> deleteProductById)
        {
            var delete = await deleteProductById.Handle(new DeleteProductCommand { ProductIdDel = productId });

            if (delete)
            {
                return Ok(delete);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct([FromServices] IRequestHandler<PutProductCommand, ProductResponse> putProduct, [FromBody] UpsertProductRequest request)
        {
            var product = await putProduct.Handle(new PutProductCommand
            {
                ProductIdPut = request.ProductId,
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                Price = request.Price,
                ProductCreated = request.ProductCreated,
            });
            return Ok(product);
        }
    }
}
