using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Dtos.TransactionDto
{
    public class UpdateTransactionDto
    {
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string AccountNo { get; set; } = string.Empty;
    }
}
