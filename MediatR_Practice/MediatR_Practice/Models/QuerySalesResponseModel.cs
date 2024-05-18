using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatR_Practice.Models
{
    public class QuerySalesResponseModel
    {
        public string EXCHID { get; set; }
        public string BID { get; set; }
        public string SID { get; set; }
        public string NAME { get; set; }
    }
}
