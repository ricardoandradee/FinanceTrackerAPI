using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Dtos.Email
{
    public class EmailDetailsDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SuccessMessage { get; set; }
    }
}
