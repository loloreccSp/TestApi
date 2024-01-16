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
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomerAsync([FromServices]IRequestHandler<IList<CustomerResponse>> getCustomer)
        {
            return Ok(await getCustomer.Handle());
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int CustomerId,[FromServices]IRequestHandler<int,CustomerResponse> getCustomerById)
        {
            return Ok(await getCustomerById.Handle(CustomerId));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCustomer([FromServices]IRequestHandler<UpsertCustomerCommand,CustomerResponse> upsertCustomer, [FromBody]UpsertCustomerRequest request)
        {
            var customer = await upsertCustomer.Handle(new UpsertCustomerCommand
            {
                CustomerId = request.CustomerId,
                CustomerLogin = request.CustomerLogin,
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                CustomerCreated = request.CustomerCreated,
            });
            return Ok(customer);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerById(int customerId, [FromServices] IRequestHandler<DeleteCustomerCommand, bool> deleteCustomerById)
        {
            var delete = await deleteCustomerById.Handle(new DeleteCustomerCommand { CustomerIdDel = customerId });

            if (delete)
            {
                return Ok(delete);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomer([FromServices] IRequestHandler<PutCustomerCommand, CustomerResponse> putCustomer, [FromBody] UpsertCustomerRequest request)
        {
            var customer = await putCustomer.Handle(new PutCustomerCommand
            {
                CustomerIdPut = request.CustomerId,
                CustomerLogin = request.CustomerLogin,
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerPhone = request.CustomerPhone,
                CustomerCreated = request.CustomerCreated,
            });
            return Ok(customer);
        }
    }
}
