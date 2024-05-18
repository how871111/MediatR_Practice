using System.Threading.Tasks;
using MediatR;
using MediatR_Practice.Handlers;
using Microsoft.AspNetCore.Mvc;
using MediatR_Practice.Models;

namespace MediatR_Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetSalesOperatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SetSalesOperatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task SetSalesOperator(SetSalesOperatorRequestModel request)
        {
            await _mediator.Publish(request);

        }
    }
}