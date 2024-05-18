using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatR_Practice.Models
{
    public class QuerySalesRequestModel : IRequest<QuerySalesResponseModel>
    {
        public string SID { get; set; }
    }
}
