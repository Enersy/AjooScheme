using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Models
{
    public class Transaction:BaseEntity
    {
        [key]
        public int Id { get; set; }
        public string Type{ get; set; } = string.Empty;
        public double Amount{ get; set; }
        public string AccountNo{ get; set; } = string.Empty;
        public double Balance{ get; set; } 


    }
}
