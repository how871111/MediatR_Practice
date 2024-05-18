using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatR_Practice.Models
{
    public class SetSalesOperatorRequestModel : INotification
    {
        public string SID { get; set; }
    }
}
