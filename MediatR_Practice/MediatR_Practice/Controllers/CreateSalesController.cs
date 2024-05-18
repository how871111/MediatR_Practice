using System.Threading.Tasks;
using MediatR;
using MediatR_Practice.Handlers;
using Microsoft.AspNetCore.Mvc;
using MediatR_Practice.Models;

namespace MediatR_Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateSalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateSalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Unit> Create(CreateSalesRequestModel command)
        {
            Unit response = await _mediator.Send(command);

            return response;
        }
    }
}