using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TestApiMovie.Contract.Request;
using TestApiMovie.Contract.Responses;
using TestApiMovie.Data.Entites;
using TestApiMovie.Service;
using TestApiMovie.Service.Commands;
using TestApiMovie.Service.Commands.Delete;
using TestApiMovie.Service.Commands.Put;

namespace TestApiMovie.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCartAsync([FromServices]IRequestHandler<IList<CartResponse>> getCartQuery)
        {
            return Ok(await getCartQuery.Handle());
        }
        [HttpGet("{CartId}")]
        public async Task<IActionResult>GetCartByIdAsync(int CartId, [FromServices]IRequestHandler<int, CartResponse> getCartById)
        {
            return Ok(await getCartById.Handle(CartId));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCartAsync([FromServices] IRequestHandler<UpsertCartCommand, CartResponse> upsertCart,  [FromBody]UpsertCartRequest request)
        {
            var cart = await upsertCart.Handle(new UpsertCartCommand
            {
                Id = request.Id,
            });

            return Ok(cart);
        }

        [HttpDelete("{cartId}")]
        public async Task<IActionResult> DeleteCartById(int cartId, [FromServices] IRequestHandler<DeleteCartCommand, bool> deleteCartById)
        {
            var delete = await deleteCartById.Handle(new DeleteCartCommand { CartId = cartId });

            if (delete)
            {
                return Ok(delete);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> PutCartById([FromServices] IRequestHandler<PutCartCommand, CartResponse> putCartById, [FromBody] UpsertCartRequest request)
        {
            var cart = await putCartById.Handle(new PutCartCommand
            {
                CartId = request.Id,
            });

            return Ok(cart);
        }
    }
}
