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
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrderAsync([FromServices] IRequestHandler<IList<OrderResponse>> getOrder)
        {
            return Ok(await getOrder.Handle());
        }

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrderByIdAsync(int OrderId, [FromServices] IRequestHandler<int, OrderResponse> getOrderById)
        {
            return Ok(await getOrderById.Handle(OrderId));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertOrder([FromServices] IRequestHandler<UpsertOrderCommand, OrderResponse> upsertOrder, [FromBody] UpsertOrderRequest request)
        {
            var order = await upsertOrder.Handle(new UpsertOrderCommand
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                OrderAmout = request.OrderAmout
            });
            return Ok(order);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrderById(int orderId, [FromServices] IRequestHandler<DeleteOrderCommand, bool> deleteOrderById)
        {
            var delete = await deleteOrderById.Handle(new DeleteOrderCommand { OrderIdDel = orderId });

            if (delete)
            {
                return Ok(delete);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> PutOrder([FromServices] IRequestHandler<PutOrderCommand, OrderResponse> putOrder, [FromBody] UpsertOrderRequest request)
        {
            var order = await putOrder.Handle(new PutOrderCommand
            {
                OrderIdPut = request.OrderId,
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                OrderAmout = request.OrderAmout
            });
            return Ok(order);
        }
    }
}
