using AjooScheme.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string NextOfKin { get; set; }

        public string AccountNo { get; set; }
        public double AccountBalance { get; set; }
        public string? ModifiedBy { get; set; }
        public bool isDeleted { get; set; }
    }
}
