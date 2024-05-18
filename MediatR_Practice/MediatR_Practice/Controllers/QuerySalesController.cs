using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediatR_Practice.Models;
using System.Threading;

namespace MediatR_Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuerySalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuerySalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<QuerySalesResponseModel> Query(QuerySalesRequestModel query)
        {
            QuerySalesResponseModel response = await _mediator.Send(query);

            return response;
        }
    }
}