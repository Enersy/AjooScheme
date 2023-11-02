using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Models
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }

        [key]
        public int Id { get; set; }

        public string PhoneNumber { get; set; }    

        public string Email { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string NextOfKin { get; set; }
        public string TypeOfContribution { get; set; }
        public double AmountToContribute { get; set; }
        public string ReleaseContributionDate { get; set; }
        public string AccountNo { get; set; }
        public double AccountBalance { get; set; }


    }
}

